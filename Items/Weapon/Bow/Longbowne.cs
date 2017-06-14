using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class Longbowne : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Longbowne");
			Tooltip.SetDefault("Fires arrows at a high velocity");
		}



        public override void SetDefaults()
        {
            item.damage = 22;
            item.noMelee = true;
            item.ranged = true;
            item.width = 22;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 2;
            item.value = 1000;
            item.rare = 3;
            item.UseSound = SoundID.Item5;
            item.shootSpeed = 19f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 40);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(ItemID.Bone, 40);
            recipe2.AddIngredient(ItemID.PlatinumBar, 5);
            recipe2.AddTile(TileID.Anvils);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}