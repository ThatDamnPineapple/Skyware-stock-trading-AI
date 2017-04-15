using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Yoyo
{
	public class Saprophyte : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Saprophyte";
            base.projectile.CloneDefaults(546);
            base.projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[base.projectile.type] = 1;
            this.aiType = 546;
        }

        public override bool PreAI()
        {
            {
                projectile.frameCounter++;
                if (projectile.frameCounter >= 60)
                {
                    Terraria.Projectile.NewProjectile(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2), projectile.velocity.X, projectile.velocity.Y, 131, projectile.damage / 2, 0f, projectile.owner, 0f, 0f);
                    projectile.frameCounter = 0;
                }
            }
			return true;
		}
        public override void AI()
        {
            base.projectile.rotation -= 10f;
        }
    }
}
