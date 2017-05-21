using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class DepthShard : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Depth Shard";
            item.toolTip = "'Metal unearthed from the Depths of the ocean'";
            item.width = 24;
            item.height = 28;
            item.value = 100;
            item.rare = 5;

            item.maxStack = 999;
        }
    }
}