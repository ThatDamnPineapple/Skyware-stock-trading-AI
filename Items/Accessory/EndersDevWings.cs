using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class EndersDevWings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Wings);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "EnderShot's Wings";
            item.width = 47;
            item.height = 37;
            item.toolTip = "PuLsAtInG WoNdErS";
            item.value = 10;
            item.rare = 2;
            item.accessory = true;
            item.expert = true;
            item.rare = 10;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.name == "EnderShot355")
            {
                player.wingTimeMax = 1000000;
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
            speed = 30f;
            acceleration *= 5.0f;
        }        
    }
}