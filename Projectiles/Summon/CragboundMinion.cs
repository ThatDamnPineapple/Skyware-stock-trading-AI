using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Summon
{
    public class CragboundMinion : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Twinkle Popper";
            projectile.width = 48;
            projectile.height = 48;
            projectile.timeLeft = 3600;
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.minion = true;
            projectile.minionSlots = 0;
        }
        public override bool PreAI()
        {

            projectile.ai[0]++;
            if (projectile.ai[0] >= 60)
            {
                if (projectile.ai[0] % 5 == 0)
                {
                    for (int i = 0; i < 200; ++i)
                    {
                        if (Main.npc[i].active && (projectile.position - Main.npc[i].position).Length() < 180 && Main.npc[i].CanBeChasedBy(projectile))
                        {
                            projectile.direction = Main.npc[i].position.X < projectile.position.X ? -1 : 1;

                            Vector2 position = new Vector2(projectile.position.X + projectile.width * 0.5f + Main.rand.Next(201) * -projectile.direction + (Main.npc[i].position.X - projectile.position.X), projectile.Center.Y - 600f);
                            position.X = (position.X * 10f + projectile.position.X) / 11f + (float)Main.rand.Next(-100, 101);
                            position.Y -= 150;
                            float speedX = (float)Main.npc[i].position.X - position.X;
                            float speedY = (float)Main.npc[i].position.Y - position.Y;
                            if (speedY < 0f)
                                speedY *= -1f;
                            if (speedY < 20f)
                                speedY = 20f;

                            float length = (float)Math.Sqrt((double)(speedX * speedX + speedY * speedY));
                            length = 12 / length;
                            speedX *= length;
                            speedY *= length;
                            speedX = speedX + (float)Main.rand.Next(-40, 41) * 0.03f;
                            speedY = speedY + (float)Main.rand.Next(-40, 41) * 0.03f;
                            speedX *= (float)Main.rand.Next(75, 150) * 0.01f;
                            position.X += (float)Main.rand.Next(-50, 51);
                            Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("AtlasSphere"), projectile.damage, projectile.knockBack, projectile.owner);
                            break;
                        }
                    }
                }

                if (projectile.ai[0] >= 90)
                    projectile.ai[0] = 0;
            }

            return true;
        }
        public override void AI()
        {
            projectile.ai[1] += 1f;
            if (projectile.ai[1] >= 7200f)
            {
                projectile.alpha += 5;
                if (projectile.alpha > 255)
                {
                    projectile.alpha = 255;
                    projectile.Kill();
                }
            }
            projectile.localAI[0] += 1f;
            if (projectile.localAI[0] >= 10f)
            {
                projectile.localAI[0] = 0f;
                int num416 = 0;
                int num417 = 0;
                float num418 = 0f;
                int num419 = projectile.type;
                for (int num420 = 0; num420 < 1000; num420++)
                {
                    if (Main.projectile[num420].active && Main.projectile[num420].owner == projectile.owner && Main.projectile[num420].type == num419 && Main.projectile[num420].ai[1] < 3600f)
                    {
                        num416++;
                        if (Main.projectile[num420].ai[1] > num418)
                        {
                            num417 = num420;
                            num418 = Main.projectile[num420].ai[1];
                        }
                    }
                    if (num416 > 1)
                    {
                        Main.projectile[num417].netUpdate = true;
                        Main.projectile[num417].ai[1] = 36000f;
                        return;
                    }
                }
            }
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            return false;
        }

        public override void TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = 26;
            height = projectile.height;
            fallThrough = false;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
    }
}
