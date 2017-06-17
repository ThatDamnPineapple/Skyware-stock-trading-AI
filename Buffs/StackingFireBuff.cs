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
            DisplayName.SetDefault("Combustion Blaze");
        }

        public override bool ReApply(NPC npc, int time, int buffIndex)
        {
            npc.GetGlobalNPC<GNPC>(mod);
            if (fireStacks < 3)
                fireStacks++;
            npc.buffTime[buffIndex] = time;
            return true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<GNPC>(mod);
            if (fireStacks <= 0)
                fireStacks = 1;
			 if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);      	
            }
        }
    }
}
