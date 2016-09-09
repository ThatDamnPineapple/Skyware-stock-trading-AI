using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class InfernalAppendage : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Infernal Appendage";
            item.width = item.height = 16;
            item.toolTip = "???";
            item.rare = 4;
            item.maxStack = 999;
        }
    }
}
