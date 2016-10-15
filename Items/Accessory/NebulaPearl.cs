using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class NebulaPearl : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Nebula Pearl";
			item.width = 18;
			item.height = 18;
            item.toolTip = "Can release healing orbs on hitting an enemy";
            item.value = Item.buyPrice(0, 40, 0, 0);
			item.rare = 9;

			item.accessory = true;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetModPlayer<MyPlayer>(mod).NebulaPearl = true;
		}
	}
}
