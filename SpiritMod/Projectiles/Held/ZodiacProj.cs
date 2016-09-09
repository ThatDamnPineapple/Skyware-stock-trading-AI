using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Held
{
    public class ZodiacProj : ModProjectile
    {
		int timer = 0;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Trident);
            projectile.name = "Zodiac";
            aiType = ProjectileID.Trident;
            projectile.aiStyle = 19;
        }
		
			public override void AI()
	{
		timer++;
		if (timer == 1)
		{
			Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X * 2, projectile.velocity.Y * 2, mod.ProjectileType("ZodiacProj2"), projectile.damage, 0f, projectile.owner, 0f, 0f);
		}
	}
    }
}