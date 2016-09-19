using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class MartianCore : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Martian Power Core";
            item.width = 16;
            item.height = 24;
            item.toolTip = "Crackling to the brim with Otherworldy Energy.";
            item.rare = 7;

            item.maxStack = 999;
        }
    }
}
