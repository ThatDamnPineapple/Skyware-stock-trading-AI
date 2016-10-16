using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
	public class ShadowBall_Friendly : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Shadowball";
			projectile.width = 20;
			projectile.height = 20;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			Main.projFrames[projectile.type] = 4;
		}
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            {
                for (int num621 = 0; num621 < 40; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num622].velocity *= 3f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num622].scale = 0.5f;
                        Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                    }
                }
                for (int num623 = 0; num623 < 70; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 27, 0f, 0f, 100, default(Color), 3f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 5f;
                    num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 27, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num624].velocity *= 2f;
                }
            }
        }
        public override void AI()
        {
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 3)
            {
                projectile.tileCollide = false;
                projectile.ai[1] = 0f;
                projectile.alpha = 255;
                projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                projectile.width = 14;
                projectile.height = 14;
                projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                projectile.knockBack = 4f;
            }
        }
        public override bool PreAI()
		{
			if (projectile.ai[1] == 0f)
			{
				projectile.ai[1] = 1f;
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 34);
			}
			else if (projectile.ai[1] == 1f && Main.netMode != 1)
			{
				int num = -1;
				float num2 = 2000f;
				for (int i = 0; i < 200; i++)
				{
					if (Main.npc[i].CanBeChasedBy(projectile, false))
					{
						Vector2 center = Main.npc[i].Center;
						float num3 = Vector2.Distance(center, projectile.Center);
						if ((num3 < num2 || num == -1) && Collision.CanHit(projectile.Center, 1, 1, center, 1, 1))
						{
							num2 = num3;
							num = i;
						}
					}
				}
				if (num2 < 20f)
				{
					projectile.Kill();
					return false;
				}
				if (num != -1)
				{
					projectile.ai[1] = 21f;
					projectile.ai[0] = (float)num;
					projectile.netUpdate = true;
				}
			}
			else if (projectile.ai[1] > 20f && projectile.ai[1] < 200f)
			{
				projectile.ai[1] += 1f;
				int num4 = (int)projectile.ai[0];
				if (!Main.npc[num4].CanBeChasedBy(projectile, false))
				{
					projectile.ai[1] = 1f;
					projectile.ai[0] = 0f;
					projectile.netUpdate = true;
				}
				else
				{
					float num5 = Utils.ToRotation(projectile.velocity);
					Vector2 vector = Main.npc[num4].Center - projectile.Center;
					if (vector.Length() < 20f)
					{
						projectile.Kill();
						return false;
					}
					float num6 = Utils.ToRotation(vector);
					if (vector == Vector2.Zero)
					{
						num6 = num5;
					}
					float num7 = Utils.AngleLerp(num5, num6, 0.008f);
					projectile.velocity = Utils.RotatedBy(new Vector2(projectile.velocity.Length(), 0f), (double)num7, default(Vector2));
				}
			}
			if (projectile.ai[1] >= 1f && projectile.ai[1] < 20f)
			{
				projectile.ai[1] += 1f;
				if (projectile.ai[1] == 20f)
				{
					projectile.ai[1] = 1f;
				}
			}
			projectile.alpha -= 40;
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
			projectile.spriteDirection = projectile.direction;
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frame++;
				projectile.frameCounter = 0;
				if (projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] == 12f)
			{
				projectile.localAI[0] = 0f;
				for (int j = 0; j < 12; j++)
				{
					Vector2 vector2 = Vector2.UnitX * -(float)projectile.width / 2f;
					vector2 += -Utils.RotatedBy(Vector2.UnitY, (double)((float)j * 3.14159274f / 6f), default(Vector2)) * new Vector2(8f, 16f);
					vector2 = Utils.RotatedBy(vector2, (double)(projectile.rotation - 1.57079637f), default(Vector2));
					int num8 = Dust.NewDust(projectile.Center, 0, 0, 27, 0f, 0f, 160, default(Color), 1f);
					Main.dust[num8].scale = 1.1f;
					Main.dust[num8].noGravity = true;
					Main.dust[num8].position = projectile.Center + vector2;
					Main.dust[num8].velocity = projectile.velocity * 0.1f;
					Main.dust[num8].velocity = Vector2.Normalize(projectile.Center - projectile.velocity * 3f - Main.dust[num8].position) * 1.25f;
				}
			}
			if (Main.rand.Next(4) == 0)
			{
				for (int k = 0; k < 1; k++)
				{
					Vector2 value = -Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 0.19634954631328583), (double)Utils.ToRotation(projectile.velocity), default(Vector2));
					int num9 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num9].velocity *= 0.1f;
					Main.dust[num9].position = projectile.Center + value * (float)projectile.width / 2f;
					Main.dust[num9].fadeIn = 0.9f;
				}
			}
			if (Main.rand.Next(32) == 0)
			{
				for (int l = 0; l < 1; l++)
				{
					Vector2 value2 = -Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 0.39269909262657166), (double)Utils.ToRotation(projectile.velocity), default(Vector2));
					int num10 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, 0f, 0f, 155, default(Color), 0.8f);
					Main.dust[num10].velocity *= 0.3f;
					Main.dust[num10].position = projectile.Center + value2 * (float)projectile.width / 2f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num10].fadeIn = 1.4f;
					}
				}
			}
			if (Main.rand.Next(2) == 0)
			{
				for (int m = 0; m < 2; m++)
				{
					Vector2 value3 = -Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 0.78539818525314331), (double)Utils.ToRotation(projectile.velocity), default(Vector2));
					int num11 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 27, 0f, 0f, 0, default(Color), 1.2f);
					Main.dust[num11].velocity *= 0.3f;
					Main.dust[num11].noGravity = true;
					Main.dust[num11].position = projectile.Center + value3 * (float)projectile.width / 2f;
					if (Main.rand.Next(2) == 0)
					{
						Main.dust[num11].fadeIn = 1.4f;
					}
				}
			}
			return false;
		}
	}
}
