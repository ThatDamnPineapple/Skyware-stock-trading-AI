using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
	public class ShadowCircleRune : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Shadow Circle Rune";
			projectile.width = 60;
			projectile.height = 60;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.alpha = 255;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 360;
		}

		public override bool PreAI()
		{
			projectile.rotation += 0.05f * (float)projectile.direction;
			return false;
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			ProjectileExtras.DrawAroundOrigin(projectile.whoAmI, lightColor);
			return false;
		}
	}
}
