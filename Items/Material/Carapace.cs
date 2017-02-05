using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class Carapace : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Hardened Carapace";
            item.toolTip = "'Fossilized shells'";
            item.width = 24;
            item.height = 28;
            item.value = 100;
            item.rare = 1;

            item.maxStack = 999;
        }
    }
}