using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

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
            item.toolTip = "Increases Life Regen when standing still.";
            item.width = 28;
            item.height = 32;
            item.value = Item.buyPrice(0, 10, 0, 0);
            item.rare = 7;
            item.accessory = true;
            item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Math.Abs(player.velocity.Y) < 0.05 && Math.Abs(player.velocity.Y) < 0.05)
            {
                player.lifeRegen *= 2;
            }
        }
    }
}
