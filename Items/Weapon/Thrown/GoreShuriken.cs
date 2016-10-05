using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace SpiritMod.Items.Weapon.Thrown {
public class GoreShuriken : ModItem
{
	
    public override void SetDefaults()
    {
        item.name = "Gore Shuriken";
        item.damage = 41;
		item.consumable = true;
        item.thrown = true;
		item.noMelee = true;
		item.noUseGraphic = true;
        item.width = 22;
        item.height = 22;
        item.toolTip = "Has a chance to inflict Cursed Inferno, bounces 3 times";
        item.useTime = 21;
        item.useAnimation = 21;
        item.useStyle = 1;
		item.shootSpeed = 10f;
		item.shoot = mod.ProjectileType("GoreShurikenProjectile");
        item.knockBack = 0;
		item.useSound = 1;
		item.scale = 1f;
        item.value = 10000;
        item.rare = 1;
        item.useSound = 1;
        item.autoReuse = true;
		item.maxStack = 999;
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FleshClump", 3);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 150);
            recipe.AddRecipe();
        }
}}
