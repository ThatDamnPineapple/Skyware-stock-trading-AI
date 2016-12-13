using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Summon
{
    public class GastropodMinion : ModProjectile
    {
        public override void SetDefaults()
        {
			projectile.CloneDefaults(ProjectileID.UFOMinion);
            projectile.name = "Gastropod Minion";
            projectile.width = 30;
            projectile.height = 34;
            projectile.minion = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.netImportant = true;
			aiType = ProjectileID.UFOMinion;
            projectile.alpha = 0;
            projectile.penetrate = -1;
			projectile.timeLeft = 18000;
			ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
			ProjectileID.Sets.Homing[projectile.type] = true;
            projectile.minionSlots = 1;
            Main.projFrames[projectile.type] = 4;
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
			bool flag64 = projectile.type == mod.ProjectileType("GastropodMinion");
			Player player = Main.player[projectile.owner];
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (flag64)
			{
				if(player.dead)
				{
					modPlayer.gasopodMinion = false;
				}
				if (modPlayer.gasopodMinion)
				{
					projectile.timeLeft =2;
				}
			}
		}
	}
}