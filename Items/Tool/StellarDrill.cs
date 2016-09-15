using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Items.Tool
{
	public class StellarDrill : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Stellar Drill";
			item.damage = 11;
			item.melee = true;
			item.width = 48;
			item.height = 22;
			item.useTime = 11;
			item.useAnimation = 32;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 34;
			item.useStyle = 5;
			item.knockBack = 0;
			item.rare = 5;
			item.useSound = 23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("StellarDrillProjectile");
			item.shootSpeed = 40f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StellarBar", 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
