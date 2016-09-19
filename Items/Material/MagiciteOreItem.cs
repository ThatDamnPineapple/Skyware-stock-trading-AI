using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class MagiciteOreItem : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Magicite Ore";
            item.width = 16; item.height = 14;
            item.value = 50;
            item.rare = 2;

            item.maxStack = 999;

            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;

            item.createTile = mod.TileType("MagiciteOre");
        }
    }
}
