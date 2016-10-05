using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class FleshClump : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "FleshClump";
            item.width = 38;
            item.height = 42;
            item.value = 100;
            item.rare = 4;

            item.maxStack = 999;
        }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight);
            recipe.AddIngredient(ItemID.Ichor);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
} 
