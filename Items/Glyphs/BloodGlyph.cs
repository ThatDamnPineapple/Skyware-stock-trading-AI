using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
	public class BloodGlyph : GlyphBase
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sanguine Glyph");
			Tooltip.SetDefault("The enchanted weapon gains: Sanguine Strike\nAttacks inflict Blood Corruption\nHitting foes struck with Blood Corruption may steal life");
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
			EnchantmentTarget(player).GetGlobalItem<GItem>(mod).BloodGlyph = true;
		}
	}
}