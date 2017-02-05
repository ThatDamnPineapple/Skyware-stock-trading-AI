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
            item.toolTip = "Involved in the crafting of Infernal Gear";
            item.width = item.height = 16;
            item.maxStack = 999;
            item.rare = 4;
        }
    }
}
