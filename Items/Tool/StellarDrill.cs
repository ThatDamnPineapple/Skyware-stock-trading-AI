using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
	public class StellarDrill : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Stellar Drill";
            item.width = 48;
            item.height = 22;
            item.rare = 5;

            item.pick = 34;

            item.damage = 11;
            item.knockBack = 0;

            item.useStyle = 5;
            item.useTime = 11;
			item.useAnimation = 32;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.noUseGraphic = true;

			item.shoot = mod.ProjectileType("StellarDrillProjectile");
			item.shootSpeed = 40f;

            item.UseSound = SoundID.Item23;
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
