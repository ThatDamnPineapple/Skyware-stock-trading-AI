using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
    public class PestilentArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pestilent Arrow");
        }
        public override void SetDefaults()
        {
            projectile.width = 9;
            projectile.height = 17;

            projectile.aiStyle = 1;
            aiType = ProjectileID.WoodenArrowFriendly;

            projectile.ranged = true;
            projectile.friendly = true;
        }

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("BlightedFlames"), 60, false);
            }
            MyPlayer mp =  Main.player[projectile.owner].GetModPlayer<MyPlayer>(mod);
            mp.PutridHits++;
			if (mp.putridSet && mp.PutridHits >= 4)
			{
			    Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("CursedFlame"), projectile.damage, 0f, projectile.owner, 0f, 0f);
                mp.PutridHits = 0;
			}
        }
        public override void Kill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 75);
            }
            Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y);
        }
    }
}
