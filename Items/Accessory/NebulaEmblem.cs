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
			item.toolTip = "Increases magic damage by 20% and reduces mana cost by 10%.";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 8;
			item.accessory = true;
			item.defense = 3;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.magicDamage += 0.2f;
			player.manaCost -= 0.1f;
		}
	}
}
