using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Tide
{
    public class MindFlayer : ModNPC
    {
        int timer = 0;
        int moveSpeed = 0;
        int moveSpeedY = 0;

        public override void SetDefaults()
        {
            npc.name = "Mind Flayer";
            npc.displayName = "Mind Flayer";
            npc.width = 48;
            npc.height = 54;
            npc.damage = 20;
            npc.defense = 8;
            npc.lifeMax = 70;
            npc.HitSound = SoundID.NPCHit25;
            npc.DeathSound = SoundID.NPCDeath28;
            npc.value = 929f;
            npc.knockBackResist = 0f;
            npc.aiStyle = 3;
            aiType = NPCID.CyanBeetle;
            Main.npcFrameCount[npc.type] = 9;

        }
        public override void NPCLoot()
        {
            InvasionWorld.invasionSize -= 1;
            if (InvasionWorld.invasionSize < 0)
                InvasionWorld.invasionSize = 0;
            if (Main.netMode != 1)
                InvasionHandler.ReportInvasionProgress(InvasionWorld.invasionSizeStart - InvasionWorld.invasionSize, InvasionWorld.invasionSizeStart, 0);
            if (Main.netMode != 2)
                return;
            NetMessage.SendData(78, -1, -1, "", InvasionWorld.invasionProgress, (float)InvasionWorld.invasionProgressMax, (float)Main.invasionProgressIcon, 0.0f, 0, 0, 0);
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            if (InvasionWorld.invasionType == SpiritMod.customEvent)
                return 1.4f;

            return 0;
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.25f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        private int Counter;
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
            {
                timer++;
                if (timer == 100 || timer == 200)
                {

                }

                {
                    if (timer >= 300) //sets velocity to 0, creates dust
                    {
                        npc.velocity.X = 0f;
                        npc.velocity.Y = 0f;
                        npc.spriteDirection = npc.direction;
                        Counter++;
                        if (Counter > 33)
                        {
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 14f, mod.ProjectileType("Flay"), 10, 1, Main.myPlayer, 0, 0);
                            Counter = 0;
                        }

                        if (Main.rand.Next(2) == 0)
                        {
                            int dust = Dust.NewDust(npc.position, npc.width, npc.height, 187);
                            Main.dust[dust].scale = 2f;
                        }
                    }
                    if (timer >= 350)
                    {
                        timer = 0;
                    }
                }
            }
        }
    }
}

