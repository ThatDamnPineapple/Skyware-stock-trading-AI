using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.NPCs;

namespace SpiritMod.Projectiles.Arrow
{
	class TikiBiter : ModProjectile
	{
		public static ModProjectile _ref;

		public override void SetDefaults()
		{
			projectile.name = "Tiki Spirit";
			projectile.width = 18;
			projectile.height = 18;
			//projectile.alpha = 0;
			//projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 5;
			projectile.extraUpdates = 1;
		}

		public override bool PreAI()
		{
			//Initialize
			if (projectile.ai[1] == 0f)
			{
				float vY = Main.rand.Next(-14, 15) * 0.125f;
				float vX = Main.rand.Next(-14, 15) * 0.125f;
				vX += vX > 0 ? Math.Abs(vY) : -Math.Abs(vY);
				projectile.velocity = new Vector2(vX, vY);
			}

			projectile.ai[1] += 1f;
			bool chasing = false;
			if (projectile.ai[1] >= 30f)
			{
				chasing = true;

				projectile.friendly = true;
				NPC target = null;
				if (projectile.ai[0] == -1f)
				{
					target = ProjectileExtras.FindRandomNPC(projectile.Center, 960f, false);
				} else
				{
					target = Main.npc[(int)projectile.ai[0]];
					if (!target.active || !target.CanBeChasedBy())
					{
						target = ProjectileExtras.FindRandomNPC(projectile.Center, 960f, false);
					}
				}

				if (target == null)
				{
					chasing = false;
					projectile.ai[0] = -1f;
				} else
				{
					projectile.ai[0] = (float)target.whoAmI;
                    ProjectileExtras.HomingAI(this, target, 10f, 5f);
                }
            }

            ProjectileExtras.LookAlongVelocity(this);
            if (!chasing)
			{
				Vector2 dir = projectile.velocity;
				float vel = projectile.velocity.Length();
				if (vel != 0f)
				{
					if (vel < 4f)
					{
						dir *= 1 / vel;
						projectile.velocity += dir * 0.0625f;
					}
				} else
				{
					//Stops the projectiles from spazzing out
					projectile.velocity.X += Main.rand.Next(2) == 0 ? 0.1f : -0.1f;
				}
			}

			//Create particles
			int i = Main.rand.Next(10);
			if (i < 5)
			{
				float offsetX = projectile.velocity.X * 0.2f * (float)i;
				float offsetY = -(projectile.velocity.Y * 0.2f) * (float)i;
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 2, 0f, 0f, 100);
				Main.dust[dust].position.X -= offsetX;
				Main.dust[dust].position.Y -= offsetY;
				Main.dust[dust].velocity -= projectile.velocity * 0.25f;
			}
			return false;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			} else
			{
				ProjectileExtras.Bounce(this, oldVelocity);
				projectile.ai[0] = -1f;
				//Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
			}
			return false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
            NInfo modNPC = target.GetModInfo<NInfo>(mod);
			if (target.life <= 0)
			{
				//Workaround: OnHitNPC gets called after NPCLoot for some reason.
				Vector2 pos = target.Center;
				Projectile.NewProjectile(pos.X, pos.Y, 0f, 0f, _ref.projectile.type, projectile.damage, 0f, projectile.owner, -1f);
			}
            else
			{
				target.AddBuff(Buffs.TikiInfestation._ref.Type, (int)(Buffs.TikiInfestation.duration * 0.5f));
				modNPC.AddTikiSource(projectile);
			}
			projectile.Kill();
		}

	}
}
