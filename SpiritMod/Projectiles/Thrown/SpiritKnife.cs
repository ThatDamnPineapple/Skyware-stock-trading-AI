using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown
{
	public class SpiritKnife : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Spirit Knife";
			projectile.width = 12;
			projectile.height = 12;
			projectile.penetrate = 2;
			projectile.friendly = true;
			projectile.thrown = true;
		}

		public override bool PreAI()
		{
			ProjectileExtras.ThrowingKnifeAI(projectile.whoAmI, 30, null, null);
			return false;
		}

		public override void Kill(int timeLeft)
		{
			if (Main.rand.Next(0, 4) == 0)
			{
				Terraria.Item.NewItem((int)projectile.position.X, (int)projectile.position.Y, projectile.width, projectile.height, mod.ItemType("SpiritKnife"), 1, false, 0, false, false);
			}
		}

		public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			ProjectileExtras.DrawAroundOrigin(projectile.whoAmI, lightColor);
			return false;
		}
	}
}
