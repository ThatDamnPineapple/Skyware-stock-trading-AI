using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Yoyo
{
	public class Murk : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Murk";
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1.08f;
		}

		public override bool PreAI()
		{
			ProjectileExtras.YoyoAI(projectile.whoAmI, 14f, 270f, 16f, 0.39f, null, null);
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
