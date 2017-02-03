using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.DonatorItems
{
    public class PhoenixMinion : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Fiery Phoenix";
            projectile.friendly = true;
            projectile.magic = true;
            projectile.width = 72;
            projectile.height = 64;
            projectile.penetrate = -1;
            projectile.timeLeft = 6000;
            Main.projFrames[projectile.type] = 8;
        }
        int timer = 20;

        public override void AI()
        {
            {
                projectile.spriteDirection = projectile.direction;
            }
            timer--;

            if (timer == 0)
            {
                int newProj = Projectile.NewProjectile(projectile.Center.X + 5, projectile.Center.Y + 3,
                    0, -4,
                    ProjectileID.BallofFire, projectile.damage, 0, projectile.owner);
                Main.projectile[newProj].hostile = false;
                Main.projectile[newProj].friendly = true;
                timer = 120;
            }
            {
                projectile.tileCollide = true;
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 6, 0f, 0f);
            }
            projectile.frameCounter++;
            if (projectile.frameCounter >= 4)
            {
                projectile.frame = (projectile.frame + 1) % Main.projFrames[projectile.type];
                projectile.frameCounter = 0;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
                target.AddBuff(BuffID.OnFire, 180);
        }
    }
}

