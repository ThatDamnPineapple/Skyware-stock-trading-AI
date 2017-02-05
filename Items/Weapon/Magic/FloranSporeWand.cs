using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace SpiritMod.Items.Weapon.Magic
{
	public class FloranSporeWand : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Floran Spore Wand";
			item.width = 48;
			item.height = 50;			
			item.value = Item.buyPrice(0, 0, 90, 0);
			item.rare = 2;
			item.damage = 21;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.useTime = 25;
			item.useAnimation = 25;
			item.mana = 6;
            item.toolTip = "Shoots out a floating Floran Spore!";
            item.knockBack = 3;
            item.crit = 8;
			item.magic = true;
			item.noMelee = true;
			item.shoot = mod.ProjectileType("FloranSpore");
			item.shootSpeed = 10f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
			modRecipe.AddIngredient(null, "FloranBar", 12);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
