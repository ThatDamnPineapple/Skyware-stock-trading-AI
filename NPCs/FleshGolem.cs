using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class FleshGolem : ModNPC
    {
        int timer = 0;
        int moveSpeed = 0;
        int moveSpeedY = 0;
        private float attackCool
        {
            get
            {
                return npc.ai[0];
            }
            set
            {
                npc.ai[0] = value;
            }
        }
        public override void SetDefaults()
        {
            npc.name = "Flesh Golem";
            npc.displayName = "Flesh Golem";
            npc.width = 70;
            npc.height = 84;
            npc.damage = 30;
            npc.defense = 18;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath2;
            npc.boss = true;
            npc.value = 20060f;
            npc.knockBackResist = .0f;
            npc.aiStyle = 3;
			aiType = NPCID.Skeleton;
			animationType = 415;
            Main.npcFrameCount[npc.type] = 8;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer && (Main.bloodMoon) && NPC.downedBoss2 ? 0.0015f : 0f;
        }
 /*       public override void FindFrame(int frameHeight)
        {
            if (attackCool < 50f)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frame.Y = 0;
            }
        }*/
        public override void AI()
        {
			//npc.spriteDirection = npc.direction;
		//	npc.ai[0]++;
		//	if(npc.ai[0] % 8 == 0) {
		//		npc.frame.Y = (int)(npc.height * npc.frameCounter);
		//		npc.frameCounter = (npc.frameCounter + 1) % 8;
		//	}
            attackCool -= 1f;
            {
                npc.spriteDirection = npc.direction;
                {
                    timer++;
                    if (timer == 150)
                    {
                        int newNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("DeadArcher"), npc.whoAmI);
                    }

                    {
                        if (timer == 300) //sets velocity to 0, creates dust
                        {
                            Vector2 direction = Main.player[npc.target].Center - npc.Center;
                            direction.Normalize();
                            direction.X *= 14f;
                            direction.Y *= 14f;

                            int amountOfProjectiles = Main.rand.Next(3, 6);
                            for (int i = 0; i < amountOfProjectiles; ++i)
                            {
                                float A = (float)Main.rand.Next(-200, 200) * 0.01f;
                                float B = (float)Main.rand.Next(-200, 200) * 0.01f;
                                Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, mod.ProjectileType("Bloodfire"), 14, 1, Main.myPlayer, 0, 0);
                            }
                            if (Main.rand.Next(2) == 0)
                            {
                                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);
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
		public override void NPCLoot()
		{
			int Techs = Main.rand.Next(7,15);
		for (int J = 0; J <= Techs; J++)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodFire"));
			}
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Butcher"));
            }
        }
		public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
			if (npc.life <= 0)
            {
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Flesh_Golem_Head"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Golem_Arm"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Golem_Arm"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Flesh_Golem_gore_1"), 1f);
			}
		}
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("BCorrupt"), 180);
        }
    }
}
