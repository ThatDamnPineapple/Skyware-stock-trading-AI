using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class BScourge : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Bubonic Scourge";
            npc.displayName = "Bubonic Scourge";
            npc.width = 64;
            npc.height = 36;
            npc.damage = 85;
            npc.defense = 28;
            npc.lifeMax = 700;
            npc.HitSound = SoundID.NPCHit19;
			npc.DeathSound = SoundID.NPCDeath5;
            npc.value = 80000f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 26;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.NebulaBeast];
            aiType = NPCID.Unicorn;
            animationType = NPCID.NebulaBeast;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
            return (tile == 2) && NPC.downedMoonlord && !Main.dayTime && spawnInfo.spawnTileY < Main.rockLayer ? 0.14f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScourgeGore"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScourgeGore1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/ScourgeGore2"), 1f);
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Venom, 420);
        }
    }
}
