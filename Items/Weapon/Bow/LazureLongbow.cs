using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class LazureLongbow : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Lazure Longbow";
            item.width = 26;
            item.height = 32;
            item.rare = 4;
            item.value = 1000;

            item.crit = 6;
            item.useAmmo = 1;
            item.damage = 41;
            item.knockBack = 5;

            item.useStyle = 5;
            item.useTime = 28;
            item.useAnimation = 28;

            item.ranged = true;
            item.noMelee = true;
            item.autoReuse = false;

            item.shoot = 3;
            item.shootSpeed = 5f;

            item.useSound = 5;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("GraniteArrow");
            return true;
        }
    }
}
