using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	public class SolarExplosion: ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Solar boom";
			projectile.width = 52;
			projectile.height = 52;
			projectile.penetrate = -1;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.hostile = false;
			projectile.friendly = true;
			Main.projFrames[projectile.type] = 5;
		}

		public override bool PreAI()
		{
			if (projectile.ai[0] == 0f)
			{
				projectile.Damage();
				projectile.ai[0] = 1f;
			}
			projectile.frameCounter++;
			if (projectile.frameCounter > 3)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame > Main.projFrames[projectile.type])
				{
					projectile.Kill();
				}
			}
			return false;
		}
		public override void AI()
		{
			 if (Main.rand.Next(3) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
		}
	}
}
