using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class BismiteBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Bismite Bow";
            item.damage = 12;
            item.noMelee = true;
            item.ranged = true;
            item.width = 26;
            item.height = 62;
            item.toolTip = "Shoots 2 Arrows on one use";
            item.useTime = 13;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 1;
            item.knockBack = 3;
            item.value = 1000;
            item.rare = 1;
            item.useSound = 5;           
            item.autoReuse = false;
            item.shootSpeed = 6.5f;
            item.crit = 8;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BismiteCrystal", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}