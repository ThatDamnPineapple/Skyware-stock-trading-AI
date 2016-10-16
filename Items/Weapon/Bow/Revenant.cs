using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
	public class Revenant : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Revenant";
			item.width = 12;
			item.height = 28;
			item.value = Item.sellPrice(0, 6, 0, 0);
			item.rare = 10;
			item.crit += 48;
			item.damage = 42;
			item.knockBack = 2f;
			item.useStyle = 5;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useAmmo = 1;
			item.ranged = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.shoot = 1;
			item.shootSpeed = 10f;
			item.useSound = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "SpiritBar", 14);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
