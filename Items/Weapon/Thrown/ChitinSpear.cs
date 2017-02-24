using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Thrown
{
    public class ChitinSpear : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Chitin Spear";
            item.width = 10;
            item.height = 42;
            item.rare = 1;
            item.maxStack = 999;
            item.damage = 11;
            item.value = Terraria.Item.sellPrice(0, 0, 5, 0);
            item.knockBack = 5;
            item.useStyle = 1;
            item.useTime = item.useAnimation = 45;
            item.thrown = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.consumable = true;
            item.noUseGraphic = true;
            item.shoot = mod.ProjectileType("ChitinSpearProj");
            item.shootSpeed = 12;
            item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Chitin", 2);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}