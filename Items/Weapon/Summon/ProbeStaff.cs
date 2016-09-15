using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Summon
{
    public class ProbeStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Enchanted Paladin's Hammer Staff";
            item.damage = 36;
            item.summon = true;
            item.mana = 17;
            item.width = 48;
            item.height = 48;
            item.toolTip = "Summons a Probe to fight for you!";
            item.useTime = 37;
            item.useAnimation = 26;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = Item.buyPrice(1, 10, 0, 0);
            item.rare = 7;
            item.useSound = 44;
            item.shoot = mod.ProjectileType("ProbeMinion");
            item.shootSpeed = 10f;
            item.buffType = mod.BuffType("ProbeBuff");
            item.buffTime = 3600;

        }
        
    }
}