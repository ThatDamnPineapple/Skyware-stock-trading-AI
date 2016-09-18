using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown
{
	public class VortexSlasherProjectile : ModProjectile
    {
		float DistYT = 0f;
        float DistXT = 0f;
        float DistY = 0f;
        float DistX = 0f;
        public override void SetDefaults()
        {
            projectile.name = "Vortex Slasher";
            projectile.width = 13;
            projectile.height = 18;
            projectile.aiStyle = 113;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.alpha = 255;
            projectile.light = 0;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.BoneJavelin;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            	 Vector2 Victom = new Vector2(target.position.X, target.position.Y);
				 Vector2 RandomPos = new Vector2(target.position.X + Main.rand.Next(48,-48), target.position.Y + Main.rand.Next(48,-48));
			Vector2 direction = Victom - RandomPos;
				direction.Normalize();
				direction.X *= 8f;
				direction.Y *= 8f;
				
           // Projectile.NewProjectile(DistX, DistY, (0 - DistX) / 50, (0 - DistY) / 50, mod.ProjectileType("ManaStarProjectile"), damage, knockBack, player.whoAmI, 0f, 0f);
            //return false;
			Projectile.NewProjectile(RandomPos.X, RandomPos.Y, direction.X, direction.Y, mod.ProjectileType("VortexSlasherProjectileTwo"), projectile.damage, 1, projectile.owner, 0f, 0f);
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 206);
            }
        }

        //public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        //{
        //    Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
        //    for (int k = 0; k < projectile.oldPos.Length; k++)
        //    {
        //        Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
        //        Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
        //        spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
        //    }
        //    return true;
        //}
    }
}