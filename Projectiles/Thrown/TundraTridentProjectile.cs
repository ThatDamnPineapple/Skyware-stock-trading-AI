using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown
{
    // IRIAZUL
    public class TundraTridentProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Tundra Trident";
            projectile.width = 12;
            projectile.height = 28;

            projectile.friendly = true;

            projectile.penetrate = -1;
        }

        public override bool PreAI()
        {
            projectile.ai[0]++;
            if(projectile.ai[0] >= 30)
            {
                projectile.velocity.Y = projectile.velocity.Y + 0.4f;
                projectile.velocity.X = projectile.velocity.X * 0.98f;
            }
            projectile.rotation = projectile.velocity.ToRotation() + 1.57F;
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(10) == 0)
            {
                target.AddBuff(BuffID.Frostburn, 180);
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; ++i)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Ice);
            }
            Main.PlaySound(28, projectile.position, 0);
        }
    }
}
