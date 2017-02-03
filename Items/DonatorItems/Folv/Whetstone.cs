using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems.Folv
{
    public class Whetstone : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Magic Whetstone";
            item.width = item.height = 16;
            item.maxStack = 999;
            item.toolTip = "A crystal that pulses with energy.";
            item.rare = 4;
        }
    }
}
