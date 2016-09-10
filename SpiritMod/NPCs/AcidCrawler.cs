using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class AcidCrawler : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Acid Crawler";
            npc.displayName = "Acid Crawler";
            npc.width = 38;
            npc.height = 28;
            npc.damage = 44;
            npc.defense = 16;
            npc.lifeMax = 220;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .25f;
            npc.aiStyle = 25;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
            aiType = NPCID.Mimic;
            animationType = NPCID.BlueSlime;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
            return  (tile == 1) && spawnInfo.spawnTileY > Main.rockLayer ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
