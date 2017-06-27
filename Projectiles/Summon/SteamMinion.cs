using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Summon
{
    public class SteamMinion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Starplate Minion");
            Main.projFrames[base.projectile.type] = 1;
            ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
            ProjectileID.Sets.Homing[base.projectile.type] = true;

        }
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.OneEyedPirate);
            projectile.width = 32;
            projectile.height = 20;
            projectile.minion = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.netImportant = true;
			aiType = ProjectileID.OneEyedPirate;
            projectile.alpha = 0;
            projectile.penetrate = -1;
			projectile.timeLeft = 18000;
            projectile.minionSlots = 1;
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
        int timer = 0;

        public override void AI()
        {
            timer++;

            if (timer == 350)
            {
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 1000 + Main.rand.Next(-50, 50), 0, Main.rand.Next(8, 14), mod.ProjectileType("StarTrail1"), projectile.damage, 2, Main.myPlayer);
                timer = 0;
            }
            bool flag64 = projectile.type == mod.ProjectileType("SteamMinion");
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            if (flag64)
            {
                if (player.dead)
                {
                    modPlayer.steamMinion = false;
                }
                if (modPlayer.steamMinion)
                {
                    projectile.timeLeft = 2;
                }
            }
        }
        public override bool MinionContactDamage()
		{
			return true;
		}
	}
}