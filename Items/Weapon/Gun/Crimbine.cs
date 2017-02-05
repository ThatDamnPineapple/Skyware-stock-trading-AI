using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
namespace SpiritMod.Items.Weapon.Gun
{
    public class Crimbine : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Crimbine";
            item.damage = 17;
            item.toolTip = "Turns bullets into lifestealing blood chunks!";
            item.ranged = true;
            item.width = 58;
            item.height = 32;
            item.useTime = 14;
            item.useAnimation = 14;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
            item.value = 1950;
            item.rare = 4;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("CrimBullet");
            item.shootSpeed = 26f;
            item.useAmmo = AmmoID.Bullet;
            item.crit = 6;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("CrimBullet");
            float spread = 15 * 0.0174f;//45 degrees converted to radians
            float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = Math.Atan2(speedX, speedY);
            double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
            speedX = baseSpeed * (float)Math.Sin(randomAngle);
            speedY = baseSpeed * (float)Math.Cos(randomAngle);
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Boomstick);
            recipe.AddIngredient(ItemID.TheUndertaker);
            recipe.AddIngredient(ItemID.PhoenixBlaster, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}