using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class DazeGlyph : GlyphBase
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Daze Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Dazed Dance\nAll attacks inflict confusion\nConfused enemies take extra damage\nGetting hurt may confuse the player");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
			item.rare = 5;

			item.maxStack = 999;
		}

		public override void RightClick(Player player)
		{
			EnchantmentTarget(player).GetGlobalItem<GItem>(mod).DazeGlyph = true;
		}
	}
}