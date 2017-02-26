using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	public class SpiritProjectileInfo : ProjectileInfo
    {
        public bool WitherLeaf = false;
        public bool shotFromStellarCrosbow = false;
        public bool shotFromBloodshot = false;
        public bool shotFromClatterBow = false;
    }
	
	public class SpiritGlobalProjectile : GlobalProjectile
    {
        public override bool PreAI(Projectile projectile)
        {

            if (projectile.GetModInfo<SpiritProjectileInfo>(mod).WitherLeaf == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                if (Main.rand.Next(2) == 0) Dust.NewDust(projectile.position, projectile.width, projectile.height, 3);
                return true;
            }
            if (projectile.GetModInfo<SpiritProjectileInfo>(mod).shotFromStellarCrosbow == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                if (Main.rand.Next(2) == 0) Dust.NewDust(projectile.position, projectile.width, projectile.height, 133);
                return false;
            }
            if (projectile.GetModInfo<SpiritProjectileInfo>(mod).shotFromBloodshot == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                if (Main.rand.Next(2) == 0) Dust.NewDust(projectile.position, projectile.width, projectile.height, 5);
                return false;
            }
            if (projectile.GetModInfo<SpiritProjectileInfo>(mod).shotFromClatterBow == true)
            {
                projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
                if (Main.rand.Next(2) == 0) Dust.NewDust(projectile.position, projectile.width, projectile.height, 147);
                return false;
            }
            return base.PreAI(projectile);
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
			if(projectile.GetModInfo<SpiritProjectileInfo>(mod).shotFromStellarCrosbow == true)
			{
            target.AddBuff(mod.BuffType("StarFracture"), 300);
			}
            if (projectile.GetModInfo<SpiritProjectileInfo>(mod).WitherLeaf == true)
            {
                target.AddBuff(mod.BuffType("WitheringLeaf"), 180);
            }
            if (projectile.GetModInfo<SpiritProjectileInfo>(mod).shotFromBloodshot == true)
            {
                target.AddBuff(mod.BuffType("BCorrupt"), 120);
            }
            if (projectile.GetModInfo<SpiritProjectileInfo>(mod).shotFromClatterBow == true && Main.rand.Next(6) == 0)
            {
                target.AddBuff(mod.BuffType("ClatterPierce"), 120);
            }
        }
    }
}
