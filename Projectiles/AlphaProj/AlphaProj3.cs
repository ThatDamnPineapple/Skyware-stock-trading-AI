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
            projectile.name = "Essence of Vortex";
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 15;
            projectile.timeLeft = 240;
            projectile.height = 6;
            projectile.width = 6;
            projectile.alpha = 255;
            aiType = ProjectileID.Bullet;
            projectile.extraUpdates = 1;
        }

		public override void AI()
		{
            {
                float rotationSpeed = (float)Math.PI / 15;
                projectile.rotation += rotationSpeed;
            }
            {
                int timer = 0;
                projectile.velocity *= 0.99f;

            }
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 110, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 110, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity *= 0f;
                Main.dust[dust2].velocity *= 0f;
                Main.dust[dust2].scale = 0.9f;
                Main.dust[dust].scale = 0.9f;
            }
        }
		}

	}