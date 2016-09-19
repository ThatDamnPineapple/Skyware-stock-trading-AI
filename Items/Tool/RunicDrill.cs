using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
	public class RunicDrill : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Runic Drill";
            item.width = 54;
            item.height = 26;
            item.rare = 5;

            item.pick = 190;

            item.damage = 23;
            item.knockBack = 0;

            item.useStyle = 5;
            item.useTime = 7;
			item.useAnimation = 25;

            item.melee = true;
            item.channel = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.noUseGraphic = true;

            item.shoot = mod.ProjectileType("RunicDrillProjectile");
			item.shootSpeed = 40f;

            item.useSound = 23;
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
