using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
	public class PutridPick : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Putrid Pick";
			item.width = 36;
			item.height = 38;
			item.value = Item.sellPrice(0, 4, 0, 0);
			item.rare = 5;

            item.pick = 150;

            item.damage = 32;
			item.knockBack = 4f;

			item.useStyle = 1;
			item.useTime = 11;
			item.useAnimation = 30;

			item.melee = true;
			item.autoReuse = true;

			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "PutridPiece", 5);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this);
			modRecipe.AddRecipe();
		}
	}
}
