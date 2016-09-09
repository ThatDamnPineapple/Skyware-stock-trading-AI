using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class UmbraStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Umbra Staff";
			item.width = 36;
			item.height = 36;
			item.toolTip = "";
			item.value = Item.buyPrice(0, 30, 0, 0);
			item.rare = 9;
			item.damage = 100;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.useTime = 36;
			item.useAnimation = 36;
			item.mana = 10;
			item.magic = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("ShadowBall_Friendly");
			item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(2, 1);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
