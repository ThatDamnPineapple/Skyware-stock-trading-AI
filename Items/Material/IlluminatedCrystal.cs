using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class IlluminatedCrystal : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Illuminated Crystal";
            item.toolTip = "'The crystal is humming with arcane energy'\n Involved in the crafting of Illuminant Armor";
            item.width = 24;
            item.height = 28;
            item.value = 100;
            item.rare = 6;

            item.maxStack = 999;
        }
    }
}