using System;
using Terraria;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Magic
{
	public class PhantomArc : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Phantom Arc";
			item.width = 36;
			item.height = 36;
            item.toolTip = "Summons an infinitely piercing laser of lost souls";
			item.value = Item.buyPrice(0, 6, 0, 0);
			item.rare = 5;
			item.crit += 6;
			item.damage = 48;
            item.mana = 9;
            item.useStyle = 5;
			item.useTime = 10;
			item.useAnimation = 10;
            item.reuseDelay = 5;
			item.magic = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.shoot = mod.ProjectileType("PhantomArcHandle");
			item.shootSpeed = 26f;
		}
		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "SpiritBar", 8);
			modRecipe.AddIngredient(531, 1);
			modRecipe.AddIngredient(520, 5);
			modRecipe.AddIngredient(521, 5);
			modRecipe.AddTile(101);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}