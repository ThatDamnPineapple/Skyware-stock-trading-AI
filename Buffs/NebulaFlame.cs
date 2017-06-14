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
            NInfo info = npc.GetModInfo<NInfo>(mod);
            if (info.nebulaFlameStacks < 5)
                info.nebulaFlameStacks++;
            return true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            NInfo info = npc.GetModInfo<NInfo>(mod);

            if (info.nebulaFlameStacks == 0)
                info.nebulaFlameStacks = 1;

            for (int i = 0; i < info.nebulaFlameStacks; ++i)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 242);
            }
        }
    }
}
