using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpiritMod.Projectiles.Sword
{
    public class TimeWinderClone : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Time Winder Clone";
            projectile.damage = 34;
            projectile.width = 20;
            projectile.height = 26;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 300;
            projectile.alpha = 100;
            projectile.light = 0.5f;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            ProjectileID.Sets.Homing[projectile.type] = true;
            projectile.aiStyle = 0;
            Main.projFrames[projectile.type] = 15;
        }

        public override void AI()
        {
            projectile.frameCounter++;
            if (projectile.frameCounter >= 20)
            {
                projectile.frameCounter = 0;
                projectile.frame = (projectile.frame + 1) % 15;
            }

            {
                projectile.spriteDirection = projectile.velocity.X > 0 ? 1 : -1;
            }
        }

        public void Kill()
        {
            Dust.NewDust(projectile.position, projectile.width, projectile.height, 7, 0, 0, 0, default(Color), 1f);
        }

        public void OnHitNPC(Player p, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(4) == 1)
            {
                Vector2 velocity = new Vector2(p.direction, 0) * 4f;
                int proj = Terraria.Projectile.NewProjectile(p.Center.X, p.position.Y + p.height + -35, velocity.X, velocity.Y, mod.ProjectileType("TimeWinderClone"), damage = 60, projectile.owner, 0, 0f);
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 36, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.75f);
            Main.dust[DustID].noGravity = true;
            return true;
        }

        public bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}
