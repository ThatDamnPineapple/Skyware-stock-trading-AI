using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class SoulSiphonProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Soul Siphon";
            projectile.width = 200;
            projectile.height = 200;

            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;

            projectile.alpha = 255;
            projectile.timeLeft = 3;
            projectile.penetrate = -1;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("SoulSiphon"), 240, false);
        }
    }
}
