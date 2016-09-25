using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
    public class PixieArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Pixie Arrow";
            projectile.width = 9;
            projectile.height = 17;

            projectile.aiStyle = 1;
            aiType = ProjectileID.WoodenArrowFriendly;

            projectile.ranged = true;
            projectile.friendly = true;
        }
		public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 2; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 67);
				
				Vector2 vel = new Vector2(0, -1);
				float rand = Main.rand.NextFloat() * 6.283f;
				vel = vel.RotatedBy(rand);
				vel *= 3.5f;
			Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, vel.X, vel.Y, 90, projectile.damage, projectile.knockBack, projectile.owner);
            }
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(5) == 0)
            {
                target.AddBuff(31, 120);
            }
        }
    }
}
