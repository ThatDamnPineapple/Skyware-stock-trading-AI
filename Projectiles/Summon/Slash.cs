using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using System.IO;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Summon
{
	public class Slash : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slash");
			Main.projFrames[projectile.type] = 6;
		}

		public override void SetDefaults()
		{
			projectile.hostile = false;
			projectile.magic = true;
			projectile.width = 76;
			projectile.height = 120;
			projectile.friendly = true;
			projectile.tileCollide = false;
			projectile.ignoreWater = true;
			projectile.timeLeft = 500;
			projectile.penetrate = -1;
			projectile.damage = 10;
			projectile.light = 0.5f;
		}

		

		public override void AI()
		{
			
			projectile.frameCounter++;
			if (projectile.frameCounter >= 3)
			{
				projectile.frameCounter = 0;
				projectile.frame = (projectile.frame + 1) % 6;
			}
		}

		


	}
}