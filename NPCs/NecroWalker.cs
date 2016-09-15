using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class NecroWalker : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Necro Walker";
            npc.displayName = "Necro Walker";
            npc.width = 32;
            npc.height = 52;
            npc.damage = 28;
            npc.defense = 17;
            npc.lifeMax = 200;
            npc.soundHit = 2;
            npc.soundKilled = 2;
            npc.value = 60f;
            npc.knockBackResist = .37f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.AngryBones];
            aiType = NPCID.AngryBones;
            animationType = NPCID.AngryBones;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneDungeon ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
