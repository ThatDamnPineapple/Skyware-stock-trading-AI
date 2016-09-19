using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class KingRock : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "King's stone";
			item.width = 18;
			item.height = 18;
            item.toolTip = "Magic attacks sometimes shoot prismatic bolts";
            item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;

			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MyPlayer>(mod).KingRock = true;
		}
	}
}
