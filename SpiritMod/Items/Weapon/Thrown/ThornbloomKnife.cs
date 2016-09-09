using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class ThornbloomKnife : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Thornbloom Knife";
            item.useStyle = 1;
            item.width = 13;
            item.height = 18;
            item.noUseGraphic = true;
            item.useSound = 1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("ThornbloomKnifeProjectile");
            item.useAnimation = 13;
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 13;
            item.shootSpeed = 10.0f;
            item.damage = 78;
            item.knockBack = 4.5f;
			item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.crit = 4;
            item.rare = 10;
            item.autoReuse = true;
            //item.maxStack = 999;
            //item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}