using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class Goreligator : ModItem
    {
		private Vector2 newVect;
        public override void SetDefaults()
        {
            item.name = "Goreligator";  
            item.damage = 31;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 2;
            item.value = 100000;
            item.rare = 6;
            item.useSound = 36;
            item.autoReuse = true;
            item.shoot = 10; 
            item.shootSpeed = 9.5f;
            item.useAmmo = ProjectileID.Bullet;
        }
		
		             public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			Vector2 origVect = new Vector2(speedX, speedY);
			for (int X = 0; X <= 3; X++)
			{
				if (Main.rand.Next(2) == 1)
				{
					newVect = origVect.RotatedBy(System.Math.PI / (Main.rand.Next(87, 1800) / 10));
				}
				else
				{
					newVect = origVect.RotatedBy(-System.Math.PI / (Main.rand.Next(87, 1800) / 10));
				}
			int proj2 = Projectile.NewProjectile(position.X, position.Y, newVect.X, newVect.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
        }
		
		        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FleshClump", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}