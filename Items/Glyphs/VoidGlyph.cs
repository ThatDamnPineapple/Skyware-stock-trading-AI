using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class VoidGlyph : GlyphBase
	{
		public static int _type;
		public static Microsoft.Xna.Framework.Graphics.Texture2D[] _textures;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Collapsing Void\nWielding the weapon grants you Collapsing Void, which reduces damage taken by 5%\nLanding a critical hit on foes may grant you up to two additional stacks of collapsing void, which reduces damage taken by up to 15%\nHitting foes when having more than one stack of Collapsing Void may generate Void Stars");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 7;

			item.maxStack = 999;
		}

		public override void RightClick(Player player)
		{
			Item item = EnchantmentTarget(player);
			item.GetGlobalItem<GItem>(mod).SetGlyph(item, GlyphType.Void);
		}


		public static void VoidEffects(Player player, Entity target, int damage)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			if (player.whoAmI == Main.myPlayer && modPlayer.voidStacks > 1 && Main.rand.Next(14) == 0)
			{
				Vector2 vel = Vector2.UnitY.RotatedByRandom(Math.PI * 2);
				vel *= (float)Main.rand.NextDouble() * 3f;
				Projectile.NewProjectile(target.Center, vel, Projectiles.VoidStar._type, damage >> 1, 0, Main.myPlayer);
			}

			if (Main.rand.Next(10) == 1)
				player.AddBuff(Buffs.Glyph.VoidGlyphBuff._type, 299);
		}
	}
}