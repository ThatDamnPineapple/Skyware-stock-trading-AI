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
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Trident);
            projectile.name = "Zodiac";
            aiType = ProjectileID.Trident;
            projectile.aiStyle = 19;
        }
		
		public override bool PreAI()
	    {
		    if (projectile.ai[0] == 0)
		    {
			    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, projectile.velocity.X * 2, projectile.velocity.Y * 2, mod.ProjectileType("ZodiacProj2"), projectile.damage, 0f, projectile.owner, 0f, 0f);
                projectile.ai[0] = 1;
            }

            return false;
	    }
    }
}