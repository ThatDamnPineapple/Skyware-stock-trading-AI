using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Ammo
{
	public class MarsBullet : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Electrified Bullet";
			item.damage = 13;
			item.ranged = true;
			item.width = 8;
			item.height = 16;
			item.maxStack = 999;
			item.toolTip = "All Charged up!";
			item.consumable = true;
			item.knockBack = 1.5f;
			item.value = 1000;
			item.rare = 8;
			item.shoot = mod.ProjectileType("MarsBulletProj");
			item.shootSpeed = 16f;
			item.ammo = ProjectileID.Bullet;
		}

        public override void AddRecipes()
        {
            ModRecipe rcp = new ModRecipe(mod);
            rcp.AddIngredient(null, "MartianCore", 1);
            rcp.AddTile(TileID.MythrilAnvil);
            rcp.SetResult(this, 70);
            rcp.AddRecipe();
        }
	}
}