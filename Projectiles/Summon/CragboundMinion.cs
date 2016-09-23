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
            projectile.name = "Atlas";
            projectile.width = 26;
            projectile.height = 48;

            projectile.minion = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.netImportant = true;

            projectile.alpha = 0;
            projectile.timeLeft *= 5;
            projectile.penetrate = -1;
            projectile.minionSlots = 1;
        }

        public override bool PreAI()
        {
            MyPlayer mp = Main.player[projectile.owner].GetModPlayer<MyPlayer>(mod);
            if (mp.player.dead)
            {
                mp.cragboundMinion = false;
            }
            if (mp.cragboundMinion)
            {
                projectile.timeLeft = 2;
            }

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

            return false;
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
