using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class CursedKnife : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Cursed Knife";
            item.useStyle = 1;
            item.width = 24;
            item.height = 24;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.thrown = true;
            item.channel = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("CursedKnifeProjectile");
            item.useAnimation = 13;
            item.useTime = 13;
            item.consumable = true;
            item.maxStack = 999;
            item.shootSpeed = 8.0f;
            item.damage = 47;
            item.knockBack = 3.5f;
			item.value = Item.sellPrice(0, 0, 1, 0);
            item.crit = 16;
            item.rare = 5;
            item.autoReuse = true;
			item.maxStack = 999;
			item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CursedFlame, 1);
            recipe.AddIngredient(ItemID.EbonstoneBlock, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}