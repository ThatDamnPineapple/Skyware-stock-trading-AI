using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class SkeletronHand : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Bone Cutter";
            item.useStyle = 1;
            item.width = 9;
            item.height = 15;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.thrown = true;
            item.toolTip = "Dashes through the air in rapid bursts";
            item.channel = true;
            item.noMelee = true;
            item.consumable = true;
            item.maxStack = 999;
            item.shoot = mod.ProjectileType("SkeletronHandProj");
            item.useAnimation = 27;
            item.useTime = 27;
            item.shootSpeed = 12f;
            item.damage = 19;
            item.knockBack = 3.5f;
			item.value = Item.buyPrice(0, 0, 1, 0);
            item.crit = 2;
            item.rare = 3;
            item.autoReuse = false;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3456, 1);
            recipe.AddTile(412);
            recipe.SetResult(this, 111);
            recipe.AddRecipe();
        }
    }
}