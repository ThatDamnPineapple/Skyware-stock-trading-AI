using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	class FireShuriken : ModProjectile
	{
        int timer = 0;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fiery Shuriken");

        }
        public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.timeLeft = 200;
			projectile.height = 24;
			projectile.width = 24;
            projectile.penetrate = 2;
			aiType = ProjectileID.Bullet;
			projectile.extraUpdates = 1;
		}

        public override void AI()
        {
            { 
                {
                    int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust2].noGravity = true;
                    Main.dust[dust2].velocity *= 0f;
                    Main.dust[dust2].velocity *= 0f;
                    Main.dust[dust2].scale = 0.9f;
                    Main.dust[dust].scale = 0.9f;
                }
                {
                    projectile.rotation += 0.3f;
                }
            }

            timer++;
            if (timer == 25)
            {
                projectile.velocity *= 0.01f;
            }
            if (timer == 50)
            {
                projectile.velocity *= 70f;
            }
            if (timer == 75)
            {
                projectile.velocity *= 0.01f;
            }
            if (timer == 100)
            {
                projectile.velocity *= 70f;
            }
            if (timer == 125)
            {
                projectile.velocity *= 0.01f;
            }
            if (timer == 150)
            {
                projectile.velocity *= 70f;
            }
            if (timer == 175)
            {
                projectile.velocity *= 0.01f;
            }
            if (timer == 200)
            {
                projectile.velocity *=70f;
            }
            if (timer >= 210)
            {
                timer = 0;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(8) == 0)
            {
                target.AddBuff(BuffID.OnFire, 240);
            }
        }
        public override void Kill(int timeLeft)
        {
            if (Main.rand.Next(0, 4) == 0)
            {
                Terraria.Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("FieryShuriken"), 1, false, 0, false, false);
            }
            for (int i = 0; i < 8; ++i)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
        }
    }
}
