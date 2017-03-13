using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Boss
{
    public class MiracleBeam : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Miracle Beam";
            projectile.width = 8;
            projectile.height = 8;
            projectile.hostile = true;
            projectile.timeLeft = 300;
            projectile.penetrate = 1;
            projectile.light = 0.5f;
        }
        
        public override void AI()
        {
        	if (projectile.localAI[0] == 0f)
			{
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 33);
				projectile.localAI[0] += 1f;
			}
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
            projectile.velocity.Y *= 1.005f;
            projectile.velocity.X *= 1.005f;
        }
        
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            {
                for (int num621 = 0; num621 < 15; num621++)
                {
                    int num622 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 257, 0f, 0f, 100, default(Color), 2f);
                }
            }
        }
    }
}