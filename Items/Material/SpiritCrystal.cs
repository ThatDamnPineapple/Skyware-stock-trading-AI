using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class SpiritCrystal : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Spirit Crystal";
            item.toolTip = "'Filled with ancient magic'";
            item.width = 42;
            item.height = 24;
            item.value = 100;
            item.rare = 5;

            item.maxStack = 999;
        }
    }
}
