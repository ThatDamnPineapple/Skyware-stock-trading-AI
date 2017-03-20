using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class StarDestiny : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[this.Type] = "Star Destiny";
            Main.buffTip[Type] = "Huge DoT";

            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(NPC npc, ref int buffIndex)
        { 
            npc.GetModInfo<NInfo>(mod).starDestiny = true;
            
        }

    }
}
