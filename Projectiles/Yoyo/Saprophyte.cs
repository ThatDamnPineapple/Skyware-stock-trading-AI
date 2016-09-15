using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Yoyo
{
	public class Saprophyte : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Saprophyte";
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1.08f;
		}

		public override bool PreAI()
		{
			ProjectileExtras.YoyoAI(projectile.whoAmI, 14f, 290f, 16f, 0.39f, delegate
			{
				projectile.frameCounter++;
				if (projectile.frameCounter >= 15)
				{
					Terraria.Projectile.NewProjectile(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2), projectile.velocity.X, projectile.velocity.Y, 131, projectile.damage / 3, 0f, projectile.owner, 0f, 0f);
					projectile.frameCounter = 0;
				}
			}, null);
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
