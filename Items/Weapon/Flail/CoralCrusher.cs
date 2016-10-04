using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Flail
{
    public class CoralCrusher : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Coral Crusher";
            item.width = 40;
            item.height = 40;
            item.rare = 1;
            item.noMelee = true; 
            item.useStyle = 5; 
            item.useAnimation = 34; 
            item.useTime = 34;
            item.knockBack = 7;
            item.damage = 15;
            item.noUseGraphic = true; 
            item.shoot = mod.ProjectileType("CoralCrusherProj");
            item.shootSpeed = 10f;
            item.useSound = 1;
            item.melee = true; 
            item.channel = true; 
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 6);
            recipe.AddIngredient(ItemID.Seashell, 1);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}