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
            DisplayName.SetDefault("Ghostly Wrath");
        }

        public override bool ReApply(NPC npc, int time, int buffIndex)
        {
            npc.GetGlobalNPC<GNPC>(mod);
            if (GhostJellyStacks < 5)
                GhostJellyStacks++;
            return true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<GNPC>(mod);

            if (GhostJellyStacks == 0)
                GhostJellyStacks = 1;

            for (int i = 0; i < GhostJellyStacks; ++i)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 206);
            }
        }
    }
}
