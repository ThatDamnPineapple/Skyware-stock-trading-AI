using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class ReapersHarvest : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Reapers Harvest";     
            item.damage = 65;            
            item.melee = true;            
            item.width = 58;              
            item.height = 58;             
            item.toolTip = "Shoots a returning scythe";  
            item.useTime = 23;           
            item.useAnimation = 23;     
            item.useStyle = 1;        
            item.knockBack = 8;      
            item.value = 4000;        
            item.rare = 8;
            item.UseSound = SoundID.Item1;        
            item.autoReuse = true;
            item.crit = 0;
            item.shoot = mod.ProjectileType("ReapersHarvestProjectile");
            item.shootSpeed = 8f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"CursedFire", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}