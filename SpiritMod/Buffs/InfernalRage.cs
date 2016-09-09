using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs
{
    public class InfernalRage : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "Infernal Rage";
            Main.buffTip[Type] = "Greatly boosted damage, at the cost of your soul...";
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}
