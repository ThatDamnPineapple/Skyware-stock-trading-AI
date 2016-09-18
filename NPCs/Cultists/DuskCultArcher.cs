using Terraria;
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
            npc.soundHit = 1;
            npc.soundKilled = 6;
            npc.value = 60f;
            npc.knockBackResist = 0.45f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.CultistArcherWhite];
            aiType = NPCID.CultistArcherWhite;
            animationType = NPCID.CultistArcherWhite;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            if (Main.invasionType == SpiritMod.customEvent)
                return 1;

            return 0;
        }
    }
}