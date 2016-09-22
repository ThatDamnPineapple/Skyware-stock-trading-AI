using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Scarebus
{
    public class Scarab : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Scarab";
            npc.displayName = "Scarab";
            npc.width = 32;
            npc.height = 20;
            npc.damage = 12;
            npc.defense = 0;
            npc.lifeMax = 140;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 26;
            Main.npcFrameCount[npc.type] = 4;
            aiType = NPCID.Zombie;
        }

		
		public override bool PreAI()
		{
			npc.spriteDirection = npc.direction;
			return true;
		}
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer && Main.hardMode && !Main.dayTime ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
			public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.25f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
    }
}
