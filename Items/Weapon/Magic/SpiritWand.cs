using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class SpiritWand : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Spirit Wand";
			item.damage = 50;
			item.magic = true;
			item.mana = 14;
			item.width = 44;
			item.height = 44;
			item.toolTip = "Shoots out Soul Burning spirits that travel along the ground";
			item.useTime = 27;
			item.useAnimation = 32;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 5;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 5;
			item.UseSound = SoundID.Item8;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("EarthSpirit");
			item.shootSpeed = 8f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritBar", 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}