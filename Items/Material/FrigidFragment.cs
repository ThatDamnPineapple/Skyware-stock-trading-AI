using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class FrigidFragment : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Frigid Fragment";
            item.width = 24;
            item.height = 28;
            item.toolTip = "'Cold to the touch'";
            item.value = 100;
            item.rare = 1;

            item.maxStack = 999;            
        }
    }
}