using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class FoundryGun : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thermal Blaster");
			Tooltip.SetDefault("Shoots out a glob of bouncing magma at foes");
		}


        public override void SetDefaults()
        {
            item.damage = 50;
            item.ranged = true;
            item.width = 52;       
            item.height = 24;      
            item.useTime = 25;  
            item.useAnimation = 25;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 2.4f;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 4, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item45;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("BouncingMagma");
            item.shootSpeed = 14f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ThermiteBar", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
