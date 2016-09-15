using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class LightWave : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Wave of Light";
            projectile.friendly = true;
            projectile.magic = true;
            projectile.width = 40;
            projectile.height = 30;
            projectile.penetrate = 2;
            projectile.timeLeft = 180;
        }

        public override bool PreAI()
        {
            projectile.tileCollide = true;
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, 0f, 0f);
            Main.dust[dust].scale = 1.5f;
            Main.dust[dust].noGravity = true;
            projectile.velocity.Y += projectile.ai[0];
            {
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            }
            return false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.Kill();
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            int dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            projectile.height = 80;
            projectile.width = 80;
            return false;
        }

        public override bool PreKill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            int dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 64, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            projectile.height = 80;
            projectile.width = 80;
            return false;
        }
    }
}
