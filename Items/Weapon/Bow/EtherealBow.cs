using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class EtherealBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Ethereal Bow";
            item.damage = 43;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.height = 38;
            item.toolTip = "Transforms arrows in to Ethereal Arrows";
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 1;
            item.knockBack = 6;
            item.value = 1000;
            item.rare = 5;
            item.useSound = 5;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.autoReuse = false;
            item.shootSpeed = 8f;
            item.crit = 4;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("EtherealArrow"), damage, knockBack, player.whoAmI, 0f, 0f); 
            return false; 
        }
    }
}