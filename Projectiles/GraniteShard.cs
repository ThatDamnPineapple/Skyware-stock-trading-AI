using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Projectiles
{
    public class GraniteShard : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Granite Shard";
            projectile.width = 6;
            projectile.height = 11;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.penetrate = 5;
            projectile.timeLeft = 600;
            projectile.light = 1f;
            projectile.extraUpdates = 1;
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            aiType = ProjectileID.CrystalShard;
        }

        public override void OnHitNPC(NPC tmcwashere, int damage, float knockback, bool crit)
        {
            {
                tmcwashere.AddBuff(BuffID.Frostburn, 120);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            {
                projectile.Kill();
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 3; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 240);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }
    }
}