using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Sword
{
    public class SwordRuneProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "SwordRuneProjectile";
            projectile.width = 20;
            projectile.height = 28;
            projectile.friendly = true;
            aiType = ProjectileID.DesertDjinnCurse;
			Main.projFrames[projectile.type] = 4;
        }
		
				public override void AI()
        {
			projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 4;
            } 
		}
    }
	
}