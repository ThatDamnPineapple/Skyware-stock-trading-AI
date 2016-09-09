using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
    public class TeslaSpikeProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Tesla Spike Projectile";
            projectile.width = 32;
            projectile.height = 14;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = -1;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            aiType = ProjectileID.MartianTurretBolt;
            Main.projFrames[projectile.type] = 4;
            projectile.timeLeft = 150;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(0) == 0)
            {
                target.AddBuff(mod.BuffType("ElectrifiedV2"), 540, true);
            }
        }
        public override void AI()
        {
            if (Main.rand.Next(8) == 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 226);
            }
        }
    }
}
