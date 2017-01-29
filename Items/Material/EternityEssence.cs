using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class EternityEssence : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Essence of Eternity";
            item.width = 24;
            item.height = 28;
            item.toolTip = "'The breath of Spirit, forever.'"; 
            item.value = 8000;
            item.rare = 11;

            item.maxStack = 999;
        }
    }
}