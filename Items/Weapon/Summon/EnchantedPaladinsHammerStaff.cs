using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Summon
{
    public class EnchantedPaladinsHammerStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Enchanted Paladin's Hammer Staff";
            item.damage = 55;
            item.summon = true;
            item.mana = 15;
            item.width = 36;
            item.height = 36;
            item.toolTip = "Summons an Enchanted Paladin's Hammer to fight for you!";
            item.useTime = 40;
            item.useAnimation = 26;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = Item.buyPrice(1, 50, 0, 0);
            item.rare = 8;
            item.useSound = 44;
            item.shoot = mod.ProjectileType("EnchantedPaladinsHammerMinion");
            item.shootSpeed = 10f;
            item.buffType = mod.BuffType("EnchantedPaladinsHammerBuff");
            item.buffTime = 3600;

        }
        
    }
}