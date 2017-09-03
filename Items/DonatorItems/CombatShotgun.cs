using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems
{
    public class CombatShotgun : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Combat Shotgun");
			Tooltip.SetDefault("Shoots a spread of bullets \n Right-click to shoot a grenade \n All grenades follow the trajectory of the last bullet, no matter where they're fired \n ~Donator Item~ \n 'Rip and Tear'");
		}


        private Vector2 newVect;
        public override void SetDefaults()
        {
            item.damage = 25;
            item.ranged = true;
            item.width = 65;
            item.height = 21;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4;
            item.value = 10780;
            item.rare = 5;
            item.UseSound = SoundID.Item36;
            item.autoReuse = false;
            item.shoot = 10;
            item.shootSpeed = 12f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {

                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.GrenadeI, (int)(damage * 1.25), knockBack, player.whoAmI);
                return false;
            }
            else
            {
                item.damage = 25;
                item.useTime = 30;
                item.useAnimation = 30;

                Vector2 origVect = new Vector2(speedX, speedY);
                for (int X = 0; X <= 3; X++)
                {
                    if (Main.rand.Next(2) == 1)
                    {
                        newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                    }
                    else
                    {
                        newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(82, 1800) / 10));
                    }
                    int proj2 = Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI);
                    Projectile newProj2 = Main.projectile[proj2];
                }
                return false;
            }
            return false;
        }
    }
}