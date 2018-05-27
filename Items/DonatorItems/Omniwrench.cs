using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems
{
	class Omniwrench : ModItem
	{
		public static readonly int _type;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omniwrench");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 12;
			item.useStyle = 1;

			item.value = 1000000;
			item.rare = 11;

			item.damage = 180;
			item.knockBack = 7f;
			item.melee = true;
			item.autoReuse = true;
			item.shootSpeed = 12f;

			item.pick = 225;
			item.tileBoost = 5;

			item.useTime = 18;
			item.useAnimation = 18;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.shoot = Projectiles.DonatorItems.Omniwrench._type;
				item.noUseGraphic = true;
				item.noMelee = true;
			}
			else
			{
				item.shoot = 0;
				item.noUseGraphic = false;
				item.noMelee = false;
			}
			return player.ownedProjectileCounts[Projectiles.DonatorItems.Omniwrench._type] == 0;
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MulticolorWrench);
			recipe.AddIngredient(ItemID.ExtendoGrip);
			recipe.AddIngredient(ItemID.LunarBar, 12);
			recipe.AddIngredient(ItemID.FragmentStardust, 20);
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
