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
            DisplayName.SetDefault("Sturdy");
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}
