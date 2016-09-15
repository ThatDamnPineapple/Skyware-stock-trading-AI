using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace SpiritMod.Items.Accessory
{
	public class KingRock : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "King's stone";
			item.toolTip = "Magic attacks sometimes shoot prismatic bolts";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
			item.accessory = true;
			item.defense = 0;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MyPlayer>(mod).KingRock = true;
		}
	}
}
