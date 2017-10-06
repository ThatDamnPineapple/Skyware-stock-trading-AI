using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.Items.Halloween;

namespace SpiritMod.Items
{
	public static class _ItemUtils
	{
		public static bool IsWeapon(this Item item)
		{
			return item.type != 0 && item.stack > 0 && item.useStyle > 0 && item.damage > 0;
		}

		public static void DropCandy(Player player)
		{
			int effect = Main.rand.Next(100);
			if (effect < 9)
			{
				player.QuickSpawnItem(Taffy._type);
			}
			else if (effect < 29)
			{
				player.QuickSpawnItem(Candy._type);
			}
			else if (effect < 49)
			{
				player.QuickSpawnItem(ChocolateBar._type);
			}
			else if (effect < 59)
			{
				player.QuickSpawnItem(HealthCandy._type);
			}
			else if (effect < 69)
			{
				player.QuickSpawnItem(ManaCandy._type);
			}
			else if (effect <78)
			{
				player.QuickSpawnItem(Lollipop._type);
			}
			else if (effect < 79)
			{
				//trash
			}
			else if (effect< 83)
			{
				player.QuickSpawnItem(Apple._type);
			}
			else if (effect < 95)
			{
				player.QuickSpawnItem(MysteryCandy._type);
			}
			else
			{
				player.QuickSpawnItem(GoldCandy._type);
			}
		}
	}
}
