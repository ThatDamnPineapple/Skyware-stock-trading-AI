using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using SpiritMod.Projectiles;

namespace SpiritMod.Items.Weapon.Bow
{
    public class TatteredShotbow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Tattered Shotbow";
            item.damage = 39;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.height = 38;
            item.toolTip = "Shoots 2 arrows with high armor penetration";
            item.useTime = 15;
            item.useAnimation = 30;
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
            item.crit = 8;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("MarbleArrow"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false; 
        }
    }
}