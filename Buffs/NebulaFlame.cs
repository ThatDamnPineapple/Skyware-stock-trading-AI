using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class NebulaFlame : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Nebula Flame");
        }

        public override bool ReApply(NPC npc, int time, int buffIndex)
        {
            npc.GetGlobalNPC<GNPC>(mod);
            if (nebulaFlameStacks < 5)
                nebulaFlameStacks++;
            return true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<GNPC>(mod);

            if (nebulaFlameStacks == 0)
                nebulaFlameStacks = 1;

            for (int i = 0; i < nebulaFlameStacks; ++i)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 242);
            }
        }
    }
}
