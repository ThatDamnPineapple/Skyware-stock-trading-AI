using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Boss
{
	public class FaeStar : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.hostile = true;
			projectile.magic = true;
			projectile.width = 20;
			projectile.light = 0.5f;
			projectile.height = 20;
			projectile.friendly = false;
			projectile.name = "Fae Star";
			projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;
			
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			}
			for (int I = 0; I < 15; I++)
				{
				//	int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, mod.DustType("CrystalDust"), (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0);
				}
			return false;
		}
	
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
				Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
			}
		}
	}
}