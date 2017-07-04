using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class SpiritBar : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Bar");
		}


        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 24;
            item.value = 100;
            item.rare = 4;
            item.rare = 5;
            item.maxStack = 999;
			item.createTile = mod.TileType("SpiritBar");
        }
        public override void AddRecipes() 
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritOre", 4);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}