using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class ThornVine : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Thorny Vine";
            projectile.friendly = true;
            projectile.magic = true;
            projectile.width = 56; projectile.height = 56;
            projectile.penetrate = -1;
            projectile.timeLeft = 120;
            Main.projFrames[projectile.type] = 2;
        }

        public override bool PreAI()
        {
            //Saving for later
            /*projectile.tileCollide = true;
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 67, 0f, 0f);
            Main.dust[dust].scale = 1.5f;
            Main.dust[dust].noGravity = true;
            projectile.velocity.Y += projectile.ai[0];
            {
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            }
            */
            return false;
        }

        public override void AI()
        {

            projectile.velocity.Y += projectile.ai[0];
            {
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
            }

            if (projectile.velocity.X > 0)
            {
                projectile.frame = 0;
            }
            else
            {
                projectile.frame = 1;
            }

        }

        public override bool OnTileCollide(Microsoft.Xna.Framework.Vector2 oldVelocity)
        {
            return base.OnTileCollide(oldVelocity);
            projectile.Kill();
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 67, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 50);
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 67, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
        }
        public void Add(Vector2 position)
        {
            for (int k = projectile.oldPos.Length - 1; k > 0; k--)
            {
                projectile.oldPos[k] = projectile.oldPos[k - 1];
            }
            projectile.oldPos[0] = projectile.position;
            projectile.position = position;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                if (projectile.oldPos[k] == Vector2.Zero)
                {
                    return;
                }
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + projectile.Size / 2f;
                Color color = Lighting.GetColor((int)(projectile.oldPos[k].X / 16f), (int)(projectile.oldPos[k].Y / 16f));
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, 0f, projectile.Size / 2f, 1f, SpriteEffects.None, 0f);
            }
        }
    }
}
