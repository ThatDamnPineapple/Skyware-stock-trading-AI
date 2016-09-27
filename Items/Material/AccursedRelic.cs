using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class AccursedRelic : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Accursed Relic";
            item.width = 24;
            item.height = 28;
            item.value = 100;
            item.rare = 4;
			 item.toolTip = "'Fragments from the past'";
            item.maxStack = 999;
        }
    }
}