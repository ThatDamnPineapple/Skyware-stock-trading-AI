using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.ReachBoss
{
    public class ReachBoss1 : ModNPC
    {
        int timer = 0;
        int moveSpeed = 0;
        int moveSpeedY = 0;
        float HomeY = 150f;
        bool txt = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vinewrath Husk");
        }
        public override void SetDefaults()
        {
            npc.width = 132;
            npc.height = 222;
            npc.damage = 40;
            npc.lifeMax = 6000;
            npc.knockBackResist = 0;
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 10;
            npc.defense = 7;
            bossBag = mod.ItemType("ReachBossBag");

            npc.buffImmune[20] = true;
            npc.buffImmune[31] = true;
            npc.buffImmune[70] = true;

            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
        }
        private int Counter;
        public override bool PreAI()
        {
            {
                Player player = Main.player[npc.target];
                Counter++;
                if (npc.life >= (npc.lifeMax / 9 * 4))
                {
                    if (npc.Center.X >= player.Center.X && moveSpeed >= -60) // flies to players x position
                    {
                        moveSpeed--;
                    }

                    if (npc.Center.X <= player.Center.X && moveSpeed <= 60)
                    {
                        moveSpeed++;
                    }

                    npc.velocity.X = moveSpeed * 0.1f;

                    if (npc.Center.Y >= player.Center.Y - 60f && moveSpeedY >= -40) //Flies to players Y position
                    {
                        moveSpeedY--;
                    }

                    if (npc.Center.Y <= player.Center.Y - 60f && moveSpeedY <= 40)
                    {
                        moveSpeedY++;
                    }
                }
                else
                {
                    if (npc.Center.X >= player.Center.X && moveSpeed >= -80) // flies to players x position
                    {
                        moveSpeed--;
                    }

                    if (npc.Center.X <= player.Center.X && moveSpeed <= 80)
                    {
                        moveSpeed++;
                    }

                    npc.velocity.X = moveSpeed * 0.1f;

                    if (npc.Center.Y >= player.Center.Y - 60f && moveSpeedY >= -70) //Flies to players Y position
                    {
                        moveSpeedY--;
                    }

                    if (npc.Center.Y <= player.Center.Y - 60 && moveSpeedY <= 70)
                    {
                        moveSpeedY++;
                    }
                }
                npc.velocity.Y = moveSpeedY * 0.1f;

                bool expertMode = Main.expertMode;
                if (Main.rand.Next(170) == 4 && npc.life >= (npc.lifeMax / 9 * 4))
                {
                    Main.PlaySound(6, (int)npc.position.X, (int)npc.position.Y);
                    Vector2 direction = Main.player[npc.target].Center - npc.Center;
                    direction.Normalize();
                    direction.X *= 12f;
                    direction.Y *= 12f;

                    int amountOfProjectiles = 1;
                    for (int i = 0; i < amountOfProjectiles; ++i)
                    {
                        float A = (float)Main.rand.Next(-200, 200) * 0.01f;
                        float B = (float)Main.rand.Next(-200, 200) * 0.01f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, mod.ProjectileType("BouncingSpore"), 28, 1, Main.myPlayer, 0, 0);

                    }
                }
                if (Main.rand.Next(170) == 5 && npc.life >= (npc.lifeMax / 9 * 4))
                {
                    Main.PlaySound(6, (int)npc.position.X, (int)npc.position.Y);
                    Vector2 direction = Main.player[npc.target].Center - npc.Center;
                    direction.Normalize();
                    direction.X *= 14f;
                    direction.Y *= 14f;

                    int amountOfProjectiles = 4;
                    for (int i = 0; i < amountOfProjectiles; ++i)
                    {
                        float A = (float)Main.rand.Next(-200, 200) * 0.07f;
                        float B = (float)Main.rand.Next(-200, 200) * 0.07f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, mod.ProjectileType("BoneBlast"), 24, 1, Main.myPlayer, 0, 0);

                    }
                }
                if (npc.life <= 2800)
                {
                    if (!txt)
                    {
                        Main.NewText("The Bramble shall consume you...", 0, 200, 80, true);
                        npc.velocity *= 0;
                        Main.PlaySound(6, (int)npc.position.X, (int)npc.position.Y);
                        Vector2 direction = Main.player[npc.target].Center - npc.Center;
                        direction.Normalize();
                        direction.X *= 18f;
                        direction.Y *= 18f;

                        int amountOfProjectiles = Main.rand.Next(5, 6);
                        for (int i = 0; i < amountOfProjectiles; ++i)
                        {
                            float A = (float)Main.rand.Next(-300, 300) * 0.01f;
                            float B = (float)Main.rand.Next(-300, 300) * 0.01f;
                            Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, mod.ProjectileType("BouncingSpore"), 30, 1, Main.myPlayer, 0, 0);
                 

                        }
                        txt = true;
                    }
                }
                if (Main.rand.Next(170) == 7 && npc.life <= (npc.lifeMax / 9 * 4))
                {
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 42);
                    Vector2 direction = Main.player[npc.target].Center - npc.Center;
                    direction.Normalize();
                    direction.X *= 12f;
                    direction.Y *= 12f;

                    int amountOfProjectiles = Main.rand.Next(4, 5);
                    for (int i = 0; i < amountOfProjectiles; ++i)
                    {
                        float A = (float)Main.rand.Next(-200, 200) * 0.05f;
                        float B = (float)Main.rand.Next(-200, 200) * 0.05f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, mod.ProjectileType("Yikes"), 21, 1, Main.myPlayer, 0, 0);

                    }
                }
                if (Main.rand.Next(170) == 1 && npc.life <= (npc.lifeMax / 9 * 4))
                {
                    Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 42);
                    Vector2 direction = Main.player[npc.target].Center - npc.Center;
                    direction.Normalize();
                    direction.X *= 12f;
                    direction.Y *= 12f;

                    int amountOfProjectiles = 1;
                    for (int i = 0; i < amountOfProjectiles; ++i)
                    {
                        float A = (float)Main.rand.Next(-200, 200) * 0.05f;
                        float B = (float)Main.rand.Next(-200, 200) * 0.05f;
                        Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 3, 3, mod.ProjectileType("HomingYikes"), 25, 1, Main.myPlayer, 0, 0);

                    }
                }
            }
            return true;
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -200;
            }
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.8f * bossLifeScale);

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
                target.AddBuff(BuffID.Poisoned, 200);
            target.AddBuff(BuffID.Bleeding, 200);
        }
        public override void HitEffect(int hitDirection, double damage)
        {



            for (int i = 0; i < 10; i++) ;
            if (Main.netMode != 1 && npc.life <= 0)
            {
                {
                    for (int num621 = 0; num621 < 20; num621++)
                    {
                        int num622 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 2, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[num622].velocity *= 3f;
                        if (Main.rand.Next(2) == 0)
                        {
                            Main.dust[num622].scale = 0.5f;
                            Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                        }
                    }
                }
            }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }
        public override void NPCLoot()
        { 
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReachFlower"), Main.rand.Next(25, 36));
                string[] lootTable = { "ThornBow", "SunbeamStaff", "ReachVineStaff", "ReachBossSword", "ReachKnife" };
                int loot = Main.rand.Next(lootTable.Length);
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
                }

            }
            MyWorld.downedReachBoss = true;
        }
    }
}
   