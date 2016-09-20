using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
namespace SpiritMod.Items.Weapon.Gun
{
    public class HellRaiser : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Hell Raiser";
            item.damage = 60;
            item.ranged = true;
            item.width = 58;
            item.height = 32;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = 100000;
            item.rare = 6;
            item.useSound = 11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("HellBullet");
            item.shootSpeed = 6f;
            item.useAmmo = ProjectileID.Bullet;
            item.crit = 6;
        }
		 public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("HellBullet");
            return true;
        }
    }
}