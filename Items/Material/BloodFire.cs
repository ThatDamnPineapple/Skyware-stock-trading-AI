using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class BloodFire : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Bloodfire";
            item.toolTip = "'This mystical blood is warm to touch'";
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.width = 24;
            item.height = 28;
            item.value = 100;
            item.rare = 2;

            item.maxStack = 999;
        }
    }
}