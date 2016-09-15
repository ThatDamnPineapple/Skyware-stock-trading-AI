using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;

namespace SpiritMod.Items.Accessory
{
	public class NebulaPearl : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Nebula pearl";
			item.toolTip = "Can release healing orbs on hitting an enemy";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 40, 0, 0);
			item.rare = 9;
			item.accessory = true;
			item.defense = 0;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MyPlayer>(mod).NebulaPearl = true;
		}
	}
}
