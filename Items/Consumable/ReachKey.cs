using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class ReachKey : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Mossy Key";
            item.width = 20;
            item.height = 20;
            item.maxStack = 999;
            AddTooltip("");
            item.value = 100000;
            item.rare = 3;
        }
    }
}
