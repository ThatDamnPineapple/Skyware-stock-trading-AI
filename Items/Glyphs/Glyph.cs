using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Glyphs
{
    public class Glyph : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blank Glyph");
			Tooltip.SetDefault("'A surprisingly empty sigil'");
		}


        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 28;
            item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
            item.rare = -11;

            item.maxStack = 999;
        }
	}
}