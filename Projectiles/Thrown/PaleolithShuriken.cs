using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown
{
    public class PaleolithShuriken : ModProjectile
    {
        int target;

        public override void SetDefaults()
        {
            projectile.name = "Paleolith Shuriken";
            projectile.width = 12;
            projectile.height = 12;
            projectile.penetrate = 2;
            projectile.friendly = true;
            projectile.thrown = true;

            projectile.timeLeft = 120;
        }

        public override bool PreAI()
        {
            projectile.rotation += (Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y)) * 0.03f * (float)projectile.direction;
            
            if (projectile.ai[0] == 0 && Main.netMode != 1)
            {
                target = -1;
                float distance = 320;
                for (int k = 0; k < 200; k++)
                {
                    if (Main.npc[k].active && Main.npc[k].CanBeChasedBy(projectile, false) && Collision.CanHitLine(projectile.Center, 1, 1, Main.npc[k].Center, 1, 1))
                    {
                        Vector2 center = Main.npc[k].Center;
                        float currentDistance = Vector2.Distance(center, projectile.Center);
                        if (currentDistance < distance || target == -1)
                        {
                            distance = currentDistance;
                            target = k;
                        }
                    }
                }
                if (target != -1)
                {
                    projectile.ai[0] = 1;
                    projectile.netUpdate = true;
                }
            }
            else
            {
                NPC targetNPC = Main.npc[this.target];
                if (!targetNPC.active || !targetNPC.CanBeChasedBy(projectile, false) || !Collision.CanHitLine(projectile.Center, 1, 1, targetNPC.Center, 1, 1))
                {
                    this.target = -1;
                    projectile.ai[0] = 0;
                    projectile.netUpdate = true;
                }
                else
                {
                    float currentRot = projectile.velocity.ToRotation();
                    Vector2 direction = targetNPC.Center - projectile.Center;
                    float targetAngle = direction.ToRotation();
                    if (direction == Vector2.Zero)
                    {
                        targetAngle = currentRot;
                    }

                    float desiredRot = currentRot.AngleLerp(targetAngle, 0.04f);
                    projectile.velocity = new Vector2(projectile.velocity.Length(), 0f).RotatedBy(desiredRot, default(Vector2));
                }
            }

            if(projectile.timeLeft <= 30)
                projectile.Opacity -= 0.032F;

            return false;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y, 1);
            for (int num424 = 0; num424 < 10; num424++)
            {
                Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 1, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.75f);
            }
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            ProjectileExtras.DrawAroundOrigin(projectile.whoAmI, lightColor);
            return false;
        }

        public override void SendExtraAI(System.IO.BinaryWriter writer)
        {
            writer.Write(this.target);
        }
        public override void ReceiveExtraAI(System.IO.BinaryReader reader)
        {
            this.target = reader.Read();
        }
    }
}
