using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class QuicksilverBow : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quicksilver Bow");
			Tooltip.SetDefault("Shoots two Quicksilver Arrows that release multiple bouncing quicksilver globs on hitting foes");
		}



        public override void SetDefaults()
        {
            item.damage = 47;
            item.noMelee = true;
            item.ranged = true;
            item.width = 44;
            item.height = 62;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 3;
            item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 14.8f;
        }
            public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("QuicksilverArrow"), damage, knockBack, player.whoAmI, 0f, 0f);
            Terraria.Projectile.NewProjectile(position.X, position.Y - 20, speedX, speedY, mod.ProjectileType("QuicksilverArrow"), damage, knockBack, player.whoAmI, 0f, 0f);
            Terraria.Projectile.NewProjectile(position.X, position.Y - 20, speedX, speedY, mod.ProjectileType("QuicksilverArrow"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Material", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
