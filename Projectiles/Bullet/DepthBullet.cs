using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Bullet
{
    public class DepthBullet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Depth Round";
            projectile.width = 2;
            projectile.height = 20;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.alpha = 255; 
            projectile.timeLeft = 240;
            aiType = ProjectileID.Bullet;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(15) == 1)
            {
                {
                    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
                    ProjectileExtras.Explode(projectile.whoAmI, 120, 120, delegate
                    {
                        for (int i = 0; i < 40; i++)
                        {
                            int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 15, 0f, -2f, 0, default(Color), 2f);
                            Main.dust[num].noGravity = true;
                            Dust expr_62_cp_0 = Main.dust[num];
                            expr_62_cp_0.position.X = expr_62_cp_0.position.X + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                            Dust expr_92_cp_0 = Main.dust[num];
                            expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + ((float)(Main.rand.Next(-50, 51) / 20) - 1.5f);
                            if (Main.dust[num].position != projectile.Center)
                            {
                                Main.dust[num].velocity = projectile.DirectionTo(Main.dust[num].position) * 6f;
                            }
                        }
                    });
                }
            }
        }
        public override bool PreAI()
        {
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[dust].scale = 1.3f;
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].noGravity = true;
                Main.dust[dust].noLight = true;
                int dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[dust1].scale = 1.3f;
                Main.dust[dust1].velocity *= 0f;
                Main.dust[dust1].noGravity = true;
                Main.dust[dust1].noLight = true;
            }
            return false;
        }
    }
}
