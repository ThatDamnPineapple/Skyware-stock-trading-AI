using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
	public class PhantomArc : ModProjectile
	{
		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			bool flag = player.CheckMana(player.inventory[player.selectedItem].mana, true, false);
			bool flag2 = player.channel && flag && !player.noItems && !player.CCed;
			if (flag2)
			{
				if (projectile.ai[0] == 1f)
				{
					Vector2 center = projectile.Center;
					Vector2 vector = Vector2.Normalize(projectile.velocity);
					if (float.IsNaN(vector.X) || float.IsNaN(vector.Y))
					{
						vector = -Vector2.UnitY;
					}
					int damage = projectile.damage;
					Projectile.NewProjectile(center.X, center.Y, vector.X, vector.Y, mod.ProjectileType("UnscratchedWispBeam_Friendly"), damage, projectile.knockBack, projectile.owner, 0f, (float)projectile.whoAmI);
					projectile.netUpdate = true;
				}
			}
			else
			{
				projectile.Kill();
			}
			return false;
		}
	}
}
