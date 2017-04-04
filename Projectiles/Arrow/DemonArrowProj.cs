using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
    public class DemonArrowProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.name = "Demon Arrow";
            projectile.width = 9;
            projectile.height = 22;
            projectile.penetrate = 2;
            
            projectile.ranged = true;
            projectile.friendly = true;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= 0f;
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }
        public override void AI()
        {
            int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 0f;
            {
                projectile.velocity *= 1.1f;
            }
        }
    }
}
