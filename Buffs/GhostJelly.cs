using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class GhostJelly : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "Ghost Jelly";
        }

        public override bool ReApply(NPC npc, int time, int buffIndex)
        {
            NInfo info = npc.GetModInfo<NInfo>(mod);
            if (info.GhostJellyStacks < 5)
                info.GhostJellyStacks++;
            return true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            NInfo info = npc.GetModInfo<NInfo>(mod);

            if (info.GhostJellyStacks == 0)
                info.GhostJellyStacks = 1;

            for (int i = 0; i < info.GhostJellyStacks; ++i)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 206);
            }
        }
    }
}
