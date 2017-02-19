using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems
{
    public class DodgeBall : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Super Dodgeball: Mach Throw";
            item.damage = 32;
            item.thrown = true;
            item.width = 30;
            item.height = 30;
            item.toolTip = "Throw a very fast, mach speed dodgeball! \n ~Donator Item~";
            item.useTime = 30;
            item.useAnimation = 30;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 0;
            item.value = 35800;
            item.rare = 4;
            item.shootSpeed = 20f;
            item.shoot = mod.ProjectileType("Dodgeball");
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.AddIngredient(ItemID.SoulofLight, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(null, "DodgeBall1", 1);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}