using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items
{
	public static class _ItemUtils
	{
		public static bool IsWeapon(this Item item)
		{
			return item.stack > 0 && item.damage > 0;
		}
	}
}
