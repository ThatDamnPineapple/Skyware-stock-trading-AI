using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
    public class SpiritArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Revenant Arrow";
            projectile.width = 9;
            projectile.height = 17;

            projectile.aiStyle = 1;
            aiType = ProjectileID.WoodenArrowFriendly;

            projectile.ranged = true;
            projectile.friendly = true;
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("SoulBurn"), 180, false);
            }
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            ProjectileExtras.Explode(projectile.whoAmI, 120, 120, delegate
            {
                for (int i = 0; i < 40; i++)
                {
                    int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 68, 0f, -2f, 0, default(Color), 2f);
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
