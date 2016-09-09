using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Boss
{
    public class IlluminantMasterVision : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "IlluminantMasterVision";
            projectile.timeLeft = 45;
            projectile.alpha = 0;
            projectile.extraUpdates = 1;
            projectile.light = 0;
			Main.projFrames[projectile.type] = 7;
        }
		 public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 7;
            }
		}
	}
}