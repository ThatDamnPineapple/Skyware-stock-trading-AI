using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	public class FieryAura : ModProjectile
	{
		public override void SetDefaults()
		{
            projectile.name = "Fiery Essence";
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 240;
            projectile.height = 6;
            projectile.width = 6;
            projectile.alpha = 255;
            aiType = ProjectileID.Bullet;
            projectile.extraUpdates = 1;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = false;
            base.projectile.magic = true;
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			base.projectile.localAI[1] += 1f;
            {
                target.AddBuff(mod.BuffType("StackingFireBuff"), 280);
                projectile.velocity *= 0f;
            }
        }

		public override void AI()
		{
			base.projectile.localAI[1] += 1f;
			int num = 1;
			int num2 = 1;
			if ((double)base.projectile.localAI[1] <= 1.0)
			{
				int num3 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("DuskAura"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
				Main.projectile[num3].localAI[0] = (float)base.projectile.whoAmI;
				return;
			}
			int num4 = (int)base.projectile.localAI[1];
			if (num4 <= 30)
			{
				if (num4 != 10)
				{
					if (num4 == 30)
					{
						num2--;
					}
				}
				else
				{
					num2--;
				}
			}
			else if (num4 != 50)
			{
				if (num4 == 70)
				{
					num2--;
				}
			}
			else
			{
				num2--;
			}
			if (new int[]
			{
				20
			}.Contains((int)base.projectile.localAI[1]))
			{
				int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("DuskAura"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
				Main.projectile[num5].localAI[0] = (float)base.projectile.whoAmI;
			}
			if (new int[]
			{
				30
			}.Contains((int)base.projectile.localAI[1]))
			{
				int num6 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("DuskAura"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
				Main.projectile[num6].localAI[0] = (float)base.projectile.whoAmI;
			}
			if (new int[]
			{
				40
			}.Contains((int)base.projectile.localAI[1]))
			{
				int num7 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("DuskAura"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
				Main.projectile[num7].localAI[0] = (float)base.projectile.whoAmI;
			}
            {
                {
                    int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust2].noGravity = true;
                    Main.dust[dust2].velocity *= 0f;
                    Main.dust[dust2].velocity *= 0f;
                    Main.dust[dust2].scale = 0.9f;
                    Main.dust[dust].scale = 0.9f;
                }

            }
        }
        public override void PostAI()
		{
			base.projectile.rotation -= 10f;
            projectile.velocity *= 0.95f;
        }
	}
}
