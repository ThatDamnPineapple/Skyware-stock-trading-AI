using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class StackingFireBuff : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "StackingFireBuff_NPCOnly";
        }

        public override bool ReApply(NPC npc, int time, int buffIndex)
        {
            NInfo info = npc.GetModInfo<NInfo>(mod);
            if (info.fireStacks < 3)
                info.fireStacks++;
            npc.buffTime[buffIndex] = time;
            return true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            NInfo info = npc.GetModInfo<NInfo>(mod);
            if (info.fireStacks <= 0)
                info.fireStacks = 1;
        }
    }
}
