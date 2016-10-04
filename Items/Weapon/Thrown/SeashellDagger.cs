using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
    public class SeashellDagger : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Seashell Dagger";
            item.useStyle = 1;
            item.width = 18;
            item.height = 28;
            item.noUseGraphic = true;
            item.useSound = 1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("SeashellDaggerProj");
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 14;
            item.useAnimation = 14;
            item.shootSpeed = 5.5f;
            item.damage = 14;
            item.knockBack = 2;
            item.value = 100;
            item.rare = 1;
            item.maxStack = 999;
            item.autoReuse = false;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 2);
            recipe.AddIngredient(ItemID.Seashell, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult("SeashellDagger",50);
            recipe.AddRecipe();
        }
    }
}
