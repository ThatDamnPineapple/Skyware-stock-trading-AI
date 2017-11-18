using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.Items.Halloween;

namespace SpiritMod
{
	public static class _ItemUtils
	{
		public static bool IsWeapon(this Item item)
		{
			return item.type != 0 && item.stack > 0 && item.useStyle > 0 && item.damage > 0;
		}

		public static void DropItem(this Entity ent, int type, int stack = 1)
		{
			Item.NewItem((int)ent.position.X, (int)ent.position.Y, ent.width, ent.height, type, stack);
		}

		public static void DropItem(this Entity ent, int type, float chance)
		{
			if (chance < Main.rand.NextDouble())
				Item.NewItem((int)ent.position.X, (int)ent.position.Y, ent.width, ent.height, type);
		}

		public static void DropItem(this Entity ent, int type, int min, int max)
		{
			Item.NewItem((int)ent.position.X, (int)ent.position.Y, ent.width, ent.height, type, Main.rand.Next(min, max));
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
			else if (effect <79)
			{
				player.QuickSpawnItem(Lollipop._type);
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
