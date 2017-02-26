using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Reachman : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Reach Guard";
            npc.displayName = "Reach Guard";
            npc.width = 40;
            npc.height = 46;
            npc.damage = 23;
            npc.defense = 11;
            npc.lifeMax = 80;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 260f;
            npc.knockBackResist = .20f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie];
            aiType = NPCID.AngryBones;
            animationType = NPCID.Zombie;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>(mod).ZoneReach ? 4f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Reach1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Reach2"), 1f);
            }
        }
    }
}
