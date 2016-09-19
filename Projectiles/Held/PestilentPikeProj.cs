using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Held
{
    public class PestilentPikeProj : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Trident);
            projectile.name = "Pestilent Pike";
            
            aiType = ProjectileID.Trident;
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(2) == 0)
            {
                target.AddBuff(mod.BuffType("BlightedFlames"), 60, false);
            }
            MyPlayer mp = Main.player[projectile.owner].GetModPlayer<MyPlayer>(mod);
            mp.PutridHits++;
            if (mp.putridSet && mp.PutridHits >= 4)
            {
                Projectile.NewProjectile(projectile.position.X, projectile.position.Y, 0f, 0f, mod.ProjectileType("CursedFlame"), projectile.damage, 0f, projectile.owner, 0f, 0f);
                mp.PutridHits = 0;
            }
        }		
    }
}
