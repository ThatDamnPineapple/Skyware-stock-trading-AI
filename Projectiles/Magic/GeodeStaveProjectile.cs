using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Projectiles.Magic
{
	public class GeodeStaveProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Geode Staff Projectile";
			projectile.width = 14;
			projectile.height = 14;
            projectile.alpha = 255;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 1000;
            projectile.light = 0.0f;

        }

		public override void AI()
		{
            projectile.rotation += 0.1f;
            

            projectile.velocity.Y += projectile.ai[0];
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("SolarFlare"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
			}
            {
                {
                    int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
                    int dust1 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 135);
                    int dust2 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75);
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 0);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {

            


            if (Main.rand.Next(8) == 0)
            {
                target.AddBuff(BuffID.CursedInferno, 200, true);
                target.AddBuff(BuffID.OnFire, 200, true);
                target.AddBuff(BuffID.Frostburn, 200, true);
            }            
        }
    }
}