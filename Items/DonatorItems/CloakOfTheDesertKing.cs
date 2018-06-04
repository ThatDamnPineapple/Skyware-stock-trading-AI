using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems
{
	class CloakOfTheDesertKing : ModItem
	{
		public static readonly int _type;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cloak of the Desert King");
			Tooltip.SetDefault("~Donator Item~");
		}

		public override void SetDefaults()
		{
			item.UseSound = SoundID.Item2;
			item.useAnimation = 20;
			item.useTime = 20;

			item.width = 22;
			item.height = 12;

			item.value = 60000;
			item.rare = 6;
			item.noMelee = true;

			item.buffType = RabbitOfCaerbannogBuff._type;
			item.shoot = Projectiles.DonatorItems.RabbitOfCaerbannog._type;
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrimsonCloak);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
