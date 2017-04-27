using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Boss
{
    public class CrystalSpike : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Crystal Spike";
            projectile.penetrate = 600;
			projectile.hostile = true;
			projectile.damage = 13;
			projectile.friendly = false;
            projectile.light = 2;
            projectile.aiStyle = 1;
			Main.projFrames[projectile.type] = 5;
			aiType = ProjectileID.Bullet;	
			projectile.tileCollide = true;

        }
		public override void AI()
        {
			projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 4;
            } 
		}
        public override void Kill(int timeLeft)
        {
            if (Main.rand.Next(10) == 0)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 62, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }
    }
}