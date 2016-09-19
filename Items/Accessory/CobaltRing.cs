using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class CobaltRing : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Cobalt ring";
			item.width = 18;
			item.height = 18;
            item.toolTip = "Increases melee and movement speed";
            item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;

			item.accessory = true;

			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			 player.moveSpeed *= 1.10f;
			 player.meleeSpeed *= 1.10f;
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
