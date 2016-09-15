using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Yoyo
{
	public class Typhoon : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Typhoon";
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1.08f;
		}

		public override bool PreAI()
		{
			ProjectileExtras.YoyoAI(projectile.whoAmI, 60f, 370f, 16f, 0.39f, delegate
			{
				projectile.frameCounter++;
				if (projectile.frameCounter >= 30)
				{
					projectile.frameCounter = 0;
					float num = 2000f;
					int num2 = -1;
					for (int i = 0; i < 200; i++)
					{
						float num3 = Vector2.Distance(projectile.Center, Main.npc[i].Center);
						if (num3 < num && num3 < 640f && Main.npc[i].CanBeChasedBy(projectile, false))
						{
							num2 = i;
							num = num3;
						}
					}
					if (num2 != -1)
					{
						bool flag = Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[num2].position, Main.npc[num2].width, Main.npc[num2].height);
						if (flag)
						{
							Vector2 value = Main.npc[num2].Center - projectile.Center;
							float num4 = 9f;
							float num5 = (float)Math.Sqrt((double)(value.X * value.X + value.Y * value.Y));
							if (num5 > num4)
							{
								num5 = num4 / num5;
							}
							value *= num5;
							Terraria.Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, value.X, value.Y, 408, projectile.damage, projectile.knockBack / 2f, projectile.owner, 0f, 0f);
						}
					}
				}
			}, null);
			return false;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			ProjectileExtras.DrawString(projectile.whoAmI, default(Vector2));
			return true;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			return false;
		}
	}
}
