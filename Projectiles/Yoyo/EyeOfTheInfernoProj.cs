using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Yoyo
{
	public class EyeOfTheInfernoProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Yelets);
            projectile.extraUpdates = 1;
			projectile.name = "Eye Of The Inferno";
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.Yelets;
        }

        public override void AI()
        {
            base.projectile.localAI[1] += 1f;
            int num = 1;
            int num2 = 1;
            if ((double)base.projectile.localAI[1] <= 1.0)
            {
                int num3 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("za"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
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
                int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("SpikeBall"), 50, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num5].localAI[0] = (float)base.projectile.whoAmI;
            }
            if (new int[]
            {
                30
            }.Contains((int)base.projectile.localAI[1]))
            {
                int num6 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("z"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num6].localAI[0] = (float)base.projectile.whoAmI;
            }
            if (new int[]
            {
                40
            }.Contains((int)base.projectile.localAI[1]))
            {
                int num7 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("x"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
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
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            {
                target.AddBuff(mod.BuffType("StackingFireBuff"), 280);
                projectile.velocity *= 0f;
            }
        }

    }

}