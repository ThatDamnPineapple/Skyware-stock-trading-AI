using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class Acid : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Corrosive Acid";
            item.width = 42;
            item.height = 24;
            item.toolTip = "'Extremely potent'";
            item.value = 100;
            item.rare = 5;

            item.maxStack = 999;
        }
    }
}
