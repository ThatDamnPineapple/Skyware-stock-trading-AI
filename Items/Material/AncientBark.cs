using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class AncientBark : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ancient Bark";
            item.width = item.height = 16;
            item.toolTip = "'Thousands of years old'";
            item.maxStack = 999;
            item.value = 800;
            item.rare = 1;
        }
    }
}
