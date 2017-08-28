using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown
{
    public class BirbDagger : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asura's Blade");
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 3;
            projectile.timeLeft = 300;
            projectile.thrown = true;
            projectile.height = 6;
            projectile.width = 6;
            aiType = ProjectileID.Bullet;
            projectile.extraUpdates = 1;

        }

        int timer = 1;
        public override void AI()
        {
            timer--;

            if (timer == 0)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("AsuraTrail"), projectile.damage / 2, projectile.knockBack, projectile.owner, 0f, 0f);
                timer = 25;
            }
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
        }
    }
}
