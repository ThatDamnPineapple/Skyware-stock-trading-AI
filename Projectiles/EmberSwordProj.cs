using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	class EmberSwordProj : ModProjectile
	{
        int timer = 0;
        public override void SetDefaults()
		{
			projectile.name = "Ember Wave";
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.timeLeft = 300;
			projectile.height = 18;
			projectile.width = 58;
            projectile.penetrate = 2;
			aiType = ProjectileID.Bullet;
			projectile.extraUpdates = 1;
		}
        public override void Kill(int timeLeft)
        {
            { 
                for (int num623 = 0; num623 < 70; num623++)
                {
                    int num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[num624].noGravity = true;
                    Main.dust[num624].velocity *= 1.5f;
                    num624 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1f);
                    Main.dust[num624].velocity *= 2f;
                }
            }
        }
        public override void AI()
        {
            {
                projectile.velocity *= .95f;
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                {
                    int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 0f;
                    Main.dust[dust].scale = 1.9f;
               }

            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(BuffID.OnFire, 240);
            }
        }
    }
}
