using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Summon
{
    public class LihzahrdMinion : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.OneEyedPirate);
            projectile.name = "Lihzahrd Minion";
            projectile.width = 32;
            projectile.height = 40;
            projectile.minion = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.netImportant = true;
			aiType = ProjectileID.OneEyedPirate;
            projectile.alpha = 0;
            projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
            projectile.minionSlots = 1;
            Main.projFrames[projectile.type] = 11;
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
			bool flag64 = projectile.type == mod.ProjectileType("LihzahrdMinion");
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (flag64)
			{
				if(player.dead)
				{
					modPlayer.lihzahrdMinion = false;
				}
				if (modPlayer.lihzahrdMinion)
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