using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class HeartofMoon : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Heart of the Moon";
            item.width = 30;
            item.height = 28;
            AddTooltip("Increases damage dealt by 11%");
            AddTooltip("Getting hurt spawns six Moon Globules around the player");
            AddTooltip("Attacks have a chance to grant the player the 'Will of the Celestials,' increasing life regeneration and reducing damage taken");
            item.rare = 10;
            item.value = Item.buyPrice(1, 0, 0, 0);

            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.magicDamage += 0.11f;
            player.thrownDamage += 0.11f;
            player.minionDamage += 0.11f;
            player.rangedDamage += 0.11f;
            player.meleeDamage += 0.11f;
            player.GetModPlayer<MyPlayer>(mod).moonHeart = true;
        }
    }
}
