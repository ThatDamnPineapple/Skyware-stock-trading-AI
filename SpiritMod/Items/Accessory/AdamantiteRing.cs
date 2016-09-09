using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace SpiritMod.Items.Accessory
{
	public class AdamantiteRing : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Adamantite band";
			item.toolTip = "Gives stat bonuses if below 50% hp, but decreases defense by 8";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
			item.accessory = true;
			item.defense = 0;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense -= 8;
			 if (player.statLife < player.statLifeMax2 / 2)
			 {
					player.magicCrit += 10;
				player.meleeCrit += 10;
				player.thrownCrit += 10;
				player.rangedCrit += 10;
				player.magicDamage *= 1.1f;
			player.meleeDamage *= 1.1f;
			player.rangedDamage *= 1.1f;
			player.minionDamage *= 1.1f;
			player.thrownDamage *= 1.1f;
			 }
		}
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AdamantiteBar, 10);
           recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
