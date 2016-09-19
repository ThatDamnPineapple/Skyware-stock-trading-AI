using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class ZocklukasWings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Wings);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Zocklukas' Wings";
            item.width = 32;
            item.height = 32;
            item.toolTip = "Just for an true Coder.";
            item.value = 10;
            item.rare = 10;

            item.expert = true;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.name == "Zocklukas")
            {
                player.wingTimeMax = 100000;
                player.waterWalk = true;
                player.fireWalk = true;
                player.manaFlower = true;
                player.gravControl = true;
                player.accFlipper = true;
                player.noKnockback = true;   
            }
            else
            {
                player.statDefense -= 100;
                player.meleeDamage = -1;
                player.thrownDamage = -1;
                player.rangedDamage = -1;
                player.magicDamage = -1;
                player.minionDamage = -1;
                player.lifeRegen = -100;
                player.moveSpeed = 0.1f;
            }
        }

        public override void VerticalWingSpeeds(ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 2;
            maxAscentMultiplier = 3;
            constantAscend = 0.135f;

        }

        public override void HorizontalWingSpeeds(ref float speed, ref float acceleration)
        {
            speed = 50;
            acceleration *= 10;
        }        
    }
}