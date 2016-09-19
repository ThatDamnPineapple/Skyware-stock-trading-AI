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

            Vector2 mountedCenter = player.RotatedRelativePoint(player.MountedCenter, true);
            if (Main.myPlayer == projectile.owner)
            {
                float scale = 32 * projectile.scale;
                Vector2 dir = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY) - mountedCenter;
                if (player.gravDir == -1f)
                {
                    dir.Y = (float)(Main.screenHeight - Main.mouseY) + Main.screenPosition.Y - mountedCenter.Y;
                }
                dir.Normalize();
                if (float.IsNaN(dir.X) || float.IsNaN(dir.Y))
                {
                    dir = -Vector2.UnitY;
                }
                dir = Vector2.Normalize(Vector2.Lerp(dir, Vector2.Normalize(projectile.velocity), 0.92f));
                dir *= scale;
                if (dir.X != projectile.velocity.X || dir.Y != projectile.velocity.Y)
                {
                    projectile.netUpdate = true;
                }
                projectile.velocity = dir;
            }
            projectile.position = mountedCenter - projectile.Size / 2f;
            projectile.rotation = projectile.velocity.ToRotation() + 1.57F;
            projectile.spriteDirection = projectile.direction;
            projectile.timeLeft = 2;
            player.ChangeDir(projectile.direction);
            player.heldProj = projectile.whoAmI;
            if (player.itemTime < 2) player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = (float)Math.Atan2((projectile.velocity.Y * projectile.direction), (projectile.velocity.X * projectile.direction));
            return false;
		}
	}
}
