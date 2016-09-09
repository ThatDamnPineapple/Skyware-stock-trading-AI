using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Projectiles.Boss
{
	public class BloodSpike : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Blood Spike";
			projectile.width = 64;
			projectile.height = 64;
			projectile.friendly = false;
			projectile.magic = false;
			projectile.hostile = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 1000;
            projectile.light = 0.6f;
			projectile.tileCollide = false;

        }

		public override void AI()
		{
            projectile.rotation += 0.1f;
            

            projectile.velocity.Y += projectile.ai[0];
			if (Main.rand.Next(3) == 0)
			{
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("SolarFlare"), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
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