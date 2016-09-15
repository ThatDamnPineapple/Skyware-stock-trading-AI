using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Arrow
{
	class BeetleArrow : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			projectile.name = "Beetle Arrow";
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			if (projectile.owner == Main.myPlayer)
			{
				Main.player[Main.myPlayer].AddBuff(Buffs.BeetleFortitude._ref.Type, 180);
			}
		}

		public override void OnHitPvp(Player target, int damage, bool crit)
		{
			if (projectile.owner == Main.myPlayer)
			{
				Main.player[Main.myPlayer].AddBuff(Buffs.BeetleFortitude._ref.Type, 180);
			}
		}
	}
}
