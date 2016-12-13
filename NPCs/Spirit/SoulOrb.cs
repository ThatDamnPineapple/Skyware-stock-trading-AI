using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Spirit
{
    public class SoulOrb : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Soul Orb";
            npc.displayName = "Soul Orb";
            npc.width = 28;
            npc.height = 28;
            npc.damage = 0;
            npc.defense = 0;
            npc.lifeMax = 5;
            npc.soundHit = 3;
            npc.soundKilled = 6;
            npc.value = 60f;
            npc.knockBackResist = .45f;
            npc.aiStyle = 64;
            npc.noGravity = true;
            aiType = NPCID.Firefly;
            Main.npcFrameCount[npc.type] = 4;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>(mod).ZoneSpirit ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.05f, 0.05f, 0.4f);
        }
    }
}
