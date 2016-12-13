using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class Retinranger : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Retinranger";
            item.damage = 44;
            item.noMelee = true;
            item.ranged = true;
            item.width = 50;
            item.height = 42;
            item.useTime = 18;
            item.toolTip = "Turns Arrows into Lasers!";
            item.useAnimation = 14;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 3;
            item.value = 80000;
            item.rare = 5;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 8.8f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int projectileFired = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.DeathLaser, item.damage, item.knockBack, item.owner);
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
