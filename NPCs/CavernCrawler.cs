using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class CavernCrawler : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Cavern Crawler";
            npc.displayName = "Cavern Crawler";
            npc.width = 34;
            npc.height = 36;
            npc.damage = 40;
            npc.defense = 9;
            npc.lifeMax = 140;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 67;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Snail];
            aiType = NPCID.Snail;
            animationType = NPCID.Snail;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneUndergroundDesert ? 0.1f : 0f;
        }
		public override void NPCLoot()
		{
			if (Main.rand.Next(100) <= 3)
			{
				
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,(mod.ItemType("CrawlerockStaff")),Main.rand.Next(1,5));
			}
		}
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
			if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gore/CaveCrawler_1"));
            }
        }
    }
}
