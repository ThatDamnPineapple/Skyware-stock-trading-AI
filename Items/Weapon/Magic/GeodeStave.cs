using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class GeodeStave : ModItem
	{
		public override void SetDefaults()
		{
            
			item.name = "Geode Staff";
			item.damage = 35;
			item.magic = true;
			item.mana = 20;
			item.width = 22;
			item.height = 34;
			item.useTime = 31;
			item.useAnimation = 31;
			item.useStyle = 5;
			Item.staff[item.type] = true; 
			item.noMelee = true; 
			item.knockBack = 3;
			item.value = 9000;
			item.rare = 4;
			item.UseSound = SoundID.Item20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("GeodeStaveProjectile");
			item.shootSpeed = 4;
            item.crit = 6;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Geode", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

        }

	}
}
