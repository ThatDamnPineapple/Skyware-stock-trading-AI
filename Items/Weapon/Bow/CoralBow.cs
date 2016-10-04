using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class CoralBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Coral Bow";
            item.damage = 10;
            item.noMelee = true;
            item.ranged = true;
            item.width = 18;
            item.height = 46;
            item.useTime = 26;
            item.useAnimation = 26;
            item.useStyle = 5;
            item.shoot = 1;
            item.useAmmo = 1;
            item.knockBack = 3;
            item.value = 100;
            item.rare = 1;
            item.useSound = 5;
            item.autoReuse = false;
            item.useTurn = false;
            item.shootSpeed = 7.2f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 3);
            recipe.AddIngredient(ItemID.Seashell, 3);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}