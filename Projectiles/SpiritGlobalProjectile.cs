using System;
using Terraria.ModLoader;
using Terraria;

namespace SpiritMod.Projectiles
{
	public class SpiritGlobalProjectile : GlobalProjectile
    {
        public bool shotFromStellarCrosbow;// = false;

        public override bool PreAI(Projectile projectile)
        {
            if(shotFromStellarCrosbow)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                if (Main.rand.Next(2) == 0) Dust.NewDust(projectile.position, projectile.width, projectile.height, 31);
                return false;
            }
            return base.PreAI(projectile);
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
			if(shotFromStellarCrosbow)
			{
            target.AddBuff(mod.BuffType("StarFracture"), 300);
			}
        }
    }
}
