using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
	class QuasarSoul : ModProjectile
	{
		public override string Texture
		{ get { return "SpiritMod/Empty"; } }

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Quasar Soul");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LostSoulFriendly);
			projectile.magic = false;
			projectile.ranged = true;
		}
	}
}
