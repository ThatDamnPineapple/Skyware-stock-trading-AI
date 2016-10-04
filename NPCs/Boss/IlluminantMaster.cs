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
		int shootTimer = 0;
		
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
			
			if (timer >= 500)
			{
				shootTimer++;
			}
				
			if (timer == 75 || timer == 175 || timer == 275 || timer == 375 || timer == 475)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				for (int i = 0; i < 50; ++i)
				{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
				Main.dust[dust].scale = 1.5f;
				}
				npc.velocity.Y = direction.Y * 3f;
				npc.velocity.X = direction.X * 3f;
				npc.position.Y += npc.velocity.Y * 180f;
				npc.position.X += npc.velocity.X * 180f;
				int amountOfProjectiles = Main.rand.Next(10, 15);
				Vector2 direction2 = Main.player[npc.target].Center - npc.Center;
				direction2.Normalize();
				direction2.X *= 15f;
				direction2.Y *= 15f;
				for (int i = 0; i < amountOfProjectiles; ++i)
					{
						float A = (float)Main.rand.Next(-150, 150) * 0.01f;
						float B = (float)Main.rand.Next(-150, 150) * 0.01f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction2.X + A, direction2.Y + B, mod.ProjectileType("CrystalSpike"), 40, 1, Main.myPlayer, 0, 0);
					}
				for (int i = 0; i < 50; ++i)
				{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
				Main.dust[dust].scale = 1.5f;
				}
			}
			
			if (timer == 3 || timer == 100 || timer == 200 || timer == 300 || timer == 400 || timer == 500)
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				npc.velocity.Y = direction.Y * 10f;
				npc.velocity.X = direction.X * 10f;
			}
			
			if (timer <= 500)
			{
				Vector2 newVect = npc.velocity.RotatedBy(System.Math.PI / -200);
				npc.velocity.Y = newVect.Y;
				npc.velocity.X = newVect.X;
			}
			

			if (shootTimer == 30)
			{
				for (int i = 0; i < 50; ++i)
				{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, 62);      
				Main.dust[dust].scale = 1.5f;
				}
				npc.velocity.X = 0f;
				npc.velocity.Y = 0f;
				int p = Main.rand.Next(-250, 250) * 3;
				int o = Main.rand.Next(-100, 100) - 500;
				npc.position.X = player.Center.X + p;
				npc.position.Y = player.Center.Y + o;
				Vector2 shoot = npc.Center + new Vector2(0f, -500f);
				Vector2 direction = player.Center - shoot;
				direction.Normalize();
				direction.X *= 15f;
				direction.Y *= 15f;
				int amountOfProjectiles = Main.rand.Next(10, 15);
				for (int i = 0; i < amountOfProjectiles; ++i)
					{
						float C = (float)Main.rand.Next(-150, 150) * 0.01f;
						float D = (float)Main.rand.Next(-150, 150) * 0.01f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y - 500f, direction.X + C, direction.Y + D, mod.ProjectileType("FaeStar"), 40, 1, Main.myPlayer, 0, 0);
					}
				shootTimer = 0;
			}
					
			if (timer == 1000)	
			{
				timer = 0;
			}				
		}
    }
}