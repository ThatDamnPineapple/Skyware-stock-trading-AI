using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class Kunai_Throwing : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Kunai";
            item.useStyle = 1;
            item.width = 9;
            item.height = 15;
            item.noUseGraphic = true;
            item.useSound = 1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.consumable = true;
            item.maxStack = 999;
            item.shoot = mod.ProjectileType("Kunai_Throwing");
            item.useAnimation = 20;
            item.useTime = 20;
            item.shootSpeed = 8.5f;
            item.damage = 12;
            item.knockBack = 3.5f;
			item.value = Terraria.Item.sellPrice(0, 0, 1, 0);
            item.crit = 20;
            item.rare = 4;
            item.autoReuse = true;
            //item.maxStack = 999;
            //item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 1);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddTile(16);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
	    recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 1);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddTile(16);
            recipe.SetResult(this, 30);
            recipe.AddRecipe();
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            float SdirX = (Main.MouseWorld.X - player.position.X) * 8.5f;
            float SdirY = (Main.MouseWorld.Y - player.position.Y) * 8.5f;
            float angle = (float)Math.Atan(25f);
			Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Kunai_Throwing"), damage, knockBack, player.whoAmI, 0f, 0f);
			Terraria.Projectile.NewProjectile(position.X, position.Y, speedX - 1, speedY - angle, mod.ProjectileType("Kunai_Throwing"), damage, knockBack, player.whoAmI, 0f, 0f);
			Terraria.Projectile.NewProjectile(position.X, position.Y, speedX + 1, speedY + angle, mod.ProjectileType("Kunai_Throwing"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
    }
}
