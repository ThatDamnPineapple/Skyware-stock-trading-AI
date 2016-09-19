using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class SolarEmblem : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Solar Emblem";
			item.width = 18;
			item.height = 18;
            item.toolTip = "Increases melee critical chance, melee speed, and damage.";
            item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;

			item.accessory = true;

			item.defense = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeCrit += 2;
			player.meleeSpeed += 0.3f;
			player.meleeDamage += 0.3f;
		}
	}
}
