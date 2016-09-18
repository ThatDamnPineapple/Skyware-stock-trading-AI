using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	public class OriPetal : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Orichalcum Petal";
			projectile.width = 20;
			projectile.tileCollide = false;
			projectile.height = 20;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 60;
			Main.projFrames[projectile.type] = 3;  
		}
		public override void AI()
		{
			projectile.frameCounter++;
            if (projectile.frameCounter >= 8)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 3;
            }
		} 
	}
}
