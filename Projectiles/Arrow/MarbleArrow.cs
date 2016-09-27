using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
    public class MarbleArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.damage = 14;
			projectile.name = "Marble Arrow";
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.BoneArrow;
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            damage = damage + (target.defense);
        }
    }
}
