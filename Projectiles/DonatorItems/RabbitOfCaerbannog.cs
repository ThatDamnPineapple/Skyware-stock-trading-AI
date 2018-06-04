using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.Items.DonatorItems;

namespace SpiritMod.Projectiles.DonatorItems
{
	class RabbitOfCaerbannog : ModProjectile
	{
		public static readonly int _type;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Rabbit of Caerbannog");
			Main.projFrames[projectile.type] = 7;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults()
		{
			projectile.netImportant = true;
			projectile.width = 30;
			projectile.height = 30;
			projectile.aiStyle = 26;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.timeLeft *= 5;
			aiType = ProjectileID.BlackCat;
		}

		public override void AI()
		{
			var owner = Main.player[projectile.owner];
			if (owner.active && owner.HasBuff(RabbitOfCaerbannogBuff._type))
				projectile.timeLeft = 2;
		}
	}
}
