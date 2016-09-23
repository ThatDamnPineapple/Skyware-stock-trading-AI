using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Held
{
	public class ZodiacLightning : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.melee = true;
			projectile.name = "Zodiac";
			projectile.friendly = true;
			projectile.aiStyle = 27;
			projectile.width = 100;
			projectile.height = 100;
			projectile.penetrate = -1;
			projectile.alpha = 255;
			projectile.timeLeft = 1;
		}

		public override bool PreAI()
		{
			for (int i = 0; i < 25; ++i)
			{
				projectile.tileCollide = false;
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 226, 0f, 0f);
				Main.dust[dust].scale = 1.5f;
			}
			return false;
		}
	}
}