using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Thrown
{
    public class PestilentShurikenProjectile : ModProjectile
    {
	    public override void SetDefaults()
	    {
		    projectile.name = "Pestilent Shuriken";
		    projectile.width = 22;
		    projectile.height = 22;

		    projectile.aiStyle = 2;

		    projectile.thrown = true;
		    projectile.friendly = true;

		    projectile.alpha = 0;
            projectile.penetrate = 4;
        }

	    public override bool OnTileCollide(Vector2 oldVelocity)
	    {
		    projectile.penetrate--;
		    if (projectile.penetrate <= 0)
		    {
			    projectile.Kill();
		    }
       
		    if (projectile.velocity.X != oldVelocity.X)
		    {
			    projectile.velocity.X = -oldVelocity.X;
		    }
		    if (projectile.velocity.Y != oldVelocity.Y)
		    {
			    projectile.velocity.Y = -oldVelocity.Y * 1.3f;
		    }
		    Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);
		    return false;
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
