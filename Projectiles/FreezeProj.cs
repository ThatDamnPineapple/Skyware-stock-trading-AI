using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
	class FreezeProj : ModProjectile
	{
		public static int _type;

		public override string Texture => SpiritMod.EMPTY_TEXTURE;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Ward");
		}

		public override void SetDefaults()
		{
			projectile.friendly = true;
			projectile.hostile = false;
			projectile.penetrate = -1;
			projectile.timeLeft = 60;
			projectile.height = 200;
			projectile.width = 200;
			projectile.alpha = 255;
		}

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.Center = player.Center;

			Rectangle rect = new Rectangle((int)projectile.Center.X, (int)projectile.position.Y, 150, 150);
			for (int index1 = 0; index1 < 200; index1++)
			{
				if (rect.Contains(Main.npc[index1].Center.ToPoint()))
					Main.npc[index1].AddBuff(Buffs.MageFreeze._type, 240);
			}
			if (Main.rand.Next(9) == 1)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 187);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].scale = 0.9f;
			}
		}

	}
}
