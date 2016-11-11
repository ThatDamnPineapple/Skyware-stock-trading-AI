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
			item.toolTip = "Increases Minion Knockback, Minion damage, and increases your max minions by 3.";
			item.width = 18;
			item.height = 18;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 10;
			item.accessory = true;
			item.defense = 6;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.minionKB += 0.4f;
			player.maxMinions += 3;
			player.minionDamage += 0.3f;
		}
	}
}
