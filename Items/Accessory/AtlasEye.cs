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
            item.toolTip = "Under 25% health, movement speed is reduced by 35%, but defense is increased by 14.";
            item.rare = 7;
			item.expert = true;
            item.defense = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife < player.statLifeMax2 / 4)
			{
                player.moveSpeed *= 0.65f;
                player.statDefense += 14;
            }
        }
    }
}
