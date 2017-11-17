using System.Collections.Generic;
using System.IO;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod;
using SpiritMod.Items;

namespace SpiritMod.Projectiles
{
	public class gProj : GlobalProjectile
	{
		private static bool hasNext = false;
		private static int nextType;
		private static GlyphType nextGlyph;

		private GlyphType glyph;
		public GlyphType Glyph => glyph;

		public override bool InstancePerEntity => true;


		public override void SetDefaults(Projectile projectile)
		{
			bool send = true;
			if (MyPlayer.swingingCheck && MyPlayer.swingingItem != null)
				glyph = MyPlayer.swingingItem.GetGlobalItem<GItem>().Glyph;
			else if (Main.ProjectileUpdateLoopIndex >= 0)
			{
				Projectile source = Main.projectile[Main.ProjectileUpdateLoopIndex];
				if (source.active && source.owner == Main.myPlayer)
					glyph = source.GetGlobalProjectile<gProj>().glyph;
			}
			else if (hasNext)
			{
				send = false;
				hasNext = false;
				if (projectile.type == nextType)
					glyph = nextGlyph;
			}
			else
				glyph = 0;
			
			if (send && glyph != 0 && Main.netMode != 0)
			{
				ModPacket packet = mod.GetPacket(4);
				packet.Write((byte)1);
				packet.Write((short)projectile.type);
				packet.Write((byte)glyph);
				packet.Send();
			}
		}

		internal static void ReceiveProjectileData(BinaryReader reader, int sender)
		{
			hasNext = true;
			nextType = reader.ReadInt16();
			nextGlyph = (GlyphType)reader.ReadByte();
			if (Main.netMode != 2)
				return;

			ModPacket packet = SpiritMod.instance.GetPacket(4);
			packet.Write((byte)1);
			packet.Write((short)nextType);
			packet.Write((byte)nextGlyph);
			packet.Send(-1, sender);
		}


		public override bool? CanHitNPC(Projectile projectile, NPC target)
		{
			if (projectile.aiStyle == 88 && ((projectile.knockBack == .5f || projectile.knockBack == .4f) || (projectile.knockBack >= .4f && projectile.knockBack < .5f)) && target.immune[projectile.owner] > 0)
			{
				return false;
			}
			return null;
		}

		public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (glyph == GlyphType.Daze)
				Items.Glyphs.DazeGlyph.Daze(target, ref damage);

			Player player = Main.player[projectile.owner];
			if (player.GetModPlayer<MyPlayer>(mod).reachSet && target.life <= target.life / 2)
			{
				if (projectile.thrown && crit)
					damage = (int)((double)damage * 2f);
			}
		}

		public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
			Player player = Main.player[projectile.owner];
			
			switch (glyph)
			{
				case GlyphType.Poison:
					if (crit & projectile.type != PoisonCloud._type)
						Items.Glyphs.PoisonGlyph.ReleasePoisonClouds(target, projectile.owner);
					break;
				case GlyphType.Blood:
					Items.Glyphs.BloodGlyph.BloodCorruption(Main.player[projectile.owner], target);
					break;
				case GlyphType.Scorch:
					Items.Glyphs.ScorchGlyph.Scorch(target, crit);
					break;
				case GlyphType.Bee:
					if (projectile.type != ProjectileID.Bee && projectile.type != ProjectileID.GiantBee)
						Items.Glyphs.BeeGlyph.ReleaseBees(player, target, damage);
					break;
				case GlyphType.Void:
					if (projectile.type != VoidStar._type)
						Items.Glyphs.VoidGlyph.VoidEffects(player, target, damage);
					break;
			}

			if (projectile.aiStyle == 88 && (projectile.knockBack >= .2f && projectile.knockBack <= .5f))
			{
				target.immune[projectile.owner] = 6;
			}
			if (projectile.friendly && projectile.thrown && Main.rand.Next(8) == 1 && player.GetModPlayer<MyPlayer>(mod).geodeSet == true)
			{
				target.AddBuff(24, 150);
			}
			if (projectile.friendly && projectile.thrown && Main.rand.Next(8) == 1 && player.GetModPlayer<MyPlayer>(mod).geodeSet == true)
			{
				target.AddBuff(44, 150);
			}
		}

		public override void ModifyHitPvp(Projectile projectile, Player target, ref int damage, ref bool crit)
		{
			if (glyph == GlyphType.Daze)
				Items.Glyphs.DazeGlyph.Daze(target, ref damage);
		}

		public override void OnHitPvp(Projectile projectile, Player target, int damage, bool crit)
		{
			Player player = Main.player[projectile.owner];
			switch (glyph)
			{
				case GlyphType.Poison:
					if (crit & projectile.type != PoisonCloud._type)
						Items.Glyphs.PoisonGlyph.ReleasePoisonClouds(target, projectile.owner);
					break;
				case GlyphType.Blood:
					Items.Glyphs.BloodGlyph.BloodCorruption(Main.player[projectile.owner], target);
					break;
				case GlyphType.Scorch:
					Items.Glyphs.ScorchGlyph.Scorch(target, crit);
					break;
				case GlyphType.Bee:
					if (projectile.type != ProjectileID.Bee && projectile.type != ProjectileID.GiantBee)
						Items.Glyphs.BeeGlyph.ReleaseBees(player, target, damage);
					break;
				case GlyphType.Void:
					if (projectile.type != VoidStar._type)
						Items.Glyphs.VoidGlyph.VoidEffects(player, target, damage);
					break;
			}
		}


		public override void AI(Projectile projectile)
		{//todo - forking lightning in Kill(), kill projectile when far from player in AI(), homing in OnHitNPC()
			if (projectile.aiStyle == 88 && projectile.knockBack == .5f || (projectile.knockBack >= .2f && projectile.knockBack < .5f))
			{
				projectile.hostile = false;
				projectile.friendly = true;
				projectile.magic = true;
				projectile.penetrate = -1;
			}
		}

	}
}
