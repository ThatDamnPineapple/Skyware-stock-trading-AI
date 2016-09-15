using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.AlphaProj
{
	class AlphaProj4 : ModProjectile
	{

		public override void SetDefaults()
		{
			projectile.name = "Alpha4";
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 500;
			projectile.alpha = 255;
			projectile.extraUpdates = 1;
		}
		
		        public override void Kill(int timeLeft)
        {
            int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y + 20, 0, 0, mod.ProjectileType("SolarExplosion"), (int)(projectile.damage), 0, Main.myPlayer);
			Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            projectile.Kill();
        }
	}
}
