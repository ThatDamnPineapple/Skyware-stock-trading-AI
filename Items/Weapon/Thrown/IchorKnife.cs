using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class IchorKnife : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ichor Knife";
            item.useStyle = 1;
            item.width = 9;
            item.height = 15;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.consumable = true;
            item.maxStack = 999;
            item.shoot = mod.ProjectileType("IchorKnifeProjectile");
            item.useAnimation = 14;
            item.useTime = 14;
            item.shootSpeed = 8.5f;
            item.damage = 48;
            item.knockBack = 3.5f;
			item.value = Terraria.Item.sellPrice(0, 0, 2, 0);
            item.crit = 20;
            item.rare = 5;
            item.autoReuse = true;
            item.maxStack = 999;
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FleshClump", 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}