using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Items.Tool
{
	public class RunicDrill : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Runic Drill";
			item.damage = 23;
			item.melee = true;
			item.width = 54;
			item.height = 26;
			item.useTime = 7;
			item.useAnimation = 25;
			item.channel = true;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.pick = 190;
			item.useStyle = 5;
			item.knockBack = 0;
			item.rare = 5;
			item.useSound = 23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("RunicDrillProjectile");
			item.shootSpeed = 40f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Rune", 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
