using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Atlas
{
    public class Atlas : ModNPC
    {
        // npc.ai[0] = state manager.

        int[] arms = new int[2];
        int timer = 0;
        bool halfstage = false;
        public override void SetDefaults()
        {
            npc.name = "Atlas";
            npc.width = 80;
            npc.height = 160;
			bossBag = mod.ItemType("AtlasBag");
            npc.damage = 22;
            npc.lifeMax = 4600;
            npc.knockBackResist = 0;

            npc.boss = true;
            npc.noGravity = true;

            npc.alpha = 255;
        }

        public override bool PreAI()
        {
            if (npc.ai[0] == 0) // First frame update.
            {
                npc.dontTakeDamage = true;

                arms[0] = NPC.NewNPC((int)npc.Center.X - 80 - Main.rand.Next(80, 160), (int)npc.position.Y, mod.NPCType("AtlasArm"), npc.whoAmI, 0, 0, 0, -1);
                arms[1] = NPC.NewNPC((int)npc.Center.X + 80 + Main.rand.Next(80, 160), (int)npc.position.Y, mod.NPCType("AtlasArm"), npc.whoAmI, 0, 0, 0, 1);

                npc.ai[0] = 1;
            }
            else if (npc.ai[0] == 1) // Spawn sequence (appearing).
            {
                npc.ai[1]++;
                if (npc.ai[1] >= 210)
                {
                    npc.alpha -= 4;
                    if (npc.alpha <= 0)
                    {
                        npc.ai[0] = 2;
                        npc.ai[1] = 0;

                        npc.alpha = 0;
                        npc.velocity.Y = 14;
                        npc.dontTakeDamage = false;
                    }
                }
            }
            else if (npc.ai[0] == 2)
            {
                if (npc.alpha == 0)
                {
                npc.netUpdate = true;
                npc.TargetClosest(true);
                #region Flying Movement
                //literally ripped from dusking :P
                float speed = 3f;
                float acceleration = 0.07f;
                Vector2 vector2 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float xDir = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) - vector2.X;
                float yDir = (float)(Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2) - 120) - vector2.Y;
                float length = (float)Math.Sqrt(xDir * xDir + yDir * yDir);
                if (length > 400 && Main.expertMode)
                {
                    ++speed;
                    acceleration += 0.05F;
                    if (length > 600)
                    {
                        ++speed;
                        acceleration += 0.05F;
                        if (length > 800)
                        {
                            ++speed;
                            acceleration += 0.05F;
                        }
                    }
                }
                float num10 = speed / length;
                xDir = xDir * num10;
                yDir = yDir * num10;
                if (npc.velocity.X < xDir)
                {
                    npc.velocity.X = npc.velocity.X + acceleration;
                    if (npc.velocity.X < 0 && xDir > 0)
                        npc.velocity.X = npc.velocity.X + acceleration;
                }
                else if (npc.velocity.X > xDir)
                {
                    npc.velocity.X = npc.velocity.X - acceleration;
                    if (npc.velocity.X > 0 && xDir < 0)
                        npc.velocity.X = npc.velocity.X - acceleration;
                }
                if (npc.velocity.Y < yDir)
                {
                    npc.velocity.Y = npc.velocity.Y + acceleration;
                    if (npc.velocity.Y < 0 && yDir > 0)
                        npc.velocity.Y = npc.velocity.Y + acceleration;
                }
                else if (npc.velocity.Y > yDir)
                {
                    npc.velocity.Y = npc.velocity.Y - acceleration;
                    if (npc.velocity.Y > 0 && yDir < 0)
                        npc.velocity.Y = npc.velocity.Y - acceleration;
                }
                #endregion
                timer++;
                if (timer > 300) // Fires prism bolts
                {
                    Vector2 direction = Main.player[npc.target].Center - npc.Center;
                    direction.Normalize();
                    direction.X *= 8f;
                    direction.Y *= 8f;

                    int amountOfProjectiles = Main.rand.Next(3, 5);
                    for (int i = 0; i < amountOfProjectiles; ++i)
                    {
                        float A = (float)Main.rand.Next(-150, 150) * 0.01f;
                        float B = (float)Main.rand.Next(-150, 150) * 0.01f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, mod.ProjectileType("PrismaticBoltHostile"), 25, 1, Main.myPlayer, 0, 0);
                        timer = 0;
                    }
                }
                if (npc.life < 2301)
                {

                    if (halfstage == false)
                    {
                        for (int I = 0; I < 5; I++)
                        {
                            //cos = y, sin = x
                            int GeyserEye = NPC.NewNPC((int)(npc.Center.X + (Math.Sin(I * 72) * 200)), (int)(npc.Center.Y + (Math.Cos(I * 72) * 200)), mod.NPCType("CobbledEye"), npc.whoAmI, 0, 0, 0, -1);
                            NPC Eye = Main.npc[GeyserEye];
                            Eye.ai[0] = I * 72;
                            Eye.ai[3] = I * 72;
                        }
                        halfstage = true;
                    }
                }
            }
                Main.npc[arms[0]].ai[0] = 2;
                    Main.npc[arms[1]].ai[0] = 2;
                }


            return false;
        }
		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ArcaneGeyser"), Main.rand.Next(32,44));
			string[] lootTable = { "KingRock", "Mountain", "TitanboundBulwark", };
			int loot = Main.rand.Next(lootTable.Length);
			 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
                
			}
		}
        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            if (npc.ai[0] < 2)
                return false;

            return base.CanHitPlayer(target, ref cooldownSlot);
        }
    }
}
