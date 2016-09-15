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
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
            item.rare = 10;
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
                player.statDefense = 0;
                player.meleeDamage = 0.0f;
                player.thrownDamage = 0.0f;
                player.rangedDamage = 0.0f;
                player.magicDamage = 0.0f;
                player.minionDamage = 0.0f;
                player.lifeRegen = -100;
                player.moveSpeed = 0.10f;
            }
        }

        public override void VerticalWingSpeeds(ref float ascentWhenFalling, ref float ascentWhenRising,
            ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            ascentWhenFalling = 0.85f;
            ascentWhenRising = 0.15f;
            maxCanAscendMultiplier = 2f;
            maxAscentMultiplier = 3f;
            constantAscend = 0.135f;

        }

        public override void HorizontalWingSpeeds(ref float speed, ref float acceleration)
        {
            speed = 50.0f;
            acceleration *= 10.0f;
        }        
    }
}