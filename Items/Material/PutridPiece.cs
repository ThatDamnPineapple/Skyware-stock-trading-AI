using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class PutridPiece : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Putrid Piece";
            item.width = 38;
            item.height = 42;
            item.maxStack = 999;
            item.value = 100;
            item.rare = 4;
        }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1508, 1);
            recipe.AddIngredient(521, 1);
            recipe.AddIngredient(522, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
} 
