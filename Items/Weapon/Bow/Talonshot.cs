using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using SpiritMod.Projectiles;

namespace SpiritMod.Items.Weapon.Bow
{
    public class Talonshot : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Talonshot";
            item.damage = 25;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.height = 38;
            item.toolTip = "Shoots 2 split arrows";
            item.useTime = 24;
            item.useAnimation = 24;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 1;
            item.knockBack = 3;
            item.value = 1000;
            item.rare = 5;
            item.useSound = 5;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.autoReuse = false;
            item.shootSpeed = 14f;
            item.crit = 8;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			
           Vector2 origVect = new Vector2(speedX, speedY);
					Vector2 newVect1 = origVect.RotatedBy(System.Math.PI / 17);
					Vector2 newVect2 = origVect.RotatedBy(-System.Math.PI / 17);
			int projShot0 = Terraria.Projectile.NewProjectile(position.X, position.Y, newVect2.X, newVect2.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
			Projectile.NewProjectile(position.X, position.Y, newVect1.X, newVect1.Y, type, damage, knockBack, player.whoAmI, 0f, 0f);
            return false; 
        }
    }
}