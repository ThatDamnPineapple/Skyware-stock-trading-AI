using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
namespace SpiritMod.Items.Weapon.Gun
{
    public class SpiritGun : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Spirit Burst";
            item.damage = 44;
            item.toolTip = "Turns bullets into Soul Burning Spirit Bullets!";
            item.ranged = true;
            item.width = 60;
            item.height = 32;
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 1;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
            item.UseSound = SoundID.Item36;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("SpiritBullet");
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
 
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            type = mod.ProjectileType("SpiritBullet");
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
            recipe.AddIngredient(null, "SpiritBar", 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
    }
}