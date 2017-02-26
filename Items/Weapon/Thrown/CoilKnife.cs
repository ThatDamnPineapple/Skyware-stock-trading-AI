using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class CoilKnife : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Shuriken);
            item.name = "Coil Knife";
            item.width = 26;
            item.height = 26;
            item.toolTip = "Flies in brilliant arcs \n Occasionally burns foes";  
            item.shoot = mod.ProjectileType("CoilKnifeProjectile");
            item.useAnimation = 18;
            item.useTime = 18;
            item.shootSpeed = 11f;
            item.damage = 21;
            item.knockBack = 1.0f;
			item.value = Terraria.Item.sellPrice(0, 0, 1, 0);
            item.crit = 6;
            item.rare = 2;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null,"TechDrive", 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}
