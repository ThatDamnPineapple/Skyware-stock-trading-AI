using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Held
{
	public class StellarDrillProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Stellar Drill Projectile";
			projectile.width = 22;
			projectile.height = 48;
			projectile.aiStyle = 20;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.hide = true;
			projectile.ownerHitCheck = true; 
			projectile.melee = true;
		}
	}
}