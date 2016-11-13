using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class ScarabBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Scarab Bow";
            item.damage = 11;
            item.noMelee = true;
            item.ranged = true;
            item.width = 26;
            item.height = 62;
            item.toolTip = "Converts arrows into Scarab arrows";
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = 5;
            item.shoot = mod.ProjectileType("ScarabArrow");
            item.useAmmo = 1;
            item.knockBack = 3;
            item.value = 1000;
            item.rare = 2;
            item.useSound = 5;           
            item.autoReuse = true;
            item.shootSpeed = 6.5f;
            item.crit = 8;
        }
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
				Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("ScarabArrow"), damage, knockBack, player.whoAmI);
            return false;
        }
    }
}