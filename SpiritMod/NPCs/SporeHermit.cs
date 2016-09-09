using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class SporeHermit : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Spore Hermit";
            npc.displayName = "Spore Hermit";
            npc.width = 48;
            npc.height = 38;
            npc.damage = 74;
            npc.defense = 20;
            npc.lifeMax = 160;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .30f;
            npc.aiStyle = 1;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.AnomuraFungus];
            aiType = NPCID.AnomuraFungus;
            animationType = NPCID.AnomuraFungus;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>(mod).ZoneVerdant ? 1f : 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
    }
}
