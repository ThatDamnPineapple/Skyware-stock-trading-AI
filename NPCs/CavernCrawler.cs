using Terraria;
using Terraria.ID;
using System;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class CavernCrawler : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Cavern Crawler";
            npc.displayName = "Cavern Crawler";
            npc.width = 45;
            npc.height = 45;
            npc.damage = 22;
            npc.defense = 9;
            npc.lifeMax = 140;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 860f;
            npc.aiStyle = 3;
            npc.knockBackResist = 0.95f;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Snail];
            aiType = NPCID.AnomuraFungus;
            animationType = NPCID.Snail;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneUndergroundDesert ? 0.18f : 0f;
        }
		public override void NPCLoot()
		{
			if (Main.rand.Next(100) <= 3)
			{
				
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,(mod.ItemType("CrawlerockStaff")));
			}
            {

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("Carapace")), Main.rand.Next(1) + 1);
            }
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
			if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/CaveCrawler_1"));
            }
        }
    }
}
