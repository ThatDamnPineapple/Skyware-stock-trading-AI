using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class GreatAwakening : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "The Great Awakening";
            item.toolTip = "'An almagamation of the waking and sleeping'\n Shoots out the flames of dawn surrounded by energies of dust \n Inflicts a multitude of debuffs \n Enemies hit are illuminanted by Holy Light";
			item.damage = 60;
			item.magic = true;
			item.mana = 13;
			item.width = 60;
			item.height = 60;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 3;
            item.value = Terraria.Item.sellPrice(0, 8, 0, 0);
            item.rare = 7;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FieryAura");
			item.shootSpeed = 26f;
		}
		
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DuskStone", 6);
            recipe.AddIngredient(null, "InfernalAppendage", 6);
            recipe.AddIngredient(null, "IlluminatedCrystal", 6);
            recipe.AddIngredient(ItemID.HallowedBar, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
