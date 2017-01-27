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
        item.toolTip = "Flies straight and occasionally inflicts Ichor";
        item.useTime = 24;
        item.useAnimation = 24;
        item.useStyle = 1;
		item.shootSpeed = 10f;
		item.shoot = mod.ProjectileType("GoreShurikenProjectile");
        item.knockBack = 0;
		item.UseSound = SoundID.Item1;
		item.scale = 1f;
        item.value = 1000;
        item.rare = 5;
        item.UseSound = SoundID.Item1;
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
