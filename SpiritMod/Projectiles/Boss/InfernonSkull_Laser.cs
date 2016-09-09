using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Boss
{
    public class InfernonSkull_Laser : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Infernal Beam";
            projectile.width = 18;
            projectile.height = 18;
            projectile.alpha = 255;

            projectile.penetrate = -1;

            projectile.hostile = true;
            projectile.friendly = false;
            projectile.tileCollide = false;

            Main.projFrames[projectile.type] = 3;
        }

        public override bool PreAI()
        {
            NPC owner = Main.npc[(int)projectile.ai[1]];

            if (projectile.velocity.HasNaNs() || projectile.velocity == Vector2.Zero)
            {
                projectile.velocity = -Vector2.UnitY;
            }

            if (owner.active && owner.ai[0] == 1)
            {
                Vector2 value29 = new Vector2(27f, 59f);
                Vector2 value30 = Utils.Vector2FromElipse(Main.npc[(int)projectile.ai[1]].localAI[0].ToRotationVector2(), value29 * Main.npc[(int)projectile.ai[1]].localAI[1]);
                projectile.position = owner.Center + value30 - new Vector2(projectile.width, projectile.height) / 2f;
            }
            else
            {
                projectile.Kill();
                return false;
            }

            if (projectile.velocity.HasNaNs() || projectile.velocity == Vector2.Zero)
            {
                projectile.velocity = -Vector2.UnitY;
            }

            float num810 = projectile.velocity.ToRotation();
            num810 += projectile.ai[0] * 1.2F;
            projectile.rotation = num810 - 1.57F;
            projectile.velocity = num810.ToRotationVector2();

            float num811 = 2f;
            float scaleFactor7 = 0f;
            Vector2 value37 = projectile.Center;

            float[] array3 = new float[(int)num811];
            int num812 = 0;
            while ((float)num812 < num811)
            {
                float num813 = (float)num812 / (num811 - 1f);
                Vector2 value38 = value37 + projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2)) * (num813 - 0.5f) * scaleFactor7 * projectile.scale;
                int num814 = (int)value38.X / 16;
                int num815 = (int)value38.Y / 16;
                Vector2 vector69 = value38 + projectile.velocity * 16f * 150f;
                int num816 = (int)vector69.X / 16;
                int num817 = (int)vector69.Y / 16;
                Tuple<int, int> tuple;
                float num818;
                if (!Collision.TupleHitLine(num814, num815, num816, num817, 0, 0, new List<Tuple<int, int>>(), out tuple))
                {
                    num818 = new Vector2((float)Math.Abs(num814 - tuple.Item1), (float)Math.Abs(num815 - tuple.Item2)).Length() * 16f;
                }
                else if (tuple.Item1 == num816 && tuple.Item2 == num817)
                {
                    num818 = 2400f;
                }
                else
                {
                    num818 = new Vector2((float)Math.Abs(num814 - tuple.Item1), (float)Math.Abs(num815 - tuple.Item2)).Length() * 16f;
                }
                array3[num812] = num818;
                num812++;
            }
            float num819 = 0f;
            for (int num820 = 0; num820 < array3.Length; num820++)
            {
                num819 += array3[num820];
            }
            num819 /= num811;
            float amount = 0.5f;
            projectile.localAI[1] = MathHelper.Lerp(projectile.localAI[1], num819, amount);

            Vector2 vector72 = projectile.Center + projectile.velocity * (projectile.localAI[1] - 14f);
            /*for (int num826 = 0; num826 < 2; num826++)
            {
                float num827 = projectile.velocity.ToRotation() + ((Main.rand.Next(2) == 1) ? -1f : 1f) * 1.57079637f;
                float num828 = (float)Main.rand.NextDouble() * 2f + 2f;
                Vector2 vector73 = new Vector2((float)Math.Cos((double)num827) * num828, (float)Math.Sin((double)num827) * num828);
                int num829 = Dust.NewDust(vector72, 0, 0, 229, vector73.X, vector73.Y, 0, default(Color), 1f);
                Main.dust[num829].noGravity = true;
                Main.dust[num829].scale = 1.7f;
            }
            if (Main.rand.Next(5) == 0)
            {
                Vector2 value40 = projectile.velocity.RotatedBy(1.5707963705062866, default(Vector2)) * ((float)Main.rand.NextDouble() - 0.5f) * (float)projectile.width;
                int num830 = Dust.NewDust(vector72 + value40 - Vector2.One * 4f, 8, 8, 31, 0f, 0f, 100, default(Color), 1.5f);
                Main.dust[num830].velocity *= 0.5f;
                Main.dust[num830].velocity.Y = -Math.Abs(Main.dust[num830].velocity.Y);
            }*/
            DelegateMethods.v3_1 = new Vector3(0.3f, 0.65f, 0.7f);
            Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], (float)projectile.width * projectile.scale, new Utils.PerLinePoint(DelegateMethods.CastLight));
            return false;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float num2 = 0f;
            if (Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), projectile.Center, projectile.Center + projectile.velocity * projectile.localAI[1], 36 * projectile.scale, ref num2))
            {
                return true;
            }
            return false;
        }

        public override bool PreDraw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.velocity == Vector2.Zero)
            {
                return false;
            }
            Texture2D laserStartTexture = Main.projectileTexture[projectile.type];
            Texture2D texture2D14 = mod.GetTexture("Projectiles/InfernonSkull_LaserMid");
            Texture2D texture2D15 = mod.GetTexture("Projectiles/InfernonSkull_LaserEnd");
            float num205 = projectile.localAI[1];
            Microsoft.Xna.Framework.Color color33 = new Microsoft.Xna.Framework.Color(255, 255, 255, 0) * 0.9f;
            SpriteBatch arg_95FF_0 = Main.spriteBatch;
            Texture2D arg_95FF_1 = laserStartTexture;
            Vector2 arg_95FF_2 = projectile.Center - Main.screenPosition;
            Microsoft.Xna.Framework.Rectangle? sourceRectangle2 = null;
            arg_95FF_0.Draw(arg_95FF_1, arg_95FF_2, sourceRectangle2, color33, projectile.rotation, laserStartTexture.Size() / 2f, projectile.scale, SpriteEffects.None, 0f);
            num205 -= (float)(laserStartTexture.Height / 2 + texture2D15.Height) * projectile.scale;
            Vector2 value15 = projectile.Center;
            value15 += projectile.velocity * projectile.scale * (float)laserStartTexture.Height / 2f;
            if (num205 > 0f)
            {
                float num206 = 0f;
                Microsoft.Xna.Framework.Rectangle rectangle4 = new Microsoft.Xna.Framework.Rectangle(0, 16 * (projectile.timeLeft / 3 % 5), texture2D14.Width, 16);
                while (num206 + 1f < num205)
                {
                    if (num205 - num206 < (float)rectangle4.Height)
                    {
                        rectangle4.Height = (int)(num205 - num206);
                    }
                    Main.spriteBatch.Draw(texture2D14, value15 - Main.screenPosition, new Microsoft.Xna.Framework.Rectangle?(rectangle4), color33, projectile.rotation, new Vector2((float)(rectangle4.Width / 2), 0f), projectile.scale, SpriteEffects.None, 0f);
                    num206 += (float)rectangle4.Height * projectile.scale;
                    value15 += projectile.velocity * (float)rectangle4.Height * projectile.scale;
                    rectangle4.Y += 16;
                    if (rectangle4.Y + rectangle4.Height > texture2D14.Height)
                    {
                        rectangle4.Y = 0;
                    }
                }
            }
            SpriteBatch arg_9865_0 = Main.spriteBatch;
            Texture2D arg_9865_1 = texture2D15;
            Vector2 arg_9865_2 = value15 - Main.screenPosition;
            sourceRectangle2 = null;
            arg_9865_0.Draw(arg_9865_1, arg_9865_2, sourceRectangle2, color33, projectile.rotation, texture2D15.Frame(1, 1, 0, 0).Top(), projectile.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}
