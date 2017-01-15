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
            item.toolTip = "Under 25% health, makes you slow, but increaes defense";
            item.rare = 7;
			item.expert = true;
            item.defense = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.statLife < player.statLifeMax2 / 4)
			{
                player.moveSpeed *= 0.55f;
                player.statDefense += 12;
            }
        }
    }
}
