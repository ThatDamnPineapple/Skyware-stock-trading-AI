using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Summon
{
    public class CragboundMinion : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Cragbound Minion";
            projectile.width = 26;
            projectile.height = 48;

            projectile.minion = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.netImportant = true;

            projectile.alpha = 0;
            projectile.timeLeft *= 5;
            projectile.penetrate = -1;
            projectile.minionSlots = 1;
        }

        public override bool PreAI()
        {
            MyPlayer mp = Main.player[projectile.owner].GetModPlayer<MyPlayer>(mod);
            if (mp.player.dead)
            {
                mp.cragboundMinion = false;
            }
            if (mp.cragboundMinion)
            {
                projectile.timeLeft = 2;
            }

            return false;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            return false;
        }

        public override void TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
        {
            width = 26;
            height = projectile.height;
            fallThrough = false;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            return false;
        }
    }
}
