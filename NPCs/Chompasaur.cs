using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Chompasaur : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Chompasaur";
            npc.displayName = "Chompasaur";
            npc.width = 64;
            npc.height = 46;
            npc.damage = 55;
            npc.defense = 18;
            npc.lifeMax = 240;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 26;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
            aiType = NPCID.Zombie;
            animationType = NPCID.Zombie;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return Main.hardMode && spawnInfo.player.ZoneUndergroundDesert ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
