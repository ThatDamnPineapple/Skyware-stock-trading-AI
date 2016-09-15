using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Furniture
{
	public class SpiritChest : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spirit Chest";
			item.width = 32;
			item.height = 28;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 500;
			item.createTile = mod.TileType("SpiritChest");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 2);
			recipe.AddIngredient(null, "SpiritWoodItem", 10);
            recipe.AddIngredient(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}