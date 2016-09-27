using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class BubbleShield : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Bubble Shield";
            item.width = item.height = 16;

            item.defense = 3;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>(mod).bubbleShield = true;
        }
    }
}
