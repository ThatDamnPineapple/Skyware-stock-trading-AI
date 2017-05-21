using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	public class DepthSpiral : ModProjectile
	{
		public override void SetDefaults()
		{
            projectile.name = "Brain";
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.timeLeft = 150;
            projectile.height = 6;
            projectile.width = 6;
            projectile.alpha = 255;
            aiType = ProjectileID.Bullet;
            projectile.extraUpdates = 1;
            base.projectile.ignoreWater = true;
            base.projectile.tileCollide = false;
            base.projectile.magic = true;
        }
        public override void AI()
        {
            base.projectile.localAI[1] += 1f;
            int num = 1;
            int num2 = 1;
            if ((double)base.projectile.localAI[1] <= 1.0)
            {
                int num3 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("DepthBolt"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
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
                int num5 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("DepthBolt"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num5].localAI[0] = (float)base.projectile.whoAmI;
            }
            if (new int[]
            {
                30
            }.Contains((int)base.projectile.localAI[1]))
            {
                int num6 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("?"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num6].localAI[0] = (float)base.projectile.whoAmI;
            }
            if (new int[]
            {
                40
            }.Contains((int)base.projectile.localAI[1]))
            {
                int num7 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, (float)num, (float)num2, base.mod.ProjectileType("?"), base.projectile.damage, base.projectile.knockBack, base.projectile.owner, 0f, 0f);
                Main.projectile[num7].localAI[0] = (float)base.projectile.whoAmI;
            }
        }
	}
}
