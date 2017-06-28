using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic.Artifact
{

    public class FreezeBolt1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frost Bolt");
            Main.projFrames[projectile.type] = 5;

        }
        public override void SetDefaults()
        { 
            projectile.width = 20;       
            projectile.height = 20;  
            projectile.friendly = true;      
            projectile.magic = true;          
            projectile.tileCollide = true;   
            projectile.penetrate = 2;      
            projectile.timeLeft = 500;      
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;

        }
        public override void AI()
        {
            projectile.frameCounter++;
            if ((float)projectile.frameCounter >= 5f)
            {
                projectile.frame = (projectile.frame + 1) % Main.projFrames[projectile.type];
                projectile.frameCounter = 0;
            }
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
            if (Main.rand.Next(4) == 0)
            {
                for (int k = 0; k < 1; k++)
                {
                    Vector2 value = -Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 0.19634954631328583), (double)Utils.ToRotation(projectile.velocity), default(Vector2));
                    int num9 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 187, 0f, 0f, 135, default(Color), 1f);
                    Main.dust[num9].velocity *= 0.1f;
                    Main.dust[num9].noGravity = true;
                    Main.dust[num9].position = projectile.Center + value * (float)projectile.width / 2f;
                    Main.dust[num9].fadeIn = 0.9f;
                }
            }
            if (Main.rand.Next(2) == 0)
            {
                for (int m = 0; m < 2; m++)
                {
                    Vector2 value3 = -Utils.RotatedBy(Utils.RotatedByRandom(Vector2.UnitX, 0.78539818525314331), (double)Utils.ToRotation(projectile.velocity), default(Vector2));
                    int num11 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 187, 0f, 0f, 0, default(Color), 1.2f);
                    Main.dust[num11].velocity *= 0.3f;
                    Main.dust[num11].noGravity = true;
                    Main.dust[num11].position = projectile.Center + value3 * (float)projectile.width / 2f;
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.dust[num11].fadeIn = 1.4f;
                    }
                }
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(20) == 0) target.AddBuff(mod.BuffType("Freeze"), 180);
        }
        public override void Kill(int timeLeft)
        {
            {
                if (Main.rand.Next(8) == 0)
                { 
                int n = 2;
                int deviation = Main.rand.Next(0, 180);
                for (int i = 0; i < n; i++)
                {
                    float rotation = MathHelper.ToRadians(270 / n * i + deviation);
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(rotation);
                    perturbedSpeed.Normalize();
                    perturbedSpeed.X *= 4.5f;
                    perturbedSpeed.Y *= 4.5f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, mod.ProjectileType("FrostTrail"), 30, 2, projectile.owner);
                }
            }

                for (int i = 0; i < 40; i++)
                {
                    int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135, 0f, -2f, 0, default(Color), 2f);
                    Main.dust[num].noGravity = true;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, mod.ProjectileType("Fire"), projectile.damage, projectile.knockBack, projectile.owner, 0f, 0f);
                    Dust expr_62_cp_0 = Main.dust[num];
                    expr_62_cp_0.position.X = expr_62_cp_0.position.X + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                    Dust expr_92_cp_0 = Main.dust[num];
                    expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                    if (Main.dust[num].position != projectile.Center)
                    {
                        Main.dust[num].velocity = projectile.DirectionTo(Main.dust[num].position) * 6f;
                    }
                }
            }
        }
    }
}