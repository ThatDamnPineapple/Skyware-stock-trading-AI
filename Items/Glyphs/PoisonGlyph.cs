using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class PoisonGlyph : GlyphBase
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Unholy Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Rotting Wounds\nIncreases critical strike chance by 5%\nCritical hits on foes may leave behind lingering clouds of poisonous rot\nThese clouds deal more damage in hardmode");
		}


		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
			item.rare = 2;

			item.maxStack = 999;
		}

		public override void RightClick(Player player)
		{
			EnchantmentTarget(player).GetGlobalItem<GItem>(mod).PoisonGlyph = true;
		}
	}
}