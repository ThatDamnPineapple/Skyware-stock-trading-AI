using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class PalladiumStaffProj : ModProjectile
    {
		int bounce = 3;
        public override void SetDefaults()
        {
			projectile.hostile = false;
			projectile.magic = true;
			projectile.name = "PalladiumStaff";
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.alpha = 255;
			projectile.timeLeft = 1000;

        }
		
				public override bool PreAI()
		{
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 55, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);      
				Main.dust[dust].scale = 1f;
				Main.dust[dust].noGravity = true;		
	
			return true;
		}
		
			public override bool OnTileCollide(Vector2 oldVelocity)
	{
		bounce--;
		if (bounce <= 0)
		{
			projectile.Kill();
		}
       
		if (projectile.velocity.X != oldVelocity.X)
		{
			projectile.velocity.X = -oldVelocity.X;
		}
		if (projectile.velocity.Y != oldVelocity.Y)
		{
			projectile.velocity.Y = -oldVelocity.Y;
		}
		Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		return false;
	}

    }
}
