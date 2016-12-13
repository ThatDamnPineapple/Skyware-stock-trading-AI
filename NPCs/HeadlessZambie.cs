using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class HeadlessZambie : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Headless Zombie";
            npc.displayName = "Headless Zombie";
            npc.width = 17;
            npc.height = 15;
            npc.damage = 44;
            npc.defense = 0;
            npc.lifeMax = 120;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 26;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer && Main.hardMode && !Main.dayTime ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
