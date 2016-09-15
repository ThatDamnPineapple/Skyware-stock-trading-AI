using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace SpiritMod.Items.Accessory
{
	public class TitaniumRing : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Titanium band";
			item.toolTip = "Every hit has a chance to give you shadow dodge";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
			item.accessory = true;
			item.defense = 2;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MyPlayer>(mod).TiteRing = true;
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TitaniumBar, 10);
             recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
