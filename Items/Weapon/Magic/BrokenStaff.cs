using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class BrokenStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Broken Hero Staff";
            item.width = 54;
            item.height = 54;
            item.value = 40000;
            item.toolTip = "'A staff of ages past...'";
            item.rare = 7;

            item.maxStack = 99;
        }
    }
}