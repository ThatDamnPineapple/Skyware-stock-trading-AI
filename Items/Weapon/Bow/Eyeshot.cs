using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class Eyeshot : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Eyeshot";
            item.damage = 14;
            item.noMelee = true;
            item.ranged = true;
            item.width = 50;
            item.height = 30;
            item.useTime = 18;
            item.toolTip = "Arrows turn into Eyeballs!";
            item.useAnimation = 18;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 1;
            item.knockBack = 4;
            item.value = 30000;
            item.rare = 2;
            item.useSound = 5;
            item.autoReuse = true;
            item.shootSpeed = 6f;
        }
            public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("EyeArrow"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false;

        }
    }
}
