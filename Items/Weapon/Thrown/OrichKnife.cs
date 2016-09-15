using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class OrichKnife : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Orichalcum Operator";
            item.useStyle = 1;
            item.width = 22;
            item.height = 22;
            item.noUseGraphic = true;
            item.useSound = 1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("OrichKnifeProjectile");
            item.useAnimation = 29;
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 29;
            item.shootSpeed = 7.0f;
            item.damage = 41;
            item.knockBack = 4f;
			item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 10;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.OrichalcumBar, 1);
            recipe.AddTile(134);
            recipe.SetResult(this, 20);
            recipe.AddRecipe();
        }
    }
}
