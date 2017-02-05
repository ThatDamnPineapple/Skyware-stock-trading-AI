using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon
{
    public class SpazLung : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Spaz Lung";
            item.damage = 56;
            item.noMelee = true;
            item.ranged = true;
            item.width = 58;
            item.height = 20;
            item.useTime = 14;
            item.toolTip = "Turns Gel into Green Fire!";
            item.useAnimation = 14;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 23;
            item.knockBack = 3;
            item.value = 8000;
            item.rare = 5;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shootSpeed = 7f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int projectileFired = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.EyeFire, item.damage, item.knockBack, item.owner);
            Main.projectile[projectileFired].friendly = true;
            Main.projectile[projectileFired].hostile = false;
            return false;
        }
              public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BlueprintTwins", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 6);
            recipe.AddIngredient(ItemID.SoulofSight, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
