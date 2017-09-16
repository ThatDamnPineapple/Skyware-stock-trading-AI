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
        
            Main.buffNoTimeDisplay[Type] = false;
            DisplayName.SetDefault("Sturdy");
            Description.SetDefault("Your sturdiness has been cracked...");
            Main.pvpBuff[Type] = false;
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
    }
}
