using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class ZocklukasRing : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Zocklukas' Ring";
            item.width = 28;
            item.height = 20;
            item.toolTip = "Just for an True Coder";
            item.value = 10;
            item.rare = 10;

            item.expert = true;
            item.accessory = true;
        }        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.name == "Zocklukas")
            {
                player.moveSpeed += 2.0f;
                player.meleeDamage += 3.00f;
                player.thrownDamage += 3.00f;
                player.rangedDamage += 3.00f;
                player.magicDamage += 3.00f;
                player.minionDamage += 3.00f;
                player.lifeRegen = +10;
                player.statDefense += +90;
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
                player.moveSpeed = 0.10f;
            }
        }
    }
}