using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
	public class FateBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Cosmic Seal";
			Main.buffTip[Type] = "You will survive...";
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
            Main.debuff[Type] = true;
        }
	}
}