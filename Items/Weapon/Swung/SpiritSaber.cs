using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
	public class SpiritSaber : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spirit Saber";
			item.width = 36;
			item.height = 38;
			item.toolTip = "";
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 3;
			item.crit += 4;
			item.damage = 50;
			item.knockBack = 5f;
			item.useStyle = 1;
			item.useTime = 26;
			item.useAnimation = 26;
			item.melee = true;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "SpiritBar", 12);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
