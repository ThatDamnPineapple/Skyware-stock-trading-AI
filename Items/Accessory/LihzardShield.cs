using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class LihzardShield : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Shield);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Lihzahrd Shield";
            item.width = 28;
            item.height = 32;
            item.toolTip = "Greatly reduces damage taken when standing still.";
            item.value = Item.buyPrice(0, 14, 0, 0);
            item.rare = 7;

            item.accessory = true;

            item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Math.Abs(player.velocity.Y) < 0.05 && Math.Abs(player.velocity.Y) < 0.05)
            {
                player.endurance += .30f;
            }
        }
    }
}
