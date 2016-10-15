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
            item.shoot = mod.ProjectileType("SwordRuneProjectile");
            item.shootSpeed = 4f;
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
