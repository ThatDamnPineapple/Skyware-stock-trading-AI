using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
	public class ElectricityBolt : ModProjectile
	{
		NPC target2 = (Main.npc[2]);
		NPC hit1 = (Main.npc[0]);
		NPC hit2 = (Main.npc[0]);
		NPC hit3 = (Main.npc[0]);
		NPC hit4 = (Main.npc[0]);
		NPC hit5 = (Main.npc[0]);
		NPC hit6 = (Main.npc[0]);
		NPC hit7 = (Main.npc[0]);
		NPC hit8 = (Main.npc[0]);
		NPC hit9 = (Main.npc[0]);
		NPC hit10 = (Main.npc[0]); //YES I KNOW IT WOULD BE MORE EFFICIENT TO JUST USE A LIST BUT SHUT 
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Electricity Bolt");
		}

		public override void SetDefaults()
		{
			projectile.hostile = false;
			projectile.melee = true;
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 10;
			projectile.alpha = 255;
			projectile.timeLeft = 35;
			projectile.tileCollide = false;
		}
		
		
		
		public override bool PreAI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + 1.57f;

			for (int i = 0; i < 20; i++)
			{
				float x = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
				float y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
				int num = Dust.NewDust(new Vector2(x, y), 20, 20, 226, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num].position.X = x;
				Main.dust[num].position.Y = y;
				Main.dust[num].velocity *= 0f;
				Main.dust[num].noGravity = true;
			}
			if (target2.active && projectile.Distance(target2.Center) / 16 < 30)
			{
				
				Vector2 ShootArea = new Vector2(projectile.Center.X, projectile.Center.Y - 25);
				Vector2 direction = target2.Center - ShootArea;
				direction.Normalize();
				direction.X *= 50;
				direction.Y *= 50;
				projectile.velocity = direction;
			}
			return true;
		}
		private bool CanTarget(NPC target)
		{
			if (target == hit1 || target == hit2 || target == hit3 || target == hit4 || target == hit5 || target == hit6 || target == hit7 || target == hit8 || target == hit9 || target == hit10)
			{
				return false;
			}
			return true;
		}
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			int range = 30;   //How many tiles away the projectile targets NPCs
			float shootVelocity = 50f; //magnitude of the shoot vector (speed of arrows shot)
			int shootSpeed = 100;

			//TARGET NEAREST NPC WITHIN RANGE
			float lowestDist = float.MaxValue;
			for (int i = 0; i < 200; ++i)
			{
				NPC npc = Main.npc[i];
				//if npc is a valid target (active, not friendly, and not a critter)
				if (npc.active && npc.CanBeChasedBy(projectile) && npc != target && CanTarget(npc))
				{
					//if npc is within 50 blocks
					float dist = projectile.Distance(npc.Center);
					if (dist / 16 < range)
					{
						//if npc is closer than closest found npc
						if (dist < lowestDist)
						{
							lowestDist = dist;

							//target this npc
							projectile.ai[1] = npc.whoAmI;
						}
					}
				}
			}

			target2 = (Main.npc[(int)projectile.ai[1]] ?? new NPC()); //our target
																		 //firing
				


				
			if (projectile.penetrate == 10)
			{
				hit10 = target2;
			}
			if (projectile.penetrate == 9)
			{
				hit9 = target2;
			}
			if (projectile.penetrate == 8)
			{
				hit8 = target2;
			}
			if (projectile.penetrate == 7)
			{
				hit7 = target2;
			}
			if (projectile.penetrate == 6)
			{
				hit6 = target2;
			}
			if (projectile.penetrate == 5)
			{
				hit5 = target2;
			}
			if (projectile.penetrate == 4)
			{
				hit4 = target2;
			}
			if (projectile.penetrate == 3)
			{
				hit3 = target2;
			}
			if (projectile.penetrate == 2)
			{
				hit2 = target2;
			}
			if (projectile.penetrate == 1)
			{
				hit1 = target2;
			}
			
			
			
			
			
			if (target2.active && projectile.Distance(target2.Center) / 16 < range)
			{
				
				Vector2 ShootArea = new Vector2(projectile.Center.X, projectile.Center.Y - 25);
				Vector2 direction = target2.Center - ShootArea;
				direction.Normalize();
				direction.X *= shootVelocity;
				direction.Y *= shootVelocity;
				projectile.velocity = direction;
			}
			else
			{
				projectile.Kill();
			}
		}

		

	}
}
