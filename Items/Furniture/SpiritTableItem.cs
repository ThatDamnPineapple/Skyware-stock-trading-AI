using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Furniture
{
	public class SpiritTableItem : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spirit Table";
            item.width = 44;
			item.height = 25;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 150;
			item.createTile = mod.TileType("SpiritTable");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null,"SpiritWoodItem", 10);
            recipe.SetResult(this);
			recipe.AddRecipe();            
        }
	}
}