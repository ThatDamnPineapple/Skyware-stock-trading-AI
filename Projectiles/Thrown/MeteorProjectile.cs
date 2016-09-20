using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown
{
	public class MeteorProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Meteor";         
            projectile.width = 30;
			projectile.friendly = true;
            projectile.thrown = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 120;
            projectile.height = 30;
        }

        public override bool PreAI()
        {
            Vector2 position = projectile.Center + Vector2.Normalize(projectile.velocity) * 10;

            Dust newDust = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 0, default(Color), 1f)];
            newDust.position = position;
            newDust.velocity = projectile.velocity.RotatedBy(Math.PI / 2, default(Vector2)) * 0.33F + projectile.velocity / 4;
            newDust.position += projectile.velocity.RotatedBy(Math.PI / 2, default(Vector2));
            newDust.fadeIn = 0.5f;
            newDust.noGravity = true;
            newDust = Main.dust[Dust.NewDust(projectile.position, projectile.width, projectile.height, 6, 0f, 0f, 0, default(Color), 1)];
            newDust.position = position;
            newDust.velocity = projectile.velocity.RotatedBy(-Math.PI / 2, default(Vector2)) * 0.33F + projectile.velocity / 4;
            newDust.position += projectile.velocity.RotatedBy(-Math.PI / 2, default(Vector2));
            newDust.fadeIn = 0.5F;
            newDust.noGravity = true;
            for (int i = 0; i < 1; i++)
            {
                newDust = Main.dust[Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 0, default(Color), 1f)];
                newDust.velocity *= 0.5F;
                newDust.scale *= 1.3F;
                newDust.fadeIn = 1F;
                newDust.noGravity = true;
            }

            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 200);
        }

        public override void Kill(int timeLeft)
        {
            int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 20, 0, 0, mod.ProjectileType("SolarExplosion"), (int)(projectile.damage), 0, Main.myPlayer);
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
        }
    }
}