using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class AcidCrawler : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Acid Crawler";
            npc.displayName = "Acid Crawler";
            npc.width = 38;
            npc.height = 28;
            npc.damage = 44;
            npc.defense = 16;
            npc.lifeMax = 180;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = .25f;
            npc.aiStyle = 25;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.BlueSlime];
            aiType = NPCID.ToxicSludge;
            animationType = NPCID.BlueSlime;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (tile == 1) && spawnInfo.spawnTileY > Main.rockLayer && Main.hardMode ? 0.6f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Acid_Leg"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Acid_Leg"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Acid_Eye"), 1f);
            }
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Poisoned, 240);
        }
        public override void AI()
        {
            int dust = Dust.NewDust(npc.position, npc.width - 30, npc.height - 30, 75);
        }
    }
}
