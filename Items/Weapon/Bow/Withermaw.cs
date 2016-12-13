using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using SpiritMod.Projectiles;

namespace SpiritMod.Items.Weapon.Bow
{
    public class Withermaw : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Withermaw";
            item.damage = 39;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.height = 38;
            item.useTime = 16;
            item.useAnimation = 16;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 1;
            item.knockBack = 5;
            item.value = 10000;
            item.rare = 8;
            item.useSound = 5;
            item.autoReuse = true;
            item.shootSpeed = 13f;
            item.crit = 7;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			if (Main.rand.Next(6) == 2)
			Projectile.NewProjectile(position.X, position.Y, speedX * 2f, speedY * 2f, mod.ProjectileType("BloodTear"), damage * (50 / 38), knockBack, player.whoAmI, 0f, 0f);
            return true; 
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NightmareFuel", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}