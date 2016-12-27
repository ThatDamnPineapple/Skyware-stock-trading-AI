using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Overseer
{
    public class Overseer : ModNPC
    {
        bool secondphase = false;
        int movementCounter;
        public override void SetDefaults()
        {
            npc.name = "Overseer";
            npc.width = 148;
            npc.height = 172;

            npc.damage = 110;
            npc.defense = 55;
            npc.lifeMax = 125000;
            npc.knockBackResist = 0;

            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 10;

            npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath5;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Overseer");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override bool PreAI()
        {
            npc.TargetClosest(true);
            Player player10 = Main.player[npc.target];
            if (!player10.active || player10.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -50; 
            }
            Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0.0f, 0.04f, 0.8f);
            if (npc.ai[0] == 0)
            {
                if (npc.life > (npc.lifeMax / 2))
                {
                    #region ai phase 1
                    movementCounter++;
                    npc.TargetClosest(true);
                    if (movementCounter < 800)
                    {
                        Vector2 direction = Main.player[npc.target].Center - npc.Center;
                        direction.Normalize();
                        npc.velocity *= 0.985f;
                        int dust2 = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                        Main.dust[dust2].noGravity = true;
                        if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) >= 7f)
                        {
                            int dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                            Main.dust[dust].noGravity = true;
                            Main.dust[dust].scale = 2f;
                            dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                            Main.dust[dust].noGravity = true;
                            Main.dust[dust].scale = 2f;
                        }
                        if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) < 13f)
                        {
                            if (Main.rand.Next(18) == 1)
                            {
                                direction.X = direction.X * Main.rand.Next(25, 28);
                                direction.Y = direction.Y * Main.rand.Next(25, 28);
                                npc.velocity.X = direction.X;
                                npc.velocity.Y = direction.Y;
                            }
                        }
                        //   if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) < 10f)
                        // {
                        //       if (Main.rand.Next(18) == 1)
                        //       {
                        //          direction.X = direction.X * Main.rand.Next(20, 23);
                        //          direction.Y = direction.Y * Main.rand.Next(20, 23);
                        //          npc.velocity.X = direction.X;
                        //          npc.velocity.Y = direction.Y;
                        //     }
                        // }
                        if (movementCounter % 150 == 50)
                        {
                            Vector2 direction9 = Main.player[npc.target].Center - npc.Center;
                            direction9.Normalize();
                            direction9.X *= 15f;
                            direction9.Y *= 15f;

                            int amountOfProjectiles = Main.rand.Next(7, 11);
                            for (int i = 0; i < amountOfProjectiles; ++i)
                            {
                                float A = (float)Main.rand.Next(-250, 250) * 0.01f;
                                float B = (float)Main.rand.Next(-250, 250) * 0.01f;
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction9.X + A, direction9.Y + B, mod.ProjectileType("CoreShard"), 120, 1, Main.myPlayer, 0, 0);
                            }
                        }
                    }
                    if (movementCounter == 800)
                    {
                        npc.velocity.X = 0;
                        npc.velocity.Y = 0;
                    }
                    if (movementCounter > 800)
                    {
                        if (movementCounter % 100 == 50)
                        {
                            Vector2 direction8 = Main.player[npc.target].Center - npc.Center;
                            direction8.Normalize();
                            direction8.X *= 28f;
                            direction8.Y *= 28f;

                            int amountOfProjectiles = Main.rand.Next(10, 15);
                            for (int i = 0; i < amountOfProjectiles; ++i)
                            {
                                float A = (float)Main.rand.Next(-250, 250) * 0.01f;
                                float B = (float)Main.rand.Next(-250, 250) * 0.01f;
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction8.X + A, direction8.Y + B, mod.ProjectileType("SpiritShard"), 80, 1, Main.myPlayer, 0, 0);
                            }
                        }
                        float speed = 15f;
                        float acceleration = 0.15f;
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
                                acceleration += 0.08F;
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
                    }
                    if (movementCounter > 1400)
                    {
                        movementCounter = 0;
                    }
                    #endregion
                }
                if (npc.life <= (npc.lifeMax / 2))
                {
                    #region Ai phase 2
                    if (!secondphase)
                    {
                        Main.NewText("BEHOLD MY TRUE POWER", 0, 80, 200, true);
                        secondphase = true;
                    }
                    movementCounter++;
                    npc.TargetClosest(true);
                    if (movementCounter < 800)
                    {
                        if (movementCounter % 120 == 50)
                        {
                            Vector2 direction9 = Main.player[npc.target].Center - npc.Center;
                            direction9.Normalize();
                            direction9.X *= 16f;
                            direction9.Y *= 16f;

                            int amountOfProjectiles = Main.rand.Next(7, 11);
                            for (int i = 0; i < amountOfProjectiles; ++i)
                            {
                                float A = (float)Main.rand.Next(-250, 250) * 0.01f;
                                float B = (float)Main.rand.Next(-250, 250) * 0.01f;
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction9.X + A, direction9.Y + B, mod.ProjectileType("CoreShard"), 130, 1, Main.myPlayer, 0, 0);
                            }
                        }
                        Vector2 direction = Main.player[npc.target].Center - npc.Center;
                        direction.Normalize();
                        npc.velocity *= 0.983f;
                        int dust2 = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                        Main.dust[dust2].noGravity = true;
                        if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) >= 7f)
                        {
                            int dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                            Main.dust[dust].noGravity = true;
                            Main.dust[dust].scale = 2f;
                            dust = Dust.NewDust(npc.position + npc.velocity, npc.width, npc.height, 206, npc.velocity.X * 0.5f, npc.velocity.Y * 0.5f);
                            Main.dust[dust].noGravity = true;
                            Main.dust[dust].scale = 2f;
                        }
                        if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) < 14f)
                        {
                            if (Main.rand.Next(18) == 1)
                            {
                                direction.X = direction.X * Main.rand.Next(30, 36);
                                direction.Y = direction.Y * Main.rand.Next(30, 36);
                                npc.velocity.X = direction.X;
                                npc.velocity.Y = direction.Y;
                            }
                        }
                        //   if (Math.Sqrt((npc.velocity.X * npc.velocity.X) + (npc.velocity.Y * npc.velocity.Y)) < 10f)
                        // {
                        //       if (Main.rand.Next(18) == 1)
                        //       {
                        //          direction.X = direction.X * Main.rand.Next(20, 23);
                        //          direction.Y = direction.Y * Main.rand.Next(20, 23);
                        //          npc.velocity.X = direction.X;
                        //          npc.velocity.Y = direction.Y;
                        //     }
                        // }
                    }
                    if (movementCounter == 800) //spawn portals
                    {
                        npc.velocity.X = 0;
                        npc.velocity.Y = 0;
                        
                    }



                    if (movementCounter > 800)
                    {
                        if (movementCounter % 75 == 50)
                        {
                            Vector2 direction8 = Main.player[npc.target].Center - npc.Center;
                            direction8.Normalize();
                            direction8.X *= 24f;
                            direction8.Y *= 28f;

                            int amountOfProjectiles = Main.rand.Next(10, 15);
                            for (int i = 0; i < amountOfProjectiles; ++i)
                            {
                                float A = (float)Main.rand.Next(-350, 350) * 0.01f;
                                float B = (float)Main.rand.Next(-350, 350) * 0.01f;
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction8.X + A, direction8.Y + B, mod.ProjectileType("SpiritShard"), 87, 1, npc.target, 0, 0);
                            }
                        }
                        float speed = 17f;
                        float acceleration = 0.17f;
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
                                acceleration += 0.08F;
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
                    }
                    if (movementCounter > 1600)
                    {
                        for (int I = 0; I < 2; I++)
                        {
                            //cos = y, sin = x
                            int portal = Projectile.NewProjectile((int)(Main.player[npc.target].Center.X + (Math.Sin(I * 180) * 500)), (int)(Main.player[npc.target].Center.Y + (Math.Cos(I * 180) * 500)), 0, 0, mod.ProjectileType("SpiritPortal"), npc.damage, 1, npc.target, 0, 0);
                            Projectile Eye = Main.projectile[portal];
                            Eye.ai[0] = I * 180;
                        }
                        movementCounter = 0;
                    }
                    #endregion
                }
                npc.ai[1]++;
                if (npc.ai[1] >= 180)
                {
                    npc.TargetClosest(true);

                    Vector2 dir = Main.player[npc.target].Center - npc.Center;
                    dir.Normalize();
                    dir *= 8;
                    Projectile.NewProjectile(npc.Center.X, npc.Center.Y, dir.X, dir.Y, mod.ProjectileType("HauntedWisp"), 10, 0, Main.myPlayer);

                    npc.ai[1] = 0;
                }
            }
            return false;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("SoulFlare"), 150);
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter >= 5)
            {
                npc.frame.Y = (npc.frame.Y + frameHeight) % (Main.npcFrameCount[npc.type] * frameHeight);
                npc.frameCounter = 0;
            }
        }
    }
}
