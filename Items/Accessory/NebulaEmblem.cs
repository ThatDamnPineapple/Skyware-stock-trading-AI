using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class NebulaEmblem : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Nebula Emblem";
			item.toolTip = "Increases Magic Damage and Reduces Mana Cost.";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 9;
			item.accessory = true;
			item.defense = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.6f;
			player.manaCost -= 0.8f;
		}
	}
}
