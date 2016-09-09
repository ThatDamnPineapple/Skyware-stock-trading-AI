using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class FallenAngel : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Fallen Angel";
            npc.displayName = "Fallen Angel";
            npc.width = 44;
            npc.height = 60;
            npc.damage = 50;
            npc.defense = 26;
            npc.lifeMax = 200;
            npc.soundHit = 4;
            npc.soundKilled = 6;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 44;
            npc.noGravity = true;
            npc.noTileCollide = true;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.FlyingFish];
            aiType = NPCID.FlyingFish;
            animationType = NPCID.FlyingFish;
            npc.stepSpeed = 2f;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.sky && Main.hardMode ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
