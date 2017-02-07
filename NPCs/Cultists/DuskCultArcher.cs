/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Cultists
{
    public class DuskCultArcher : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Dusk Cult Archer";
            npc.displayName = "Dusk Cult Archer";
            npc.width = 42;
            npc.height = 54;
            npc.damage = 120;
            npc.defense = 14;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 60f;
            npc.knockBackResist = 0.45f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.CultistArcherWhite];
            aiType = NPCID.CultistArcherWhite;
            animationType = NPCID.CultistArcherWhite;
        }

        public override void NPCLoot()
        {
            InvasionWorld.invasionSize -= 1;
            if (InvasionWorld.invasionSize < 0)
                InvasionWorld.invasionSize = 0;
            if (Main.netMode != 1)
                InvasionHandler.ReportInvasionProgress(InvasionWorld.invasionSizeStart - InvasionWorld.invasionSize, InvasionWorld.invasionSizeStart, 0);
            if (Main.netMode != 2)
                return;
            NetMessage.SendData(78, -1, -1, "", InvasionWorld.invasionProgress, (float)InvasionWorld.invasionProgressMax, (float)Main.invasionProgressIcon, 0.0f, 0, 0, 0);
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
          //  if (InvasionWorld.invasionType == SpiritMod.customEvent)
            //    return 10;

            return 0;
        }
    }
}
*/