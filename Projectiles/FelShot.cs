using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	public class FelShot : ModProjectile
    {
        //Warning : it's not my code. It's exampleMod code. so i donnt fully understand it
        public override void SetDefaults()
        {
            projectile.name = "Reaper's Soul";
            projectile.friendly = true;
            projectile.magic = true;
            projectile.width = 18; projectile.height = 18;
            projectile.penetrate = 1;
            projectile.alpha = 255;
            projectile.timeLeft = 180;
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override bool PreAI()
        {


            projectile.ai[1] += 1f;
            bool chasing = false;
            if (projectile.ai[1] >= 30f)
            {
                chasing = true;

                projectile.friendly = true;
                NPC target = null;
                if (projectile.ai[0] == -1f)
                {
                    target = ProjectileExtras.FindRandomNPC(projectile.Center, 960f, false);
                }
                else
                {
                    target = Main.npc[(int)projectile.ai[0]];
                    if (!target.active || !target.CanBeChasedBy())
                    {
                        target = ProjectileExtras.FindRandomNPC(projectile.Center, 960f, false);
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
                    this.HomingAI(target, 10f, 5f);
                }
            }

            this.LookAlongVelocity();
            if (!chasing)
            {
                Vector2 dir = projectile.velocity;
                float vel = projectile.velocity.Length();
                if (vel != 0f)
                {
                    if (vel < 4f)
                    {
                        dir *= 1 / vel;
                        projectile.velocity += dir * 0.0625f;
                    }
                }
                else
                {
                    //Stops the projectiles from spazzing out
                    projectile.velocity.X += Main.rand.Next(2) == 0 ? 0.1f : -0.1f;
                }
            }
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 75, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
            return false;
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
          target.AddBuff(mod.BuffType("FelBrand"), 280);
        }


    }
}
