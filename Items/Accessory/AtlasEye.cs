using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class AtlasEye : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Atlas Eye";
            item.width = 30;
            item.height = 28;
            item.toolTip = "Under 25% health, movement speed is reduced by 20%, but defense is increased by 14. \n Reduces damage taken by 7%";
            item.rare = 7;
			item.expert = true;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.defense = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife < player.statLifeMax2 / 4)
			{
                player.moveSpeed *= 0.20f;
                player.statDefense += 14;
                player.endurance += 0.07f;
            }
        }
    }
}
