using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class Fireball : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.LostSoulFriendly);
            projectile.damage = 124;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 1;
            aiType = ProjectileID.LostSoulFriendly;
            Main.projFrames[projectile.type] = 4;
        }

        public override void AI()
        {
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
            }
        }
    }
}
