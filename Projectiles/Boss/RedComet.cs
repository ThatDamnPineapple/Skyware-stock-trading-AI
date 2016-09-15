using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Projectiles.Boss
{
	public class RedComet : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Red Comet";
			projectile.width = 34;
			projectile.height = 90;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 1000;
			projectile.tileCollide = false;
			projectile.aiStyle = -1;
        }
		
				public override void AI()
		{
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 60, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
    }
}