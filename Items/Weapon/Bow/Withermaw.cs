using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using SpiritMod.Projectiles;

namespace SpiritMod.Items.Weapon.Bow
{
    public class Withermaw : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Withermaw";
            item.damage = 39;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.height = 38;
            item.useTime = 12;
            item.useAnimation = 12;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 1;
            item.knockBack = 5;
            item.value = 1000;
            item.rare = 5;
            item.useSound = 5;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.autoReuse = false;
            item.shootSpeed = 10f;
            item.crit = 7;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (Main.rand.Next(6) == 2)
			Projectile.NewProjectile(position.X, position.Y, speedX * 2f, speedY * 2f, mod.ProjectileType("BloodTear"), damage * (50 / 38), knockBack, player.whoAmI, 0f, 0f);
            return true; 
        }
    }
}