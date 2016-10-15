using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class SpiritKnife : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spirit Knife";
			item.width = 16;
			item.height = 24;
			item.toolTip = "";
			item.value = Terraria.Item.buyPrice(0, 30, 0, 0);
			item.rare = 9;
			item.maxStack = 999;
			item.crit += 6;
			item.damage = 47;
			item.knockBack = 1f;
			item.useStyle = 1;
			item.useTime = 14;
			item.useAnimation = 14;
			item.thrown = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.consumable = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("SpiritKnife");
			item.shootSpeed = 8f;
			item.useSound = 1;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "SpiritBar", 1);
			modRecipe.AddTile(134);
			modRecipe.SetResult(this, 15);
			modRecipe.AddRecipe();
		}
	}
}
