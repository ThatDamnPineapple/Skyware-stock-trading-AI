using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Projectiles.Boss
{
	public class BloodyThing : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Bloody Thing";
			projectile.width = 10;
			projectile.height = 20;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 1000;
			projectile.aiStyle = 1;
            projectile.extraUpdates = 1;
            aiType = 1;
			projectile.alpha = 255;

        }
		
			public override void AI()
		{
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 5, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);      
				Main.dust[dust].scale = 2f;
				Main.dust[dust].noGravity = true;
				Main.dust[dust].noLight = true;				
		}
    }
}