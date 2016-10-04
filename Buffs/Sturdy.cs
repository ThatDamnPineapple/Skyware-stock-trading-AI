using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class Sturdy : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "Sturdy";
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}
