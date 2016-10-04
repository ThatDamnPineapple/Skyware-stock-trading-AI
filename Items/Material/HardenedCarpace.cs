using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class HardenedCarpace : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Hardened Carpace";
            item.width = item.height = 16;
            item.toolTip = "???";
            item.maxStack = 999;
            item.rare = 1;
        }
    }
}
