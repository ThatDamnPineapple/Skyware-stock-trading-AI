using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class StardustEmblem : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Stardust Emblem";
			item.toolTip = "Increases Minion Knockback by 15%, Minion damage by 17, and increases your max minions by 2.";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 8;
			item.accessory = true;
			item.defense = 3;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionKB += 0.15f;
			player.maxMinions += 2;
			player.minionDamage += 0.17f;
		}
	}
}
