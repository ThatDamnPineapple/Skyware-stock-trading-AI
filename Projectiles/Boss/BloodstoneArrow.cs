using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;

namespace SpiritMod.Projectiles.Boss
{
	public class BloodstoneArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Bloodstone Arrow";
			projectile.width = 20;
			projectile.height = 60;
			projectile.tileCollide = false;
			
		}
		public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
		}
    }
}