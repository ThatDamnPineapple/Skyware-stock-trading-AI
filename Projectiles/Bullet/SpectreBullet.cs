using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Bullet
{
    class SpectreBullet : ModProjectile
    {
        public const float MAX_ANGLE_CHANGE = (float)Math.PI / 12;
        public const float ACCELERATION = 0.5f;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Bullet");
        }
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.timeLeft = 300;
            projectile.height = 6;
            projectile.width = 6;
            projectile.alpha = 255;
            aiType = ProjectileID.Bullet;
            projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            if (projectile.ai[1] == 0)
            {
                projectile.ai[0] = -1;
                projectile.ai[1] = projectile.velocity.Length();
            }
            
            bool chasing = true;
            NPC target = null;
            if (projectile.ai[0] < 0 || projectile.ai[0] >= Main.maxNPCs)
            {
                target = ProjectileExtras.FindCheapestNPC(projectile.Center, projectile.velocity, ACCELERATION, MAX_ANGLE_CHANGE);
            }
            else
            {
                target = Main.npc[(int)projectile.ai[0]];
                if (!target.active || !target.CanBeChasedBy())
                {
                    target = ProjectileExtras.FindCheapestNPC(projectile.Center, projectile.velocity, ACCELERATION, MAX_ANGLE_CHANGE);
                }
            }

            if (target == null)
            {
                chasing = false;
                projectile.ai[0] = -1f;
            }
            else
            {
                projectile.ai[0] = (float)target.whoAmI;
                ProjectileExtras.HomingAI(this, target, projectile.ai[1], ACCELERATION);
            }

            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 187);//, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 187);//, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust2].noGravity = true;
            Main.dust[dust2].velocity = Vector2.Zero;
            Main.dust[dust2].velocity = Vector2.Zero;
            Main.dust[dust2].scale = 0.9f;
            Main.dust[dust].scale = 0.9f;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.chaseable || target.lifeMax <= 5 || target.dontTakeDamage || target.friendly || target.immortal)
                return;
            if (Main.rand.Next(100) <= 35)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, 305, 0, 0f, projectile.owner, projectile.owner, 1);
            }
        }
    }
}
