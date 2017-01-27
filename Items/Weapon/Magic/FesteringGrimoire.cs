using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class FesteringGrimoire : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Festering Grimoire";
			item.damage = 42;
			item.magic = true;
			item.mana = 13;
			item.width = 40;
			item.height = 40;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 3;
			item.value = 4500;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("GrimoireScythe");
			item.shootSpeed = 2f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 8);
            recipe.AddIngredient(531, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}