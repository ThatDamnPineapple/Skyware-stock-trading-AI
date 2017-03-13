using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class MarbleChunk : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ancient Marble Chunk";
            item.toolTip = "'Contains fragments of past civilizations'";
            item.width = 22;
            item.height = 36;
            item.maxStack = 999;
            item.rare = 2;
            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 15;

            item.autoReuse = true;
            item.consumable = true;

            item.createTile = mod.TileType("MarbleOre");
        }
    }
}