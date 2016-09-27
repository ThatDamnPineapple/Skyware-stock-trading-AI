using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
    public class ScarabArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.damage = 8;
			projectile.name = "Scarab Arrow";
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.BoneArrow;
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
			if (Main.rand.Next(2) == 1)
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 8, 5, 0, mod.ProjectileType("ScarabProj"), projectile.damage, 0, projectile.owner);
			}
			else
			{
				Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 8, -5, 0, mod.ProjectileType("ScarabProj"), projectile.damage, 0, projectile.owner);
			}
            return true;
        }
    }
}
