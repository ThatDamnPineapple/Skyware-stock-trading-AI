using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class CarvedRock : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Infernal Rock";
            item.toolTip = "'A rock hewn with magma'";
            item.width = 16;
            item.height = 14;
            item.value = 800;
            item.rare = 3;

            item.maxStack = 999;
        }
    }
}