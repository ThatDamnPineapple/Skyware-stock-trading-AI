using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems.Folv
{
    public class Enchantment : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Forgotten Enchantment";
            item.width = 28;
            item.height = 30;
            item.maxStack = 999;
            item.toolTip = "Runic inscription for a particular sword.";
            item.rare = 6;
        }
    }
}
