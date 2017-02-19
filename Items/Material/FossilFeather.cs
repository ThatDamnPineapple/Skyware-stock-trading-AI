using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class FossilFeather : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Fossil Feather";
            item.width = 24;
            item.height = 24;
            item.toolTip = "Involved in the crafting of Talon tools and armor \n 'Suprisingly well preserved'";
            item.value = 100;
            item.rare = 3;

            item.maxStack = 999;
        }
    }
}
