using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class TechDrive : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Tech Drive";
            item.width = 42;
            item.height = 24;
            item.maxStack = 999;
            item.value = 100;
            item.toolTip = "It seems to overflow with energy.";
            item.rare = 3;
        }
    }
}
