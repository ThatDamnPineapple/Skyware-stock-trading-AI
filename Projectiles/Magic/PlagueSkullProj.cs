using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class PlagueSkullProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Plague Skull";
            projectile.width = 30;
			projectile.height = 30;

            projectile.magic = true;
            projectile.friendly = true;
            projectile.hostile = false;

            projectile.penetrate = 5;
        }
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + 3.14f;
			if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);      
	            Main.dust[dust].noGravity = true;		
            }
		}
		
		 public override void Kill(int timeLeft)
        {
            Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
			for (int I = 0; I < 8; I++)
            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 61, projectile.oldVelocity.X * 0.2f, projectile.oldVelocity.Y * 0.2f);
        }
    }
}
