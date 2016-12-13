using Terraria;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss
{
    public class Argargothicon : ModNPC
    {
		private float XSpeed;
		private float YSpeed;
        public override void SetDefaults()
        {
            npc.name = "Argargothicon";
            npc.displayName = "Argargothicon, the Demon of the Dungeon";
            npc.width = 403;
            npc.height = 420;
            npc.damage = 32;
			npc.noTileCollide = true;
            npc.defense = 120;
			npc.boss = true;
            npc.lifeMax = 33000;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.noGravity = true;
            npc.value = 60f;
            npc.knockBackResist = 0f;
     
        }
		public override void AI()
		{
					npc.TargetClosest(true);
			Player player = Main.player[npc.target];
Vector2 direction = player.Center - npc.Center;
float desiredRotation = direction.ToRotation();
npc.rotation = desiredRotation;
Point center = npc.Center.ToTileCoordinates();
Lighting.AddLight(center.X, center.Y, 0f, 0.9058f, 0.7843f);
    {
	
	if (npc.life <= 11000)
	{
		Vector2 moveTo = player.Center + new Vector2(0f, 0f); //This is 200 pixels above the center of the player.
			float speed = 13f;
			Vector2 move = moveTo - npc.Center;
			float magnitude = (float) Math.Sqrt(move.X * move.X + move.Y * move.Y);
			if(magnitude > speed)
				{
   				 move *= speed / magnitude;
				}
			float turnResistance = 5f; //the larger this is, the slower the npc will turn
			move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
			magnitude = (float) Math.Sqrt(move.X * move.X + move.Y * move.Y);
			if(magnitude > speed)
				{
    			move *= speed / magnitude;
				}
			npc.velocity = move;
											if (NPC.CountNPCS(mod.NPCType("ArgargothiconMimicFour")) == 0)
			{
				int minionsummon = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("ArgargothiconMimicFour"));
			}
										if (NPC.CountNPCS(mod.NPCType("ArgargothiconMimicTwo")) == 0)
			{
				int minionsummon = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("ArgargothiconMimicTwo"));
			}
			if(npc.ai[0]++ == 5) // One second
{
int rand = Main.rand.Next(0, 4);
	if(rand == 0)
	{
	Vector2 vel = player.Center - npc.Center;
vel.Normalize();
vel *= 20f; //5 blocks / s
int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, mod.ProjectileType("BloodstoneArrow"), 100, 5);
	}
	else if(rand == 1)
	{
	Vector2 vel = player.Center - npc.Center;
vel.Normalize();
vel *= 10f; //5 blocks / s
int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, mod.ProjectileType("BloodSpike"), 100, 5);
	}
	else if(rand == 2)
	{
int minionsummon = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Argargothite"));
	}
	else if(rand == 3)
				{

			}
	else if(rand == 4)
	{

			}
    npc.ai[0] = 0;
}
}	
	
	
	
		else if (npc.life < 22000)
		{
		Vector2 moveTo = player.Center + new Vector2(0f, 0f); //This is 200 pixels above the center of the player.
			float speed = 9f;
			Vector2 move = moveTo - npc.Center;
			float magnitude = (float) Math.Sqrt(move.X * move.X + move.Y * move.Y);
			if(magnitude > speed)
				{
   				 move *= speed / magnitude;
				}
			float turnResistance = 5f; //the larger this is, the slower the npc will turn
			move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
			magnitude = (float) Math.Sqrt(move.X * move.X + move.Y * move.Y);
			if(magnitude > speed)
				{
    			move *= speed / magnitude;
				}
			npc.velocity = move;
					if (NPC.CountNPCS(mod.NPCType("ArgargothiconMimicOne")) == 0)
			{
				int minionsummon = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("ArgargothiconMimicOne"));
			}
			
if(npc.ai[0]++ == 15) // One second
{
int rand = Main.rand.Next(0, 4);
	if(rand == 0)
	{
	Vector2 vel = player.Center - npc.Center;
vel.Normalize();
vel *= 14f; //5 blocks / s
int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, mod.ProjectileType("BloodstoneArrow"), 70, 5);
	}
	else if(rand == 1)
	{
	Vector2 vel = player.Center - npc.Center;
vel.Normalize();
vel *= 7f; //5 blocks / s
int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, mod.ProjectileType("BloodSpike"), 60, 5);
	}
	else if(rand == 2)
	{
int minionsummon = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Argargothite"));
	}
	else if(rand == 3)
	{
	}
    npc.ai[0] = 0;
}
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		else if (npc.life <= 33000)
		{

			Vector2 moveTo = player.Center + new Vector2(0f, -300f); //This is 200 pixels above the center of the player.
			float speed = 5f;
			Vector2 move = moveTo - npc.Center;
			float magnitude = (float) Math.Sqrt(move.X * move.X + move.Y * move.Y);
			if(magnitude > speed)
				{
   				 move *= speed / magnitude;
				}
			float turnResistance = 10f; //the larger this is, the slower the npc will turn
			move = (npc.velocity * turnResistance + move) / (turnResistance + 1f);
			magnitude = (float) Math.Sqrt(move.X * move.X + move.Y * move.Y);
			if(magnitude > speed)
				{
    			move *= speed / magnitude;
				}
			npc.velocity = move;
			
if(npc.ai[0]++ == 30) // One second
{
int rand = Main.rand.Next(0, 3);
	if(rand == 0)
	{
	Vector2 vel = player.Center - npc.Center;
vel.Normalize();
vel *= 14f; //5 blocks / s
int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, mod.ProjectileType("BloodstoneArrow"), 60, 5);
	}
	else if(rand == 1)
	{
	Vector2 vel = player.Center - npc.Center;
vel.Normalize();
vel *= 7f; //5 blocks / s
int proj = Projectile.NewProjectile(npc.Center.X, npc.Center.Y, vel.X, vel.Y, mod.ProjectileType("BloodSpike"), 50, 5);
	}
	else if(rand == 2)
	{
int minionsummon = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, mod.NPCType("Argargothite"));
	}
    npc.ai[0] = 0;
}
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	

			
	}
	}
	}
    }


