using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using SpiritMod.Projectiles;

namespace SpiritMod.Items.Weapon.Bow
{
    public class CygnusCrossbow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Cygnus Crossbow";
            item.damage = 42;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.height = 38;
            item.toolTip = "Arrows inflict Star Fracture";
            item.useTime = 25;
            item.useAnimation = 25;
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
            item.shootSpeed = 11f;
            item.crit = 4;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			int projShot0 = Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI, 0f, 0f);
            Projectile projShot = Main.projectile[projShot0];
            projShot.GetModInfo<SpiritProjectileInfo>(mod).shotFromStellarCrosbow = true; 
            return false; 
        }
    }
}