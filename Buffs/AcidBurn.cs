using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class AcidBurn : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "AcidBurn";
        }

        public override bool ReApply(NPC npc, int time, int buffIndex)
        {
            NInfo info = npc.GetModInfo<NInfo>(mod);
            if (info.acidBurnStacks < 2)
                info.acidBurnStacks++;
            npc.buffTime[buffIndex] = time;
            return true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            NInfo info = npc.GetModInfo<NInfo>(mod);
            if (info.acidBurnStacks <= 0)
                info.acidBurnStacks = 1;
			 if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 107);      	
            }
        }
    }
}
