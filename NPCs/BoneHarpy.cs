using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class BoneHarpy : ModNPC
    {
		int moveSpeed = 0;
		int moveSpeedY = 0;
		float HomeY = 150f;

        public override void SetDefaults()
        {
            npc.name = "Bone Harpy";
            npc.width = 98;
            npc.height = 92;
            npc.damage = 25;
            npc.defense = 10;
            npc.lifeMax = 300;
            npc.noGravity = true;
            npc.noTileCollide = false;
            npc.HitSound = SoundID.NPCHit7;
			npc.DeathSound = SoundID.NPCDeath5;
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void AI()
        {
			npc.spriteDirection = npc.direction;
			Player player = Main.player[npc.target];
				if (npc.Center.X >= player.Center.X && moveSpeed >= -53) // flies to players x position
				{
					moveSpeed--;
				}
					
				if (npc.Center.X <= player.Center.X && moveSpeed <= 53)
				{
					moveSpeed++;
				}
				
				npc.velocity.X = moveSpeed * 0.1f;
				
				if (npc.Center.Y >= player.Center.Y - HomeY && moveSpeedY >= -30) //Flies to players Y position
				{
					moveSpeedY--;
					HomeY = 150f;
				}
					
				if (npc.Center.Y <= player.Center.Y - HomeY && moveSpeedY <= 30)
				{
					moveSpeedY++;
				}
				
				npc.velocity.Y = moveSpeedY * 0.1f;
			if (Main.rand.Next(220) == 6)
			{
				HomeY = -35f;
			}
			if (Main.rand.Next(150) == 6) //Fires desert feathers like a shotgun
			{
				Vector2 direction = Main.player[npc.target].Center - npc.Center;
				direction.Normalize();
				direction.X *= 14f;
				direction.Y *= 14f;
				
				int amountOfProjectiles = Main.rand.Next(3, 5);
				for (int i = 0; i < amountOfProjectiles; ++i)
				{
						float A = (float)Main.rand.Next(-150, 150) * 0.01f;
						float B = (float)Main.rand.Next(-150, 150) * 0.01f;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X + A, direction.Y + B, mod.ProjectileType("DesertFeather"), 25, 1, Main.myPlayer, 0, 0);
				}
			}
			
        }
		public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.sky && NPC.downedBoss3  ? 0.3f : 0f;
        }
		public override void NPCLoot()
		{
			if (Main.rand.Next(10) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("JewelCrown"));
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
