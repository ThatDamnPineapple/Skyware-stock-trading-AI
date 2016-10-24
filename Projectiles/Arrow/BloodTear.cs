using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
    public class BloodTear : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.damage = 50;
            projectile.name = "BloodTear";
            projectile.extraUpdates = 1;
            projectile.penetrate = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.BoneArrow;
            projectile.penetrate = -1;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            for (int I = 0; I < 8; I++)
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 5, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
        }
        public override bool PreAI()
        {
            if (Main.rand.Next(8) == 1)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[dust].scale = 2f;
                Main.dust[dust].noGravity = true;
            }

            return true;
        }
    }
}
