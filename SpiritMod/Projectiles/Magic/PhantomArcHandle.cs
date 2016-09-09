using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
	public class PhantomArcHandle : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Phantom Arc";
			projectile.width = 14;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.magic = true;
			projectile.ignoreWater = true;
		}

		public override bool PreAI()
		{
			Player player = Main.player[projectile.owner];
			float num = 1.57079637f;
			player.RotatedRelativePoint(player.MountedCenter, true);
			projectile.damage = (int)((float)player.inventory[player.selectedItem].damage * player.magicDamage);
			projectile.ai[0] += 1f;
			projectile.ai[1] += 1f;
			projectile.frameCounter++;
			float arg_B0_0 = projectile.ai[0];
			if (Main.myPlayer == projectile.owner)
			{
				bool flag = player.CheckMana(player.inventory[player.selectedItem].mana, true, false);
				bool flag2 = player.channel && flag && !player.noItems && !player.CCed;
				if (flag2)
				{
					if (projectile.ai[0] == 1f)
					{
						Vector2 arg_123_0 = projectile.Center;
						Vector2 vector = Vector2.Normalize(projectile.velocity);
						if (float.IsNaN(vector.X) || float.IsNaN(vector.Y))
						{
							vector = -Vector2.UnitY;
						}
						int arg_169_0 = projectile.damage;
						projectile.netUpdate = true;
					}
				}
				else
				{
					projectile.Kill();
				}
			}
			projectile.position = player.RotatedRelativePoint(player.MountedCenter, true) - projectile.Size / 2f;
			projectile.rotation = Utils.ToRotation(projectile.velocity) + num;
			projectile.spriteDirection = projectile.direction;
			projectile.timeLeft = 2;
			player.ChangeDir(projectile.direction);
			player.heldProj = projectile.whoAmI;
			player.itemTime = 2;
			player.itemAnimation = 2;
			player.itemRotation = (float)Math.Atan2((double)(projectile.velocity.Y * (float)projectile.direction), (double)(projectile.velocity.X * (float)projectile.direction));
			return false;
		}
	}
}
