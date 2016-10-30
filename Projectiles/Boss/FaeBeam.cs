using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Boss
{
	public class FaeBeam : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.hostile = true;
			projectile.magic = true;
			projectile.width = 4;
			projectile.height = 20;
			projectile.friendly = false;
			projectile.name = "Fae Beam";
			projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
			projectile.tileCollide = false;
			
		}
		
		public override void AI()
        {
			if (Main.rand.Next(10) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 62, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
		}
	}
}