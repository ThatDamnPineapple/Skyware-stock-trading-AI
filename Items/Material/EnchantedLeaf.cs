using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class EnchantedLeaf : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Enchanted Leaf";
            item.width = item.height = 16;
            item.toolTip = "'Blessed with the magic of druids'";
            item.maxStack = 999;
            item.value = 500;
            item.rare = 1;
        }
    }
}
