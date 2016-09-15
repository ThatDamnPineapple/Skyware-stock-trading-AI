using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Boss
{
    public class Spark : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Spark";
            projectile.penetrate = 2;
			projectile.height = 36;
			projectile.width = 36;
			projectile.tileCollide = false;
			projectile.hostile = true;
			projectile.friendly = false;
            projectile.extraUpdates = 1;
            projectile.light = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;

        }
    }
}