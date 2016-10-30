using Terraria;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss
{
    public class IlluminantMaster : ModNPC
    {
		int timer = 0;
		int teleportTimer = 0;
		
        public override void SetDefaults()
        {
            npc.name = "Illuminant Master";
            npc.displayName = "Illuminant Master";
            npc.width = 130;
            npc.height = 154;
            npc.damage = 32;
			npc.noTileCollide = true;
			bossBag = mod.ItemType("IlluminantBag");
            npc.defense = 34;
			npc.boss = true;
            npc.lifeMax = 22000;
            npc.soundHit = 1;
            npc.soundKilled = 1;
			npc.noGravity = true;
            npc.value = 60f;
            npc.knockBackResist = 0f;
            Main.npcFrameCount[npc.type] = 7;
			npc.aiStyle = -1;
     
        }
		public override void NPCLoot()
		{
			if (Main.expertMode)
			{
				npc.DropBossBags();
			}
			else
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IlluminatedCrystal"), Main.rand.Next(32,44));
			string[] lootTable = { "SylphBow", "FairystarStaff", "FaeSaber", };
			int loot = Main.rand.Next(lootTable.Length);
			 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
                
			}
		}
		public override void AI()
        {
			npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -50;
				timer = 0;
            }
			
			timer++;
			teleportTimer++;
			
			if (timer == 150) //First Teleport
			{
				for (int i = 0; i < 50; ++i) //Create dust before teleport
					{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
					Main.dust[dust].scale = 1.5f;
					}
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("FaeDetonator"), 20, 1, Main.myPlayer, 0, 0); //Make projectilllllelelelelele
				npc.position.X = player.position.X + 500f; //Teleport in a corner of the screen
				npc.position.Y = player.position.Y + 500f; //Moves to you
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				npc.velocity.Y = direction.Y * 9f;
				npc.velocity.X = direction.X * 9f;
				
				for (int i = 0; i < 50; ++i) //Create dust after teleport
					{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
					Main.dust[dust].scale = 1.5f;
					}
			}

			if (timer == 300) //Second Teleport
			{
				for (int i = 0; i < 50; ++i) //Create dust before teleport
					{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
					Main.dust[dust].scale = 1.5f;
					}
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("FaeDetonator"), 20, 1, Main.myPlayer, 0, 0); //Make projectilllllelelelelele
				npc.position.X = player.position.X - 500f; //Teleport in a corner of the screen
				npc.position.Y = player.position.Y + 500f;
				Vector2 direction = Main.player[npc.target].Center - npc.Center;//Moves to you
				direction.Normalize();
				npc.velocity.Y = direction.Y * 9f;
				npc.velocity.X = direction.X * 9f;
				
				for (int i = 0; i < 50; ++i) //Create dust after teleport
					{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
					Main.dust[dust].scale = 1.5f;
					}
			}

			if (timer == 450) //Third Teleport
			{
				for (int i = 0; i < 50; ++i) //Create dust before teleport
					{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
					Main.dust[dust].scale = 1.5f;
					}
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("FaeDetonator"), 20, 1, Main.myPlayer, 0, 0); //Make projectilllllelelelelele
				npc.position.X = player.position.X + 500f; //Teleport in a corner of the screen
				npc.position.Y = player.position.Y - 500f;
				Vector2 direction = Main.player[npc.target].Center - npc.Center;//Moves to you
				direction.Normalize();
				npc.velocity.Y = direction.Y * 9f;
				npc.velocity.X = direction.X * 9f;
				
				for (int i = 0; i < 50; ++i) //Create dust after teleport
					{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
					Main.dust[dust].scale = 1.5f;
					}
			}

			if (timer == 600) //Fourth Teleport
			{
				for (int i = 0; i < 50; ++i) //Create dust before teleport
					{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
					Main.dust[dust].scale = 1.5f;
					}
				Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("FaeDetonator"), 20, 1, Main.myPlayer, 0, 0); //Make projectilllllelelelelele
				npc.position.X = player.position.X - 500f; //Teleport in a corner of the screen
				npc.position.Y = player.position.Y - 500f;
				Vector2 direction = Main.player[npc.target].Center - npc.Center; //Moves to you
				direction.Normalize();
				npc.velocity.Y = direction.Y * 9f;
				npc.velocity.X = direction.X * 9f;
				
				for (int i = 0; i < 50; ++i) //Create dust after teleport
					{
					int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
					Main.dust[dust].scale = 1.5f;
					}
			}

			if (Main.rand.Next(30) == 0 && timer <= 600) //Random fae stars
				{
					int A = Main.rand.Next(-250, 250) * 5;
					int B = Main.rand.Next(-100, 100) - 2000;
					Projectile.NewProjectile(player.Center.X + A, player.Center.Y + B, 0f, 10f, mod.ProjectileType("FaeStar"), 20, 1, Main.myPlayer, 0, 0);
				}
			
			if (Main.rand.Next(30) == 0 && timer <= 600)
				{
					int A = Main.rand.Next(-250, 250) * 5;
					int B = Main.rand.Next(-100, 100) + 2000;
					Projectile.NewProjectile(player.Center.X + A, player.Center.Y + B, 0f, -10f, mod.ProjectileType("FaeStar"), 20, 1, Main.myPlayer, 0, 0);
				}
				
			if (Main.rand.Next(30) == 0 && timer <= 600)
				{
					int A = Main.rand.Next(-100, 100) + 2000;
					int B = Main.rand.Next(-250, 250) * 5;
					Projectile.NewProjectile(player.Center.X + A, player.Center.Y + B, -10f, 0f, mod.ProjectileType("FaeStar"), 20, 1, Main.myPlayer, 0, 0);
				}
				
			if (Main.rand.Next(30) == 0 && timer <= 600)
				{
					int A = Main.rand.Next(-100, 100) - 2000;
					int B = Main.rand.Next(-250, 250) * 5;
					Projectile.NewProjectile(player.Center.X + A, player.Center.Y + B, 10f, 0f, mod.ProjectileType("FaeStar"), 20, 1, Main.myPlayer, 0, 0);
				} // End of random fae stars
				
				
				if (teleportTimer >= 80 && timer >= 600) //Phase 2 boiiiiii
					{
						for (int i = 0; i < 50; ++i)
						{
						int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
						Main.dust[dust].scale = 1.5f;
						}
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0f, 0f, mod.ProjectileType("FaeDetonator"), 20, 1, Main.myPlayer, 0, 0); //DETONATE ME
						npc.velocity.X = 0f;
						npc.velocity.Y = 0f;
						int A = Main.rand.Next(-250, 250) * 3;
						int B = Main.rand.Next(-100, 100) - 400;
						npc.position.X = player.Center.X + A;
						npc.position.Y = player.Center.Y + B;
						teleportTimer = 0;
						for (int i = 0; i < 5; ++i)
						{
							Vector2 direction = Main.player[npc.target].Center - npc.Center;
							direction.Normalize();
							float sX = direction.X * 10f;
							float sY = direction.Y * 10f;
							sX += (float)Main.rand.Next(-60, 61) * 0.08f;
							sY += (float)Main.rand.Next(-60, 61) * 0.08f;
							Projectile.NewProjectile(npc.Center.X, npc.Center.Y, sX, sY, mod.ProjectileType("CrystalSpike"), 20, 1, Main.myPlayer, 0, 0);
						}
					}
					
				if (timer == 1200)
				{
					timer = 0;
				}
		}
    }
}