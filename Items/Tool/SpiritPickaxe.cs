using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
	public class SpiritPickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spirit Pickaxe";
			item.width = 36;
			item.height = 38;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 3;

            item.pick = 185;

            item.damage = 25;
			item.knockBack = 4f;

			item.useStyle = 1;
			item.useTime = 24;
			item.useAnimation = 24;

			item.melee = true;
			item.autoReuse = true;

			item.useSound = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "SpiritBar", 18);
			modRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
