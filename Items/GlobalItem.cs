using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

using SpiritMod.NPCs;
using SpiritMod.Mounts;

namespace SpiritMod.Items
{
	public class GItem : GlobalItem
	{
		public override bool InstancePerEntity => true;
		public override bool CloneNewInstances => true;

		bool CandyToolTip = false;

		private int glyph = 0;
		public int Glyph => glyph;
		private void SetGlyph(int g, bool value)
		{
			if (value)
				glyph = g;
			else if (glyph == g)
				glyph = 0;
		}
		public bool FrostGlyph
		{
			get { return glyph == 1; }
			set { SetGlyph(1, value); }
		}
		public bool PoisonGlyph
		{
			get { return glyph == 2; }
			set { SetGlyph(2, value); }
		}
		public bool BloodGlyph
		{
			get { return glyph == 3; }
			set { SetGlyph(3, value); }
		}
		public bool FlareGlyph
		{
			get { return glyph == 4; }
			set { SetGlyph(4, value); }
		}
		public bool BeeGlyph
		{
			get { return glyph == 5; }
			set { SetGlyph(5, value); }
		}
		public bool PhaseGlyph
		{
			get { return glyph == 6; }
			set { SetGlyph(6, value); }
		}
		public bool DazeGlyph
		{
			get { return glyph == 7; }
			set { SetGlyph(7, value); }
		}
		public bool CamoGlyph
		{
			get { return glyph == 8; }
			set { SetGlyph(8, value); }
		}
		public bool VoidGlyph
		{
			get { return glyph == 9; }
			set { SetGlyph(9, value); }
		}
		public bool HauntedGlyph
		{
			get { return glyph == 10; }
			set { SetGlyph(10, value); }
		}

		public override bool NeedsSaving(Item item)
		{
			return glyph != 0;
		}

		public override TagCompound Save(Item item)
		{
			TagCompound data = new TagCompound();
			data.Add("glyph", glyph);
			return data;
		}

		public override void Load(Item item, TagCompound data)
		{
			glyph = data.GetInt("glyph");
		}

		public override void NetSend(Item item, BinaryWriter writer)
		{
			writer.Write(glyph);
		}

		public override void NetReceive(Item item, BinaryReader reader)
		{
			glyph = reader.ReadInt32();
		}


		public override void OpenVanillaBag(string context, Player player, int arg)
		{
			if (context != "goodieBag")
				return;
			_ItemUtils.DropCandy(player);
			if (Main.rand.Next(3) == 0)
			{
				string[] lootTable = { "MaskSchmo", "MaskGraydee", "MaskLordCake", "MaskVladimier", "MaskKachow", "MaskHulk", "MaskBlaze", "MaskSvante", "MaskIggy", "MaskYuyutsu", "MaskLeemyy", };
				int loot = Main.rand.Next(lootTable.Length);
				player.QuickSpawnItem(mod.ItemType(lootTable[loot]));
			}
		}


		public override void UpdateInventory(Item item, Player player)
		{
			if (FlareGlyph)
			{
				item.shootSpeed = 25;
			}
		}

		public override void GetWeaponCrit(Item item, Player player, ref int crit)
		{
			if (FrostGlyph)
			{
				crit += 6;
			}
			else if (PoisonGlyph)
			{
				crit += 5;
			}
		}

		public override void HoldItem(Item item, Player player)
		{
			switch (glyph)
			{
				case 1:
					player.AddBuff(Buffs.Glyph.FrostGlyphBuff._type, 2);
					if (player.ownedProjectileCounts[mod.ProjectileType("FreezeProj")] <= 1)
						Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("FreezeProj"), 0, 0, player.whoAmI);
					break;
				case 2:
					player.AddBuff(Buffs.Glyph.PoisonGlyphBuff._type, 2);
					break;
				case 3:
					player.AddBuff(Buffs.Glyph.BloodGlyphBuff._type, 2);
					break;
				case 4:
					player.AddBuff(Buffs.Glyph.FlareGlyphBuff._type, 2);
					if (player.itemAnimation != 0)
						player.AddBuff(BuffID.OnFire, 6);
					break;
				case 5:
					player.AddBuff(Buffs.Glyph.BeeGlyphBuff._type, 2);
					break;
				case 6:
					player.AddBuff(Buffs.Glyph.PhaseGlyphBuff._type, 2);
					break;
				case 7:
					player.AddBuff(Buffs.Glyph.DazeGlyphBuff._type, 2);
					break;
				case 8:
					player.AddBuff(Buffs.Glyph.CamoGlyphBuff._type, 2);
					break;
				case 9:
					player.AddBuff(Buffs.Glyph.VoidGlyphBuff._type, 2);
					break;
			}
		}


