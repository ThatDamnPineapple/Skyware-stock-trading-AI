using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Yoyo
{
	public class EyeOfTheInfernoProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Yelets);
            projectile.extraUpdates = 1;
			projectile.name = "Eye Of The Inferno";
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.Yelets;
        }

        public override bool PreAI()
        {
				projectile.frameCounter++;
				if (projectile.frameCounter >= 60)
				{
					projectile.frameCounter = 0;
							int randFire = Main.rand.Next(3);
                int newProj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 
                    Main.rand.Next(-300,300) / 100, Main.rand.Next(-3,3),
                    ProjectileID.GreekFire1 + randFire, projectile.damage, 0, projectile.owner);
                Main.projectile[newProj].hostile = false;
                Main.projectile[newProj].friendly = true;
				}
			return true;
        }
    }
}