using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
	public class GorePickaxe : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Gore Pick";
			item.width = 36;
			item.height = 38;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = 5;

            item.pick = 150;

            item.damage = 32;
			item.knockBack = 4f;

			item.useStyle = 1;
			item.useTime = 7;
			item.useAnimation = 16;

			item.melee = true;
			item.autoReuse = true;

			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "FleshClump", 5);
			modRecipe.AddTile(TileID.MythrilAnvil);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
