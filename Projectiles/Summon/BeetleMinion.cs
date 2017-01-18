using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Summon
{
    public class BeetleMinion : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.BabySlime);
            projectile.name = "Beetle";
            projectile.width = 32;
            projectile.height = 20;
            projectile.minion = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.netImportant = true;
			aiType = ProjectileID.BabySlime;
            projectile.alpha = 0;
            projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
            projectile.minionSlots = 1;
            Main.projFrames[projectile.type] = 5;
        }
		public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.penetrate == 0)
            {
                projectile.Kill();
            }
            return false;
        }
		public override void AI()
		{
			bool flag64 = projectile.type == mod.ProjectileType("BeetleMinion");
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (flag64)
			{
				if(player.dead)
				{
					modPlayer.beetleMinion = false;
				}
				if (modPlayer.beetleMinion)
				{
					projectile.timeLeft =2;
				}
			}
		}
		public override bool MinionContactDamage()
		{
			return true;
		}
	}
}