using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
    public class AtlasSphere : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Atlas Sphere";
            projectile.width = 16;
            projectile.height = 16;

            projectile.npcProj = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;

            projectile.penetrate = 2;
            projectile.timeLeft = 180;
        }

        public override bool PreAI()
        {
            for(int i = 0; i < 3; ++i)
            {
                Vector2 speed = -projectile.velocity + new Vector2(Main.rand.Next(-5, 5), Main.rand.Next(-5, 5));
                speed *= 0.4F;
                Dust newDust = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.AmberBolt, speed.X, speed.Y, 0, default(Color), 1.5f)];
                newDust.noGravity = true;
                newDust.position.X = projectile.Center.X;
                newDust.position.Y = projectile.Center.Y;
                newDust.position.X = newDust.position.X + (float)Main.rand.Next(-10, 11);
                newDust.position.Y = newDust.position.Y + (float)Main.rand.Next(-10, 11);
            }

            return false;
        }
    }
}
