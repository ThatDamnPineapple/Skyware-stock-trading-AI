using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace SpiritMod.Items.Accessory
{
    public class MagnifyingGlass : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Magnifying Glass";
            item.toolTip = "Increases Critical Strike Chance by 5%.";
            item.width = 24;
            item.height = 24;
            item.value = Item.buyPrice(0, 0, 50, 0);
            item.rare = 1;
            item.accessory = true;
            item.defense = 0;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            {
                player.magicCrit += 5;
                player.meleeCrit += 5;
                player.thrownCrit += 5;
                player.rangedCrit += 5;
            }
        }
    }
}
