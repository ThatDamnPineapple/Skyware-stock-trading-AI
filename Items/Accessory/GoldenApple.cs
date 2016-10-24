using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class GoldenApple : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Golden Apple";
			item.width = 18;
			item.height = 18;
			item.toolTip = "Increases life regen as health decreases";
			item.value = Item.buyPrice(0, 12, 0, 0);
			item.rare = 5;
			item.defense = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			float defBoost = (float)(player.statLifeMax2 - player.statLife) / (float)player.statLifeMax2 * 20f;
			player.statDefense += (int)defBoost;
		}

	}
}
