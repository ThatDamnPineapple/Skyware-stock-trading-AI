using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class CavernCrawler : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Cavern Crawler";
            npc.displayName = "Cavern Crawler";
            npc.width = 34;
            npc.height = 36;
            npc.damage = 40;
            npc.defense = 9;
            npc.lifeMax = 140;
            npc.soundHit = 2;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 67;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Snail];
            aiType = NPCID.Snail;
            animationType = NPCID.Snail;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneUndergroundDesert ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
