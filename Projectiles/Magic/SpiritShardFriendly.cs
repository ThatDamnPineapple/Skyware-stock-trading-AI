using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class SpiritShardFriendly : ModProjectile
    {
        int target;
        // USE THIS DUST: 261
        public override void SetDefaults()
        {
            projectile.name = "Spirit Shard";
            projectile.width = projectile.height = 12;

            projectile.hostile = false;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;

            projectile.penetrate = 1;

            projectile.timeLeft = 60;
        }
        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            int proj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("SpiritBoom"), (int)(projectile.damage), 0, Main.myPlayer);
            Projectile newProj2 = Main.projectile[proj];
            newProj2.friendly = true;
            newProj2.hostile = false;
        }
        public override bool PreAI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + 1.57F;

            float lowestDist = float.MaxValue;
            for (int i = 0; i < 200; ++i)
            {
                NPC npc = Main.npc[i];
                //if npc is a valid target (active, not friendly, and not a critter)
                if (npc.active && npc.CanBeChasedBy(projectile))
                {
                    //if npc is within 50 blocks
                    float dist = projectile.Distance(npc.Center);
                        //if npc is closer than closest found npc
                        if (dist < lowestDist)
                        {
                            lowestDist = dist;

                            //target this npc
                            projectile.ai[1] = npc.whoAmI;
                        }
                    }
                }
            NPC target = (Main.npc[(int)projectile.ai[1]] ?? new NPC()); //our target
                Vector2 direction = target.Center - projectile.Center;
            direction.Normalize();
            projectile.velocity *= 0.98f;
            int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 206, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust2].noGravity = true;
            if (Math.Sqrt((projectile.velocity.X * projectile.velocity.X) + (projectile.velocity.Y * projectile.velocity.Y)) >= 7f)
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 206, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = 2f;
                dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 206, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = 2f;
            }
            if (Math.Sqrt((projectile.velocity.X * projectile.velocity.X) + (projectile.velocity.Y * projectile.velocity.Y)) < 14f)
            {
                if (Main.rand.Next(24) == 1)
                {
                    direction.X = direction.X * Main.rand.Next(20, 24);
                    direction.Y = direction.Y * Main.rand.Next(20, 24);
                    projectile.velocity.X = direction.X;
                    projectile.velocity.Y = direction.Y;
                }
            }
            return false;
        }

        public override void SendExtraAI(System.IO.BinaryWriter writer)
        {
            writer.Write(this.target);
        }
        public override void ReceiveExtraAI(System.IO.BinaryReader reader)
        {
            this.target = reader.Read();
        }
    }
}
