using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class PoisonGlyph : GlyphBase
	{
		public static int _type;
		public static Microsoft.Xna.Framework.Graphics.Texture2D[] _textures;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unholy Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Rotting Wounds\nIncreases critical strike chance by 5%\nCritical hits on foes may leave behind lingering clouds of poisonous rot\nThese clouds deal more damage in hardmode");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 2;

			item.maxStack = 999;
		}

		public override void RightClick(Player player)
		{
			Item item = EnchantmentTarget(player);
			item.GetGlobalItem<GItem>(mod).SetGlyph(item, GlyphType.Poison);
		}


		public static void ReleasePoisonClouds(Entity target, int owner)
		{
			if (owner != Main.myPlayer)
				return;
			int max = Main.hardMode ? 7 : 5;
			for (int i = 0; i < max; i++)
			{
				Vector2 vel = Vector2.UnitY.RotatedByRandom(Math.PI * 2);
				vel *= Main.rand.Next(8, 40) * .125f;
				Projectile.NewProjectile(target.Center, vel, Projectiles.PoisonCloud._type, Main.hardMode ? 35 : 20, 0, owner);
			}
		}
	}
}