using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.AlphaProj
{
	class AlphaProj2 : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.name = "Alpha2";
			projectile.tileCollide = false;
			projectile.aiStyle = 1;
			projectile.friendly = true;
			projectile.penetrate = 5;
			projectile.timeLeft = 300;
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
