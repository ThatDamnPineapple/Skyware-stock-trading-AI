using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Yoyo
{
	public class ProbeP : ModProjectile
	{
		public override void SetDefaults()
		{
			base.projectile.CloneDefaults(549);
			base.projectile.damage = 52;
			base.projectile.extraUpdates = 3;
			ProjectileID.Sets.TrailCacheLength[base.projectile.type] = 4;
			ProjectileID.Sets.TrailingMode[base.projectile.type] = 1;
			this.aiType = 549;
		}

		public override void PostAI()
		{
			base.projectile.rotation -= 10f;
		}

		public override void AI()
		{
			base.projectile.frameCounter++;
			if (base.projectile.frameCounter >= 80)
			{
				base.projectile.frameCounter = 0;
				float num = (float)((double)Main.rand.Next(0, 361) * 0.017453292519943295);
				Vector2 vector = new Vector2((float)Math.Cos((double)num), (float)Math.Sin((double)num));
				int num2 = Projectile.NewProjectile(base.projectile.Center.X, base.projectile.Center.Y, vector.X, vector.Y, 100, base.projectile.damage, (float)base.projectile.owner, 0, 0f, 0f);
				Main.projectile[num2].friendly = true;
				Main.projectile[num2].hostile = false;
				Main.projectile[num2].velocity *= 7f;
				Dust.NewDust(base.projectile.position, base.projectile.width, base.projectile.height, 35, 0f, 0f, 0, default(Color), 1f);
			}
		}
	}
}
