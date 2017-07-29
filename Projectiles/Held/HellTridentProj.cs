using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Held
{
    public class HellTridentProj : ModProjectile
    {
        int timer = 10;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fury of the Underworld");
        }
        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.Trident);
            projectile.height = 122;
            projectile.width = 122;
            aiType = ProjectileID.Trident;
        }      
        public override void AI()
        {
            timer--;

            if (timer == 0)
            {
                Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 8);
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("HellTridentProj1"), projectile.damage / 3 * 2, projectile.knockBack, projectile.owner, 0f, 0f);
                timer = 20;
            }
        }
    }
}