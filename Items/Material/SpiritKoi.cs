using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class SpiritKoi : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Spirit Koi";
            item.toolTip = "'Is it past its expiry date?'";
            item.width = 38;
            item.height = 42;
            item.value = 100;
            item.rare = 4;

            item.maxStack = 999;
        }
    }
} 
