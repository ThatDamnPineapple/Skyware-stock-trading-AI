using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.AlphaProj
{
	class AlphaProj5 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Alpha5";
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 15;
			projectile.timeLeft = 500;
			projectile.height = 30;
			projectile.width = 16;
			aiType = ProjectileID.Bullet;
			projectile.extraUpdates = 1;
		}

		public override void AI()
		{
			projectile.velocity.Y += projectile.ai[0];
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				projectile.velocity *= 0.75f;
			}
			return false;
		}
	}
}
