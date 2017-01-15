using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss
{
    public class AncientFlyer : ModNPC
    {
        int timer = 0;
		int moveSpeed = 0;
		int moveSpeedY = 0;

        public override void SetDefaults()
        {
            npc.name = "Ancient Flyer";
            npc.width = 168;
            npc.height = 82;
            npc.damage = 22;
            npc.defense = 13;
            npc.lifeMax = 3200;
            npc.knockBackResist = 0;
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.npcSlots = 5;
			bossBag = mod.ItemType("FlyerBag");
            npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath5;
            Main.npcFrameCount[npc.type] = 4;
			npc.scale = 1.1f;
        }
        public override void AI()
        {
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
				if (npc.Center.X >= player.Center.X && moveSpeed >= -100) // flies to players x position
				{
					moveSpeed--;
				}
					
				if (npc.Center.X <= player.Center.X && moveSpeed <= 100)
				{
					moveSpeed++;
				}
				
				npc.velocity.X = moveSpeed * 0.1f;
				
				if (npc.Center.Y >= player.Center.Y - 300f && moveSpeedY >= -30) //Flies to players Y position
				{
					moveSpeedY--;
				}
					
				if (npc.Center.Y <= player.Center.Y - 300f && moveSpeedY <= 30)
				{
					moveSpeedY++;
				}
				
				npc.velocity.Y = moveSpeedY * 0.1f;
			
			timer++;
			if (timer == 200 || timer == 300 || timer == 400 || timer == 500 || timer == 600) //Fires desert feathers like a shotgun
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				direction.X *= 14f;
				direction.Y *= 14f;
				
				int amountOfProjectiles = Main.rand.Next(10, 15);
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
						float A = (float)Main.rand.Next(-150, 150) * 0.01f;
						float B = (float)Main.rand.Next(-150, 150) * 0.01f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, mod.ProjectileType("DesertFeather"), 16, 1, Main.myPlayer, 0, 0);
				}
			}
			
						if (timer == 700 || timer == 750 || timer == 800 || timer == 850 || timer == 900 || timer == 950 || timer == 1000 || timer == 1050 || timer == 1100 || timer == 1150 || timer == 1200 || timer == 1250) // Fires bone waves
			{
					Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X * 10f, direction.Y * 10f, mod.ProjectileType("BoneWave"), 18, 1, Main.myPlayer, 0, 0);
			}
			
			if (timer >= 1200 && timer <= 1600) //Rains red comets
			{
				if (Main.rand.Next(10) == 0)
				{
					int A = Main.rand.Next(-250, 250) * 5;
					int B = Main.rand.Next(-100, 100) - 2000;
					Projectile.NewProjectile(player.Center.X + A, player.Center.Y + B, 0f, 14f, mod.ProjectileType("RedComet"), 12, 1, Main.myPlayer, 0, 0);
				}
			}
			if (timer >= 1300) //sets velocity to 0, creates dust
			{
				npc.velocity.X = 0f;
				npc.velocity.Y = 0f;
				
			if (Main.rand.Next(2) == 0)
            {
                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 60);      
				Main.dust[dust].scale = 2f;		
            }
			
			}
			if (timer >= 1800)
			{
				timer = 0;
			}
			
			if (Main.expertMode && npc.life <= 3000) //Fires comets when low on health in expert
			{
				if (Main.rand.Next(30) == 0)
				{
					int A = Main.rand.Next(-250, 250) * 5;
					int B = Main.rand.Next(-100, 100) - 2000;
					Projectile.NewProjectile(player.Center.X + A, player.Center.Y + B, 0f, 14f, mod.ProjectileType("RedComet"), 20, 1, Main.myPlayer, 0, 0);
				}
			}
			
				if (!player.active || player.dead) //despawns when player is ded
            {
                npc.TargetClosest(false);
                npc.velocity.Y = -50;
				timer = 0;
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
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Talon"), Main.rand.Next(32,44));
			string[] lootTable = { "TalonBlade", "Talonshot", "TalonPiercer", "TalonBurst","SkeletalonStaff" };
			int loot = Main.rand.Next(lootTable.Length);
			 Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType(lootTable[loot]));
                
			}
		}
		public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
			if (npc.life <= 0)
            {
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore3"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Gore4"), 1f);
            }
        }
		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter += 0.25f; 
			npc.frameCounter %= Main.npcFrameCount[npc.type]; 
			int frame = (int)npc.frameCounter; 
			npc.frame.Y = frame * frameHeight; 
		}
    }
}
