using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Furniture
{
	public class SpiritChairItem : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spirit Wood Chair";
            item.width = 64;
			item.height = 34;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("SpiritChair");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"SpiritWoodItem", 4);
			recipe.AddIngredient(225, 5);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
}