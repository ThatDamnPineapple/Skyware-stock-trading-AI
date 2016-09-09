using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Spear {
public class PestilentPike : ModItem
{
    public override void SetDefaults()
    {
        item.name = "Pestilent Pike";
        item.useStyle = 5;
        item.width = 24;
        item.height = 24;
        item.noUseGraphic = true;
        item.useSound = 1;
        item.melee = true;
        item.noMelee = true;
        item.useAnimation = 27;
        item.useTime = 27;
        item.shootSpeed = 9f;
        item.knockBack = 6f;
        item.damage = 77;
        item.value = Item.sellPrice(0, 1, 30, 0);
        item.rare = 3;
        item.shoot = mod.ProjectileType("PestilentPikeProj");
    }
    
    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
}}
