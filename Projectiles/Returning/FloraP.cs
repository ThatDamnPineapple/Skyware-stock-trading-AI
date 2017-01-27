using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Returning
{
	public class FloraP : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.name = "Florang";
			projectile.width = 40;
			projectile.height = 40;
			projectile.aiStyle = 3;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.magic = false;
			projectile.penetrate = 3;
			projectile.timeLeft = 600;
			projectile.light = 0.5f;
			projectile.extraUpdates = 1;
			
			
		}
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            {
                target.AddBuff(BuffID.Posioned, 240);
            }
            base.OnHitNPC(target, damage, knockback, crit);
        }


    }
}
