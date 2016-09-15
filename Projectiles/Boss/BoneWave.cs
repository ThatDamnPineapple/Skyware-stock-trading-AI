using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Projectiles.Boss
{
	public class BoneWave : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Bone Wave";
			projectile.width = 80;
			projectile.height = 30;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = 10;
			projectile.timeLeft = 1000;
			projectile.tileCollide = false;
			projectile.aiStyle = 1;
			aiType = ProjectileID.Bullet;

        }
    }
}