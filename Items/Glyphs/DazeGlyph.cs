using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class DazeGlyph : GlyphBase
	{
		public static int _type;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Daze Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Dazed Dance\nAll attacks inflict confusion\nConfused enemies take extra damage\nGetting hurt may confuse the player");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 5;

			item.maxStack = 999;
		}

		public override void RightClick(Player player)
		{
			EnchantmentTarget(player).GetGlobalItem<GItem>(mod).DazeGlyph = true;
		}


		public static void Daze(NPC target, ref int damage)
		{
			if (target.FindBuffIndex(BuffID.Confused) > -1)
			{
				Main.NewText("Daze");
				damage += 30;
			}

			if (Main.rand.Next(9) == 1)
				target.AddBuff(BuffID.Confused, 240);
		}

		public static void Daze(Player target, ref int damage)
		{
			if (target.FindBuffIndex(BuffID.Confused) > -1)
				damage += 30;

			if (Main.rand.Next(9) == 1)
				target.AddBuff(BuffID.Confused, 240, false);
		}
	}
}