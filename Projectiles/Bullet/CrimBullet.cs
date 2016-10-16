using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Bullet
{
	public class CrimBullet : ModProjectile
    {
        //Warning : it's not my code. It's exampleMod code. so i donnt fully understand it
        public override void SetDefaults()
        {
            projectile.name = "Crim Bullet";
            projectile.width = 2;
            projectile.height = 20;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 240;
            aiType = ProjectileID.Bullet;
            ProjectileID.Sets.Homing[projectile.type] = true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(100) <= 9)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0f, 0f, 305, 0, 0f, projectile.owner, projectile.owner, Main.rand.Next(1, 3));
            }
        }


    }
}
