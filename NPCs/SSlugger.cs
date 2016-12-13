using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class SSlugger : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Shadow Slugger";
            npc.displayName = "Shadow Slugger";
            npc.width = 50;
            npc.height = 40;
            npc.damage = 31;
            npc.defense = 16;
            npc.lifeMax = 240;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 60f;
            npc.knockBackResist = .40f;
            npc.aiStyle = 26;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.HellArmoredBonesSword];
            aiType = NPCID.Unicorn;
            animationType = NPCID.HellArmoredBonesSword;
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
