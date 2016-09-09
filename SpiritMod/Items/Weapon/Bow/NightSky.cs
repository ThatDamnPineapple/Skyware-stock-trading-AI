using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class NightSky : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Night Sky";
            item.damage = 37;
            item.noMelee = true;
            item.ranged = true;
            item.width = 24;
            item.height = 46;
            item.toolTip = "Converts Arrows to Stars!";
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 1;
            item.knockBack = 4;
            item.value = 1000;
            item.rare = 3;
            item.useSound = 1;
            item.autoReuse = true;
            item.shootSpeed = 10.8f;
            item.crit = 6;
        }
            public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ProjectileID.FallingStar, damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }    
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StarlightBow", 1);
            recipe.AddIngredient(null, "BloomBuster", 1);
            recipe.AddIngredient(null, "Longbowne", 1);
            recipe.AddIngredient(ItemID.HellwingBow, 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}