		public override void ModifyHitNPC(Item item, Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
		{
			if (DazeGlyph)
				Glyphs.DazeGlyph.Daze(target, ref damage);
		}

		public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
		{
			switch (glyph)
			{
				case 2:
					if (crit)
						Glyphs.PoisonGlyph.ReleasePoisonClouds(target, player.whoAmI);
					break;
				case 3:
					Glyphs.BloodGlyph.BloodCorruption(player, target);
					break;
				case 4:
					Glyphs.ScorchGlyph.Scorch(target, crit);
					break;
				case 5:
					Glyphs.BeeGlyph.ReleaseBees(player, target, damage);
					break;
				case 9:
					Glyphs.VoidGlyph.VoidEffects(player, target, damage);
					break;
			}
		}

		public override void ModifyHitPvp(Item item, Player player, Player target, ref int damage, ref bool crit)
		{
			if (DazeGlyph)
				Glyphs.DazeGlyph.Daze(target, ref damage);
		}

		public override void OnHitPvp(Item item, Player player, Player target, int damage, bool crit)
		{
			switch (glyph)
			{
				case 2:
					if (crit)
						Glyphs.PoisonGlyph.ReleasePoisonClouds(target, player.whoAmI);
					break;
				case 3:
					Glyphs.BloodGlyph.BloodCorruption(player, target);
					break;
				case 4:
					Glyphs.ScorchGlyph.Scorch(target, crit);
					break;
				case 5:
					Glyphs.BeeGlyph.ReleaseBees(player, target, damage);
					break;
				case 9:
					Glyphs.VoidGlyph.VoidEffects(player, target, damage);
					break;
			}
		}


		public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (modPlayer.talonSet && (item.ranged || item.magic) && Main.rand.Next(10) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY + 2), ProjectileID.HarpyFeather, 10, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}
			if (modPlayer.titanicSet && item.melee && Main.rand.Next(6) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("WaterMass"), 40, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}
			if (modPlayer.fierySet && (item.ranged || item.thrown) && Main.rand.Next(8) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.Fireball, 16, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}
			if (modPlayer.cultistScarf && item.magic && Main.rand.Next(8) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("WildMagic"), 66, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}
			if (modPlayer.thermalSet && item.melee && Main.rand.Next(6) == 0)
			{
				for (int I = 0; I < 4; I++)
				{
					int proj = Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(300, 500) / 100), speedY * (Main.rand.Next(300, 500) / 100), 134, 65, 7f, player.whoAmI, 0f, 0f);
					Main.projectile[proj].friendly = true;
					Main.projectile[proj].hostile = false;
				}
			}
			if (modPlayer.timScroll && item.magic && Main.rand.Next(12) == 0)
			{
				int p = Main.rand.Next(9, 22);
				int proj = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, p, damage, knockBack, player.whoAmI, 0f, 0f);
				Main.projectile[proj].friendly = true;
				Main.projectile[proj].hostile = false;
			}
			if (modPlayer.crystal && item.ranged && Main.rand.Next(8) == 0)
			{
				int proj = Projectile.NewProjectile(position.X, position.Y, speedX * (float)(Main.rand.Next(100, 165) / 100), speedY * (float)(Main.rand.Next(100, 165) / 100), type, damage, knockBack, player.whoAmI, 0f, 0f);
				Main.projectile[proj].friendly = true;
				Main.projectile[proj].hostile = false;
			}

			if (modPlayer.KingSlayerFlask && item.thrown && Main.rand.Next(5) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("KingSlayerKnife"), 35, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}

			if (modPlayer.fireMaw && item.ranged && Main.rand.Next(10) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("FireMaw"), 30, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}

			if (modPlayer.drakinMount && item.magic && Main.rand.Next(4) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), 671, 41, 3f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}
			if (modPlayer.MoonSongBlossom && item.ranged && Main.rand.Next(8) == 0)
			{
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("BlossomArrow"), 29, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;

				int proj1 = Projectile.NewProjectile(position, new Vector2(speedX + 1, speedY), mod.ProjectileType("BlossomArrow"), 29, 2f, player.whoAmI);
				Main.projectile[proj1].hostile = false;
				Main.projectile[proj1].friendly = true;

				int proj2 = Projectile.NewProjectile(position, new Vector2(speedX, speedY - 1), mod.ProjectileType("BlossomArrow"), 29, 2f, player.whoAmI);
				Main.projectile[proj2].hostile = false;
				Main.projectile[proj2].friendly = true;
			}
			if (modPlayer.manaWings && item.magic && Main.rand.Next(7) == 0)
			{
				float d1 = 20 + ((player.statManaMax2 - player.statMana) / 3);
				int proj = Projectile.NewProjectile(position, new Vector2(speedX, speedY), mod.ProjectileType("ManaSpark"), (int)d1, 2f, player.whoAmI);
				Main.projectile[proj].hostile = false;
				Main.projectile[proj].friendly = true;
			}

			return true;
		}


		public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
		{
			string line = null;
			Color color = Color.White;
			switch (glyph)
			{
				case 1:
					line = "[Frostfreeze]\n"+
						"Increases critical strike chance by 6%\n"+
						"Enemies near you are slowed";
					color = new Color(80, 80, 200);
					break;
				case 2:
					line = "[Rotting Wounds]\n"+
						"Increases critical strike chance by 5%\n"+
						"Landing critical strikes on foes may release poisonous clouds";
					color = new Color(80, 200, 80);
					break;
				case 3:
					line = "[Sanguine Strike]\n"+
						"Attacks inflict Blood Corruption\n"+
						"Hitting enemies with Blood Corruption may steal life";
					color = new Color(200, 80, 80);
					break;
				case 4:
					line = "[Flare Frenzy]\n"+
						"The player is engulfed in flames\n"+
						"Greatly increases the velocity of projectiles\n"+
						"Attacks may inflict On Fire\n"+
						"Attacks may also deal extra damage";
					color = new Color(255, 153, 10);
					break;
				case 5:
					line = "[Wasp Call]\n"+
						"Reduces movement speed by 7%\n"+
						"Attacks may release multiple bees";
					color = new Color(158, 125, 10);
					break;
				case 6:
					line = "[Phase Flux]\n"+
						"20% increased movement speed\n"+
						"Grants immunity to knockback\n"+
						"Reduces defense by 5";
					color = new Color(255, 217, 30);
					break;
				case 7:
					line = "[Dazed Dance]\n"+
						"All attacks inflict confusion\n"+
						"Confused enemies take extra damage\n"+
						"Getting hurt may confuse the player";
					color = new Color(163, 22, 224);
					break;
				case 8:
					line = "[Concealment]\n"+
						"Being still puts you in stealth\n"+
						"Stealth increases damage by 15% and life regen by 3";
					color = new Color(22, 188, 127);
					break;
				case 9:
					line = "[Collapsing Void]\n"+
						"Grants you Collapsing Void, which reduces damage taken by 5%\n"+
						"Crits on foes may grant you up to two additional stacks of collapsing void, which reduces damage taken by up to 15%\n"+
						"Hitting foes when having more than one stack of Collapsing Void may generate Void Stars";
					color = new Color(120, 31, 209);
					break;
				case 10:
					line = "[Haunting]\n"+
						"Attacks cause fear inducing bats to sweep across the screen\n"+
						"You deal 8% additional damage to feared enemies";
					color = new Color(120, 170, 170);
					break;
			}
			if (line != null)
			{
				TooltipLine tip = new TooltipLine(mod, "Glyph", line);
				tip.overrideColor = color;
				tooltips.Add(tip);
			}
		}

		public override void PostReforge(Item item)
		{
			glyph = 0;
		}
	}
}
