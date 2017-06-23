using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.YoYoOverload.Items.Acc
{
	public class Totem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bloody Bauble");
			Tooltip.SetDefault("A must have for any Yoyoer.");
		}


		public override void SetDefaults()
		{
			base.item.width = 14;
			base.item.height = 24;
			base.item.rare = 3;
            base.item.UseSound = SoundID.Item11;
            base.item.accessory = true;
			base.item.value = Item.buyPrice(0, 2, 30, 0);
			base.item.value = Item.sellPrice(0, 1, 6, 0);
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.1f;
			player.meleeCrit += 5;
			base.item.knockBack += 0.1f;
			player.meleeSpeed += 0.1f;
		}

		public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(base.mod);
			modRecipe.AddIngredient(null, "YoyoCharm2", 1);
			modRecipe.AddIngredient(null, "MCharm", 1);
			modRecipe.AddIngredient(null, "CCharm", 1);
			modRecipe.AddIngredient(null, "HCharm", 1);
			modRecipe.AddTile(26);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
