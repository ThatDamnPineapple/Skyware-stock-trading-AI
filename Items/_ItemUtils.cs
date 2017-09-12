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
			return item.type != 0 && item.stack > 0 && item.useStyle > 0 && item.damage > 0;
		}
	}
}
