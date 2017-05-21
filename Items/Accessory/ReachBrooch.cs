using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class ReachBrooch : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Forsworn Pendant";
            item.width = 24;
            item.height = 24;
            item.toolTip = "Increases ranged critical strike chance by 2% and melee speed by 3%";
            item.value = Item.buyPrice(0, 0, 2, 0);
            item.rare = 2;

            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeSpeed += 0.03f;
            player.rangedCrit += 2;
        }
    }
}
