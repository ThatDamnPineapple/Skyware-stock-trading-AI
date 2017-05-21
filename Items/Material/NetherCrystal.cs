using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class NetherCrystal : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Nether Crystal";
            item.width = 22;
            item.height = 22;
            item.toolTip = "'Brimming with bright souls'";
            item.rare = 5;

            item.maxStack = 999;
        }
    }
}
