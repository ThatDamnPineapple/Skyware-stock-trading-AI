using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class DuskPendant : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Dusk Pendant";
            item.width = 24;
            item.toolTip = "Increases magic and ranged damage by 13% at night time";
            item.height = 28;
            item.rare = 4;
            item.value = 80000;
            item.expert = true;
            item.melee = true;
            item.accessory = true;

            item.knockBack = 9f;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!Main.dayTime)
            {
                player.rangedCrit += 13;
                player.magicCrit += 13;
            }
        }
    }
}
