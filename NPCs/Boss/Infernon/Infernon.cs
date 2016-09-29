using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Infernon
{
    public class Infernon : ModNPC
    {
        public int currentSpread;

        public override void SetDefaults()
        {
            npc.name = "Infernon";
            npc.width = 130;
            npc.height = 140;
			bossBag = mod.ItemType("InfernonBag");
            npc.damage = 36;
            npc.defense = 13;
            npc.lifeMax = 17000;
            npc.knockBackResist = 0;

            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;

            npc.npcSlots = 5;

            npc.soundHit = 7;
            npc.soundKilled = 5;

            Main.npcFrameCount[npc.type] = 7;
        }

        public override bool PreAI()
        {
            if (!NPC.AnyNPCs(mod.NPCType("InfernonSkull")))
            {
                if (Main.expertMode || npc.life <= 7000)
                {
                    NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("InfernonSkull"), 0, 2, 1, 0, npc.whoAmI, npc.target);
                }
            }

            if (npc.ai[0] == 0)
            {
                // Get the proper direction to move towards the current targeted player.
                if (npc.ai[2] == 0)
                {
                    npc.TargetClosest(true);
                    npc.ai[2] = npc.Center.X >= Main.player[npc.target].Center.X ? -1f : 1f;
                }
                npc.TargetClosest(true);

                Player player = Main.player[npc.target];

                float currentXDist = Math.Abs(npc.Center.X - player.Center.X);
                if (npc.Center.X < player.Center.X && npc.ai[2] < 0)
                    npc.ai[2] = 0;
                if (npc.Center.X > player.Center.X && npc.ai[2] > 0)
                    npc.ai[2] = 0;

                float accelerationSpeed = 0.1F;
                float maxXSpeed = 7;

                npc.velocity.X = npc.velocity.X + npc.ai[2] * accelerationSpeed;
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -maxXSpeed, maxXSpeed);

                float yDist = player.position.Y - (npc.position.Y + npc.height);
                if (yDist < 0)
                    npc.velocity.Y = npc.velocity.Y - 0.2F;
                if (yDist > 150)
                    npc.velocity.Y = npc.velocity.Y + 0.2F;
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -6, 6);

                npc.rotation = npc.velocity.X * 0.03f;

                // If the NPC is close enough
                if ((currentXDist < 500 || npc.ai[3] < 0) && npc.position.Y < player.position.Y)
                {
                    ++npc.ai[3];
                    int cooldown = 13;
                    if (npc.life < npc.lifeMax * 0.75)
                        cooldown = 12;
                    if (npc.life < npc.lifeMax * 0.5)
                        cooldown = 11;
                    if (npc.life < npc.lifeMax * 0.25)
                        cooldown = 10;
                    cooldown++;
                    if (npc.ai[3] > cooldown)
                        npc.ai[3] = -cooldown;

                    if (npc.ai[3] == 0 && Main.netMode != 1)
                    {
                        Vector2 position = npc.Center;
                        position.X += npc.velocity.X * 7;

                        float speedX = player.Center.X - npc.Center.X;
                        float speedY = player.Center.Y - npc.Center.Y;
                        float length = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
                        float speed = 6;
                        if (npc.life < npc.lifeMax * 0.75)
                            speed = 7f;
                        if (npc.life < npc.lifeMax * 0.5)
                            speed = 8f;
                        if (npc.life < npc.lifeMax * 0.25)
                            speed = 9f;
                        float num12 = speed / length;
                        speedX = speedX * num12;
                        speedY = speedY * num12;
                        Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("InfernalWave"), Main.expertMode ? 52 : 28, 0, Main.myPlayer);
                    }
                }
                else if (npc.ai[3] < 0)
                    npc.ai[3]++;

                if (Main.netMode != 1)
                {
                    npc.ai[1] += Main.rand.Next(1, 4);
                    if (npc.ai[1] > 800 && currentXDist < 600)
                        npc.ai[0] = -1;
                }
            }
            if (npc.ai[0] == 1)
            {
                if (npc.ai[2] == 0)
                {
                    npc.TargetClosest(true);
                    npc.ai[2] = npc.Center.X >= Main.player[npc.target].Center.X ? -1f : 1f;
                }
                npc.TargetClosest(true);
                Player player = Main.player[npc.target];

                float currentXDist = Math.Abs(npc.Center.X - player.Center.X);
                if (npc.Center.X < player.Center.X && npc.ai[2] < 0)
                    npc.ai[2] = 0;
                if (npc.Center.X > player.Center.X && npc.ai[2] > 0)
                    npc.ai[2] = 0;

                float accelerationSpeed = 0.1F;
                float maxXSpeed = 7;

                npc.velocity.X = npc.velocity.X + npc.ai[2] * accelerationSpeed;
                npc.velocity.X = MathHelper.Clamp(npc.velocity.X, -maxXSpeed, maxXSpeed);

                float yDist = player.position.Y - (npc.position.Y + npc.height);
                if (yDist < 0)
                    npc.velocity.Y = npc.velocity.Y - 0.2F;
                if (yDist > 150)
                    npc.velocity.Y = npc.velocity.Y + 0.2F;
                npc.velocity.Y = MathHelper.Clamp(npc.velocity.Y, -6, 6);
                
                npc.rotation = npc.velocity.X * 0.03f;

                if (Main.netMode != 1)
                {
                    npc.ai[3]++;

                    if (npc.ai[3] % 5 == 0 && npc.ai[3] <= 25)
                    {
                        Vector2 pos = new Vector2(npc.Center.X, (npc.position.Y + npc.height - 14));
                        if (!WorldGen.SolidTile((int)(pos.X / 16), (int)(pos.Y / 16)))
                        {
                            Vector2 dir = player.Center - pos;
                            dir.Normalize();
                            dir *= 12;
                            Projectile.NewProjectile(pos.X, pos.Y, dir.X, dir.Y, mod.ProjectileType("FireSpike"), Main.expertMode ? 47 : 24, 0.4F, Main.myPlayer, Main.rand.Next(5));
                            currentSpread++;
                        }
                    }

                    int cooldown = 60;
                    if (npc.life < npc.lifeMax * 0.75)
                        cooldown = 50;
                    if (npc.life < npc.lifeMax * 0.5)
                        cooldown = 40;
                    if (npc.life < npc.lifeMax * 0.25)
                        cooldown = 30;
                    if (npc.life < npc.lifeMax * 0.1)
                        cooldown = 25;
                    if (npc.ai[3] >= cooldown)
                        npc.ai[3] = 0;

                    npc.ai[1] += Main.rand.Next(1, 4);
                    if (npc.ai[1] > 600.0)
                        npc.ai[0] = -1f;
                }
            }
            if (npc.ai[0] == 2)
            {
                if (npc.velocity.X > 0) npc.velocity.X -= 0.1F;
                if (npc.velocity.X < 0) npc.velocity.X += 0.1F;
                if (npc.velocity.X > -0.2F && npc.velocity.X < 0.2F) npc.velocity.X = 0;
                if (npc.velocity.Y > 0) npc.velocity.Y -= 0.1F;
                if (npc.velocity.Y < 0) npc.velocity.Y += 0.1F;
                if (npc.velocity.Y > -0.2F && npc.velocity.Y < 0.2F) npc.velocity.Y = 0;

                npc.rotation = npc.velocity.X * 0.03F;

                npc.ai[3]++;

                if (npc.ai[3] >= 60)
                {
                    if (npc.ai[3] % 20 == 0)
                    {

                        Vector2 direction = Vector2.One.RotatedByRandom(MathHelper.ToRadians(360));
                        int newNPC = NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, mod.NPCType("InfernonSkullMini"));
                        Main.npc[newNPC].velocity = direction * 8;
                    }
                    // Shoot mini skulls.
                }

                if (Main.netMode != 1)
                {
                    npc.ai[1] += Main.rand.Next(1, 4);
                    if (npc.ai[1] > 500)
                        npc.ai[0] = -1f;
                }
            }
            if (npc.ai[0] == 3)
            {
                npc.velocity.Y -= 0.1F;
                npc.alpha += 2;
                if (npc.alpha >= 255)
                    npc.active = false;
                if (npc.velocity.X > 0) npc.velocity.X -= 0.2F;
                if (npc.velocity.X < 0) npc.velocity.X += 0.2F;
                if (npc.velocity.X > -0.2F && npc.velocity.X < 0.2F) npc.velocity.X = 0;

                npc.rotation = npc.velocity.X * 0.03f;
            }

            if (!Main.player[npc.target].active || Main.player[npc.target].dead)
            {
                npc.TargetClosest(true);
                if (!Main.player[npc.target].active || Main.player[npc.target].dead)
                {
                    npc.ai[0] = 3;
                    npc.ai[3] = 0;
                }
            }

            if (npc.ai[0] != -1)
                return false;
            int num = Main.rand.Next(3);
            npc.TargetClosest(true);
            if (Math.Abs(npc.Center.X - Main.player[npc.target].Center.X) > 1000)
                num = 0;
            npc.ai[0] = num;
            npc.ai[1] = 0;
            npc.ai[2] = 0;
            npc.ai[3] = 0;

            return false;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.ai[0] == 0)
                npc.frame.Y = npc.ai[3] < 0.0 ? (npc.velocity.X >= 0.0 ? frameHeight * 2 : frameHeight) : 0;
            else if (npc.ai[0] == 1)
            {
                if (npc.ai[3] <= 25)
                {
                    ++npc.frameCounter;
                    if (npc.frameCounter > 5.0)
                    {
                        npc.frameCounter = 0.0;
                        npc.frame.Y = npc.frame.Y + frameHeight;
                    }
                    if (npc.frame.Y > frameHeight * 4)
                        npc.frame.Y = frameHeight * 3;
                    if (npc.frame.Y < frameHeight * 3)
                        npc.frame.Y = frameHeight * 3;
                }
                else
                    npc.frame.Y = 0;
            }
            else if (npc.ai[0] == 2 || npc.ai[0] == 3)
            {
                npc.frame.Y = 5 * frameHeight;
            }
        }

        public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
			int Techs = Main.rand.Next(25, 36);
		for (int J = 0; J <= Techs; J++)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("InfernalAppendage"));
			}
			string[] lootTable = { "InfernalJavelin", "InfernalSword", "InfernalStaff", };
			int loot = Main.rand.Next(lootTable.Length);
			 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
                
			}
		}

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;
        }
    }
}
