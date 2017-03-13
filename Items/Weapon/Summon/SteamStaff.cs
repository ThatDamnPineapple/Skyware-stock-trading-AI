using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Summon
{
    public class SteamStaff : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Starplate Staff";
            item.damage = 23;
            item.summon = true;
            item.mana = 11;
            item.width = 58;
            item.height = 58;
            item.toolTip = "Summons a Starplate Spider to fight for you!";
            item.useTime = 37;
            item.useAnimation = 37;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 3;
            item.UseSound = SoundID.Item44;
            item.shoot = mod.ProjectileType("SteamMinion");
            item.shootSpeed = 10f;
            item.buffType = mod.BuffType("SteamMinionBuff");
            item.buffTime = 3600;

        }
    }
}