using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Held
{
	public class RunicDrillProjectile : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Runic Drill Projectile";
			projectile.width = 26;
			projectile.height = 54;
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