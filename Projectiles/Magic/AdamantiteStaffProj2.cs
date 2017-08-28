using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class AdamantiteStaffProj2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantite Blast");
        }
        public override void SetDefaults()
        {
			projectile.hostile = false;
			projectile.magic = true;
			projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = -1;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.alpha = 255;

        }
		
				public override bool PreAI()
		{
			projectile.velocity = projectile.velocity.RotatedBy(System.Math.PI / 180) * 1.01f;
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);      
				Main.dust[dust].scale = 1f;
				Main.dust[dust].noGravity = true;	

                int dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);      
				Main.dust[dust1].scale = 1f;
				Main.dust[dust1].noGravity = true;	
				
	
			return true;
		}

    }
}
