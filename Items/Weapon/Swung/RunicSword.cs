using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class RunicSword : ModItem
    {
		float downX;
			  float downY;
			   float upX;
			  float upY;
        public override void SetDefaults()
        {
            item.name = "Runic Sword";     
            item.damage = 44;            
            item.melee = true;            
            item.width = 42;              
            item.height = 50;             
            item.toolTip = "Shoots Runes on use";  
            item.useTime = 29;           
            item.useAnimation = 29;     
            item.useStyle = 1;        
            item.knockBack = 4;      
            item.value = 1000;        
            item.rare = 5;
            item.useSound = 1;       
            item.autoReuse = false;
			item.value = Item.buyPrice(0, 4, 0, 0);
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.useTurn = true;
            item.crit = 0;
            item.shoot = mod.ProjectileType("Rune");
            item.shootSpeed = 4f;
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
            float SdirX = (float)(Main.MouseWorld.X - player.position.X);
            float SdirY = (float)(Main.MouseWorld.Y - player.position.Y);
            float angleup = (float)Math.Atan(SdirX / SdirY) + 25;
			 float angledown = (float)Math.Atan(SdirX / SdirY) - 25;
			 if (SdirY < 0)
			 {
			 downX = (float)(0 - (Math.Sin(angledown) * 7.5));
			 downY = (float)(0 - (Math.Cos(angledown) * 7.5));
			   upX = (float)(0 - (Math.Sin(angleup) * 7.5));
			  upY = (float)(0 - (Math.Cos(angleup) * 7.5));
			 }
			 
			 if (SdirY > 0)
			 {
			  downX = (float)(Math.Sin(angledown) * 7.5);
			  downY = (float)(Math.Cos(angledown) * 7.5);
			  upX = (float)(Math.Sin(angleup) * 7.5);
			  upY = (float)(Math.Cos(angleup) * 7.5);
			 }
			Terraria.Projectile.NewProjectile(position.X, position.Y, downX, downY, type, damage, knockBack, player.whoAmI, 0f, 0f);
			Terraria.Projectile.NewProjectile(position.X, position.Y, upX, upY, type, damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"Rune", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
