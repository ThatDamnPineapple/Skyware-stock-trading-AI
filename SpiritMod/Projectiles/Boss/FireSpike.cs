using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Boss
{
    public class FireSpike : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Fire Spike";
            projectile.width = projectile.height = 12;

            projectile.hostile = true;

            projectile.penetrate = -1;

            Main.projFrames[projectile.type] = 5;
        }

        public override bool PreAI()
        {
            projectile.frame = (int)projectile.ai[0];
            projectile.velocity.Y = projectile.velocity.Y + 0.1f;
            if (projectile.localAI[0] == 0f || projectile.localAI[0] == 2f)
            {
                projectile.scale += 0.01f;
                projectile.alpha -= 50;
                if (projectile.alpha <= 0)
                {
                    projectile.localAI[0] = 1f;
                    projectile.alpha = 0;
                }
            }
            else if (projectile.localAI[0] == 1f)
            {
                projectile.scale -= 0.01f;
                projectile.alpha += 50;
                if (projectile.alpha >= 255)
                {
                    projectile.localAI[0] = 2f;
                    projectile.alpha = 255;
                }
            }
            projectile.rotation = projectile.velocity.ToRotation() + 1.57F;

            return false;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(200, 200, 200, projectile.alpha);
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 27);
            for (int num273 = 0; num273 < 3; num273++)
            {
                int num274 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.Fire, 0f, 0f, 0, default(Color), 1f);
                Main.dust[num274].noGravity = true;
                Main.dust[num274].noLight = true;
                Main.dust[num274].scale = 0.7f;
            }
        }
    }
}
