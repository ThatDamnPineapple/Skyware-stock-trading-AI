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
        //kys donald trump i hope u die m8
        int[] arms = new int[2];
        int timer = 0;
        bool halfstage = false;
        int collideTimer = 0;

        public override void SetDefaults()
        {
            npc.name = "Atlas";
            npc.width = 80;
            npc.height = 160;
            bossBag = mod.ItemType("AtlasBag");
            npc.damage = 26;
            npc.lifeMax = 5000;
            npc.knockBackResist = 0;

            npc.boss = true;
            npc.noGravity = true;

            npc.alpha = 255;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath5;
        }

        private int Counter;
        public override bool PreAI()
        {
            bool expertMode = Main.expertMode; //expert mode bool
            Player player = Main.player[npc.target]; //player target
            bool aiChange = (double)npc.life <= (double)npc.lifeMax * 0.5; //ai change to phase 2
            bool phaseChange = (double)npc.life <= (double)npc.lifeMax * 0.2; //aggression increase
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
                    Vector2 dist = player.Center - npc.Center;
                    Vector2 direction = player.Center - npc.Center;
                    npc.netUpdate = true;
                    npc.TargetClosest(true);
                    if (!player.active || player.dead)
                    {
                        npc.TargetClosest(false);
                        npc.velocity.Y = -100;
                    }
                    #region Dashing mechanics
                    //dash if player is too far away
                    if (Math.Sqrt((dist.X * dist.X) + (dist.Y * dist.Y)) > 455)
                    {
                        direction.Normalize();
                        npc.velocity *= 0.98f;
                        if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) >= 7f)
                        {
                            int dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 1, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                            Main.dust[dust].noGravity = true;
                            dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 1, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                            Main.dust[dust].noGravity = true;
                        }
                        if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) < 2f)
                        {
                            if (Main.rand.Next(25) == 1)
                            {
                                direction.X = direction.X * Main.rand.Next(15, 19);
                                direction.Y = direction.Y * Main.rand.Next(15, 19);
                                npc.velocity.X = direction.X;
                                npc.velocity.Y = direction.Y;
                            }
                        }
                    }
                    #endregion
                    #region Flying Movement
                    if (Math.Sqrt((dist.X * dist.X) + (dist.Y * dist.Y)) < 325)
                    {
                        //literally ripped from dusking :P
                        float speed = expertMode ? 5f : 4.5f; //made more aggressive.  expert mode is more.  dusking base value is 7
                        float acceleration = expertMode ? 0.08f : 0.075f; //made more aggressive.  expert mode is more.  dusking base value is 0.09
                        Vector2 vector2 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        float xDir = player.position.X + (float)(player.width / 2) - vector2.X;
                        float yDir = (float)(player.position.Y + (player.height / 2) - 120) - vector2.Y;
                        float length = (float)Math.Sqrt(xDir * xDir + yDir * yDir);
                        if (length > 400 && expertMode)
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
                            {
                                npc.velocity.X = npc.velocity.X + acceleration;
                            }
                        }
                        else if (npc.velocity.X > xDir)
                        {
                            npc.velocity.X = npc.velocity.X - acceleration;
                            if (npc.velocity.X > 0 && xDir < 0)
                            {
                                npc.velocity.X = npc.velocity.X - acceleration;
                            }
                        }
                        if (npc.velocity.Y < yDir)
                        {
                            npc.velocity.Y = npc.velocity.Y + acceleration;
                            if (npc.velocity.Y < 0 && yDir > 0)
                            {
                                npc.velocity.Y = npc.velocity.Y + acceleration;
                            }
                        }
                        else if (npc.velocity.Y > yDir)
                        {
                            npc.velocity.Y = npc.velocity.Y - acceleration;
                            if (npc.velocity.Y > 0 && yDir < 0)
                            {
                                npc.velocity.Y = npc.velocity.Y - acceleration;
                            }
                        }
                    }
                    #endregion
                    timer += phaseChange ? 2 : 1; //if below 20% life fire more often
                    int shootThings = expertMode ? 250 : 300; //fire more often in expert mode
                    if (timer > shootThings) // Fires prism bolts
                    {
                        direction.Normalize();
                        direction.X *= 8f;
                        direction.Y *= 8f;

                        int amountOfProjectiles = Main.rand.Next(3, 5);
                        int damageAmount = expertMode ? 22 : 33; //always account for expert damage values
                        for (int i = 0; i < amountOfProjectiles; ++i)
                        {
                            float A = (float)Main.rand.Next(-150, 150) * 0.01f;
                            float B = (float)Main.rand.Next(-150, 150) * 0.01f;
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, mod.ProjectileType("PrismaticBoltHostile"), damageAmount, 1, npc.target, 0, 0);
                            timer = 0;
                        }
                    }
                    if (aiChange)
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
            collideTimer++;
            if (collideTimer == 500)
            {
                npc.noTileCollide = true;
            }
            npc.TargetClosest(true);
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -100;
                timer = 0;
            }
            {
                Counter++;
                if (Counter > 400)
                {
                    SpiritMod.shittyModTime = 120;
                    Counter = 0;
                }
                return true;
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
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ArcaneGeyser"), Main.rand.Next(32, 44));
                string[] lootTable = { "KingRock", "Mountain", "TitanboundBulwark", "CragboundStaff", "QuakeFist"};
                int loot = Main.rand.Next(lootTable.Length);
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
            }
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            if (npc.ai[0] < 2)
            {
                return false;
            }
            return base.CanHitPlayer(target, ref cooldownSlot);
        }
    }
}