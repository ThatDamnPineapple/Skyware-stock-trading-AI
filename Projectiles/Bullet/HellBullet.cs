using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Bullet
{
	public class HellBullet : ModProjectile
    {
		private int Counter = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hell Bullet");
        }
        public override void SetDefaults()
        {
            projectile.width = 2;
            projectile.height = 16;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 240;
            aiType = ProjectileID.Bullet;
        }
			public override void AI()
		{
						 if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
			Counter++;
			if (Counter % 35 == 1)
			{
				for (int i = 0; i < 2; ++i)
            {
                int randFire = Main.rand.Next(3);
                int newProj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 
                    0, -4,
                    ProjectileID.GreekFire1 + randFire, projectile.damage, 0, projectile.owner);
                Main.projectile[newProj].hostile = false;
                Main.projectile[newProj].friendly = true;
            }
			}
		}


    }
}
