using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpiritMod.Projectiles.Magic
{
    public class StarfallProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.CloneDefaults(82);
			projectile.hostile = false;
			projectile.magic = true;
			projectile.name = "StarfallProj";
			projectile.width = 28;
			projectile.light = 0.5f;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.damage = 10;

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(3) == 0) target.AddBuff(mod.BuffType("StarFracture"), 280);
        }
        public override void AI()
		{
			projectile.rotation = projectile.velocity.ToRotation() + (float)(Math.PI/2);
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 87);
            }
		}
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 87);
            }
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
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