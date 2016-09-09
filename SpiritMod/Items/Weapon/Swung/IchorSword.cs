using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class IchorSword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ichor Energy Sword";     
            item.damage = 52;            
            item.melee = true;            
            item.width = 40;              
            item.height = 40;             
            item.toolTip = "On use,it shots an Shuriken thats Inflict Ichor";  
            item.useTime = 22;           
            item.useAnimation = 22;     
            item.useStyle = 1;        
            item.knockBack = 6;      
            item.value = 10000;        
            item.rare = 4;
            item.useSound = 1;       
            item.autoReuse = true;   
            item.useTurn = true;
            item.shoot = mod.ProjectileType("IchorSword");
            item.shootSpeed = 8f;                                 
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ichor, 6);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 20);
            recipe.AddIngredient(ItemID.SoulofNight, 30);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}