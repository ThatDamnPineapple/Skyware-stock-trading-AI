using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	class WardProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Sanguine Ward";
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = 4;
			projectile.timeLeft = 500;
			projectile.height = 100;
			projectile.width = 100;
            projectile.alpha = 255;
			projectile.extraUpdates = 1;
		}

        public override void AI()
        {
            { 
                {
                Player player = Main.player[projectile.owner];
                projectile.Center = new Vector2(player.Center.X + (player.direction > 0 ? 0 : 0), player.position.Y + 30);   // I dont know why I had to set it to -60 so that it would look right   (change to -40 to 40 so that it's on the floor)
             }
                if (Main.rand.Next(5) == 1)
                {
                    int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 5, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 5, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust2].noGravity = true;
                    Main.dust[dust2].velocity *= 0f;
                    Main.dust[dust2].velocity *= 0f;
                    Main.dust[dust2].scale = 0.9f;
                    Main.dust[dust].scale = 0.9f;
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(6) == 1)

            {
                target.AddBuff(mod.BuffType("BCorrupt"), 180);
            }
        }
    }
}
