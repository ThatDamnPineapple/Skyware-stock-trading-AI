using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems.Folv
{
    public class Hilt : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ancient Hilt";
            item.width = 28;
            item.height = 30;
            item.maxStack = 999;
            item.toolTip = "A hilt of aeons past.";
            item.rare = 8;
        }
    }
}
