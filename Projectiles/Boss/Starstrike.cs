using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Boss
{
    public class Starstrike : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Starstrike";
            projectile.penetrate = 600;
			projectile.hostile = true;
			projectile.friendly = false;
             projectile.extraUpdates = 1;
            projectile.light = 2;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;

        }
    }
}