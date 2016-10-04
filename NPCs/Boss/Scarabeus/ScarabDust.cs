using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Boss.Scarabeus
{
    public class ScarabDust : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.name = "Scarabeus";

           projectile.width = 10;
			projectile.height = 10;
			projectile.aiStyle = -1;
			projectile.friendly = false;
			projectile.hostile = true;
			projectile.penetrate = 4;
			projectile.alpha = 255;
			projectile.timeLeft = 20;
        }

        public override bool PreAI()
        {
            int newDust = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 4f), 8, 8, 85, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
            newDust = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 4f), 8, 8, 36, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);
			newDust = Dust.NewDust(new Vector2(projectile.position.X - projectile.velocity.X * 4f + 2f, projectile.position.Y + 2f - projectile.velocity.Y * 4f), 8, 8, 32, projectile.oldVelocity.X, projectile.oldVelocity.Y, 100, default(Color), 1.25f);

            return false;
        }
    }
}
