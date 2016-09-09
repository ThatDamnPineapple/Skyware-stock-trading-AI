using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Held
{
    public class ZodiacProj2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.name = "Zodiac";
            projectile.friendly = true;
            projectile.aiStyle = 27;
			projectile.width = 24;
			projectile.height = 24;
			projectile.penetrate = -1;
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
	Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("ZodiacLightning"), projectile.damage, 0f, projectile.owner, 0f, 0f);
	}
	
    }
}