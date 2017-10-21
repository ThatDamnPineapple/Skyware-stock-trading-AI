using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class HideGlyph : GlyphBase
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Camoflauge Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Concealment\nBeing still puts you in stealth\nStealth increases damage by 15% and life regen by 3");
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
			EnchantmentTarget(player).GetGlobalItem<GItem>(mod).CamoGlyph = true;
		}
	}
}