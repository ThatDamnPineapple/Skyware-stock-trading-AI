using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class CWalker : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Corrupt Walker";
            npc.displayName = "Corrupt Walker";
            npc.width = 40;
            npc.height = 46;
            npc.damage = 22;
            npc.defense = 11;
            npc.lifeMax = 80;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .20f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
            aiType = NPCID.FaceMonster;
            animationType = NPCID.Zombie;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneCorrupt && spawnInfo.spawnTileY < Main.rockLayer ? 0.5f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
