using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class TalonBurst : ModItem
    {
		private int memes;
        public override void SetDefaults()
        {
            item.name = "Talon Burst";  
            item.damage = 23;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 12;
            item.useAnimation = 24;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 6;
            item.value = 100000;
            item.rare = 6;
            item.useSound = 36;
            item.autoReuse = false;
            item.shoot = 10; 
			item.crit = 8;
            item.shootSpeed = 5f;
            item.useAmmo = ProjectileID.Bullet;
        }
		
			  public override void AddRecipes()
        {
           ModRecipe recipe = new ModRecipe(mod);
                recipe.AddIngredient(null, "Talon", 12);
				recipe.AddTile(TileID.Anvils);
                recipe.SetResult(this, 1);
                recipe.AddRecipe();
        }
		
    }
}