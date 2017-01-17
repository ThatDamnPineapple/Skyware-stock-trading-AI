using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class GeodeShuriken : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Shuriken);
            item.name = "Geode Shuriken";
            item.width = 26;
            item.height = 26;           
            item.shoot = mod.ProjectileType("GeodeShurikenProjectile");
            item.useAnimation = 16;
            item.useTime = 16;
            item.shootSpeed = 11f;
            item.damage = 35;
            item.knockBack = 1.0f;
			item.value = Terraria.Item.sellPrice(0, 0, 3, 0);
            item.crit = 6;
            item.rare = 4;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"Geode", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}
