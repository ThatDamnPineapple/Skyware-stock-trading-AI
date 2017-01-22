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
            npc.width = 34;
            npc.height = 36;
            npc.damage = 40;
            npc.defense = 9;
            npc.lifeMax = 140;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 1060f;
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Snail];
            aiType = NPCID.Snail;
            animationType = NPCID.Snail;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.player.ZoneUndergroundDesert ? 0.4f : 0f;
        }
		public override void NPCLoot()
		{
			if (Main.rand.Next(100) <= 3)
			{
				
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height,(mod.ItemType("CrawlerockStaff")));
			}
            {

                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, (mod.ItemType("Carapace")));
            }
        }
        public override void AI()
        {
            {
                    if (npc.ai[3] != 0f)
                    {
                        npc.scale = npc.ai[3];
                        int num1434 = (int)(12f * npc.scale);
                        int num1435 = (int)(12f * npc.scale);
                        if (num1434 != npc.width)
                        {
                            npc.position.X = npc.position.X + (float)(npc.width / 2) - (float)num1434 - 2f;
                            npc.width = num1434;
                        }
                        if (num1435 != npc.height)
                        {
                            npc.position.Y = npc.position.Y + (float)npc.height - (float)num1435;
                            npc.height = num1435;
                        }
                    }
                    if (npc.ai[3] == 0f && Main.netMode != 1)
                    {
                        npc.ai[3] = (float)Main.rand.Next(80, 111) * 0.01f;
                        npc.netUpdate = true;
                    }
               
                float num1436 = 0.9f;
               
                if (npc.ai[0] == 0f)
                {
                    npc.TargetClosest(true);
                    npc.directionY = 1;
                    npc.ai[0] = 1f;
                    if (npc.direction > 0)
                    {
                        npc.spriteDirection = 1;
                    }
                }
                bool flag128 = false;
                if (Main.netMode != 1)
                {
                    if (npc.ai[2] == 0f && Main.rand.Next(7200) == 0)
                    {
                        npc.ai[2] = 2f;
                        npc.netUpdate = true;
                    }
                    if (!npc.collideX && !npc.collideY)
                    {
                        npc.localAI[3] += 1f;
                        if (npc.localAI[3] > 5f)
                        {
                            npc.ai[2] = 2f;
                            npc.netUpdate = true;
                        }
                    }
                    else
                    {
                        npc.localAI[3] = 0f;
                    }
                }
                if (npc.ai[2] > 0f)
                {
                    npc.ai[1] = 0f;
                    npc.ai[0] = 1f;
                    npc.directionY = 1;
                    if (npc.velocity.Y > num1436)
                    {
                        npc.rotation += (float)npc.direction * 0.1f;
                    }
                    else
                    {
                        npc.rotation = 0f;
                    }
                    npc.spriteDirection = npc.direction;
                    npc.velocity.X = num1436 * (float)npc.direction;
                    npc.noGravity = false;
                    int num1437 = (int)(npc.Center.X + (float)(npc.width / 2 * -(float)npc.direction)) / 16;
                    int num1438 = (int)(npc.position.Y + (float)npc.height + 8f) / 16;
                    if (Main.tile[num1437, num1438] != null && !Main.tile[num1437, num1438].topSlope() && npc.collideY)
                    {
                        npc.ai[2] -= 1f;
                    }
                    num1438 = (int)(npc.position.Y + (float)npc.height - 4f) / 16;
                    num1437 = (int)(npc.Center.X + (float)(npc.width / 2 * npc.direction)) / 16;
                    if (Main.tile[num1437, num1438] != null && Main.tile[num1437, num1438].bottomSlope())
                    {
                        npc.direction *= -1;
                    }
                    if (npc.collideX && npc.velocity.Y == 0f)
                    {
                        flag128 = true;
                        npc.ai[2] = 0f;
                        npc.directionY = -1;
                        npc.ai[1] = 1f;
                    }
                    if (npc.velocity.Y == 0f)
                    {
                        if (npc.localAI[1] == npc.position.X)
                        {
                            npc.localAI[2] += 1f;
                            if (npc.localAI[2] > 10f)
                            {
                                npc.direction = 1;
                                npc.velocity.X = (float)npc.direction * num1436;
                                npc.localAI[2] = 0f;
                            }
                        }
                        else
                        {
                            npc.localAI[2] = 0f;
                            npc.localAI[1] = npc.position.X;
                        }
                    }
                }
                if (npc.ai[2] == 0f)
                {
                    npc.noGravity = true;
                    if (npc.ai[1] == 0f)
                    {
                        if (npc.collideY)
                        {
                            npc.ai[0] = 2f;
                        }
                        if (!npc.collideY && npc.ai[0] == 2f)
                        {
                            npc.direction = -npc.direction;
                            npc.ai[1] = 1f;
                            npc.ai[0] = 1f;
                        }
                        if (npc.collideX)
                        {
                            npc.directionY = -npc.directionY;
                            npc.ai[1] = 1f;
                        }
                    }
                    else
                    {
                        if (npc.collideX)
                        {
                            npc.ai[0] = 2f;
                        }
                        if (!npc.collideX && npc.ai[0] == 2f)
                        {
                            npc.directionY = -npc.directionY;
                            npc.ai[1] = 0f;
                            npc.ai[0] = 1f;
                        }
                        if (npc.collideY)
                        {
                            npc.direction = -npc.direction;
                            npc.ai[1] = 0f;
                        }
                    }
                    if (!flag128)
                    {
                        float num1439 = npc.rotation;
                        if (npc.directionY < 0)
                        {
                            if (npc.direction < 0)
                            {
                                if (npc.collideX)
                                {
                                    npc.rotation = 1.57f;
                                    npc.spriteDirection = -1;
                                }
                                else if (npc.collideY)
                                {
                                    npc.rotation = 3.14f;
                                    npc.spriteDirection = 1;
                                }
                            }
                            else if (npc.collideY)
                            {
                                npc.rotation = 3.14f;
                                npc.spriteDirection = -1;
                            }
                            else if (npc.collideX)
                            {
                                npc.rotation = 4.71f;
                                npc.spriteDirection = 1;
                            }
                        }
                        else if (npc.direction < 0)
                        {
                            if (npc.collideY)
                            {
                                npc.rotation = 0f;
                                npc.spriteDirection = -1;
                            }
                            else if (npc.collideX)
                            {
                                npc.rotation = 1.57f;
                                npc.spriteDirection = 1;
                            }
                        }
                        else if (npc.collideX)
                        {
                            npc.rotation = 4.71f;
                            npc.spriteDirection = -1;
                        }
                        else if (npc.collideY)
                        {
                            npc.rotation = 0f;
                            npc.spriteDirection = 1;
                        }
                        float num1440 = npc.rotation;
                        npc.rotation = num1439;
                        if ((double)npc.rotation > 6.28)
                        {
                            npc.rotation -= 6.28f;
                        }
                        if (npc.rotation < 0f)
                        {
                            npc.rotation += 6.28f;
                        }
                        float num1441 = Math.Abs(npc.rotation - num1440);
                        float num1442 = 0.1f;
                        if (npc.rotation > num1440)
                        {
                            if ((double)num1441 > 3.14)
                            {
                                npc.rotation += num1442;
                            }
                            else
                            {
                                npc.rotation -= num1442;
                                if (npc.rotation < num1440)
                                {
                                    npc.rotation = num1440;
                                }
                            }
                        }
                        if (npc.rotation < num1440)
                        {
                            if ((double)num1441 > 3.14)
                            {
                                npc.rotation -= num1442;
                            }
                            else
                            {
                                npc.rotation += num1442;
                                if (npc.rotation > num1440)
                                {
                                    npc.rotation = num1440;
                                }
                            }
                        }
                    }
                    npc.velocity.X = num1436 * (float)npc.direction;
                    npc.velocity.Y = num1436 * (float)npc.directionY;
                }
            }
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
