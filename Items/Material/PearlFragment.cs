using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class PearlFragment : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Black Pearl Shard";
            item.toolTip = "'Resounding with the currents...'";
            item.width = 12;
            item.height = 12;
            item.value = 100;
            item.rare = 3;

            item.maxStack = 999;
        }
    }
}
