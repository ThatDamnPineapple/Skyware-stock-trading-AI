using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Projectiles.Thrown
{
	public class SpectreKnifeProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Spectre Knife";
            projectile.width = 18;
            projectile.height = 18;
            projectile.aiStyle = 113;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 3;
            projectile.timeLeft = 600;
            projectile.extraUpdates = 1;
            projectile.light = 0;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.ThrowingKnife;
		}
		public override void Kill(int timeLeft)
		{
			 int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-8,8), Main.rand.Next(-8,8), mod.ProjectileType("SpectreBolt"), (int)(projectile.damage), 0, Main.myPlayer);
			     Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
		}
		public override void AI()
		{
						 if (Main.rand.Next(2) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 187, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
		}
	}
}
