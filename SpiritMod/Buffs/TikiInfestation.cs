using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
	class TikiInfestation : ModBuff
	{
		public static ModBuff _ref;

		public const int maxStacks = 10;
		public const int duration = 600;

		public override void SetDefaults()
		{
			Main.buffName[this.Type] = "Tiki Infestation";
			Main.buffTip[Type] = "Releases Tiki Spirits on death.";
			Main.buffNoTimeDisplay[Type] = false;
		}

	}
}
