using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class RottingRifle : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Rotting Rifle";  
            item.damage = 28;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 4;
            item.useAnimation = 12;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 2;
            item.value = 10900;
            item.rare = 4;
            item.UseSound = SoundID.Item36;
            item.autoReuse = true;
            item.shoot = 10; 
            item.shootSpeed = 17f;
            item.useAmmo = AmmoID.Bullet;
			item.reuseDelay = 30;
        }
		
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("BlightedBullet"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false;

        }
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}