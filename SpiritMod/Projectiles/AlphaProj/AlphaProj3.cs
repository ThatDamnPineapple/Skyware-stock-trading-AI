using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.AlphaProj
{
	class AlphaProj3 : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.name = "Alpha3";
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft = 500;
			projectile.alpha = 255;
			projectile.extraUpdates = 1;
			aiType = ProjectileID.Bullet;
		}

		public override void AI()
		{
			float rotationSpeed = (float)Math.PI / 15;
            projectile.rotation += rotationSpeed;
		}
	}
}