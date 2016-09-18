using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
	public class RuneBook : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Rune Book";
			projectile.width = 28;
			projectile.height = 32;
			projectile.timeLeft = 80;
			projectile.hostile = false;
			projectile.friendly = true;
			projectile.ignoreWater = true;
			projectile.extraUpdates = 1;
			Main.projFrames[projectile.type] = 4;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
				for (int k = 0; k < 15; k++)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 206, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
			}
			for (int h = 0; h < 7; h++)
			{
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 6f;
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 20, vel.X, vel.Y, mod.ProjectileType("Rune"), projectile.damage, 0, Main.myPlayer);
			}
		}
	}
}
