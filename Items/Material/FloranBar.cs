using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class FloranBar : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Floran Ingot";
            item.width = 30;
            item.height = 24;
            item.maxStack = 999;
            item.value = 4050;
            item.rare = 4;
        }
        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"FloranOre", 3);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}