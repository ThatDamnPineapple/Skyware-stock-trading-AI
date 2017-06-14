using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
    public class MartianGrenade : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Electrosphere Grenade");
			Tooltip.SetDefault("'WARNING- HIGH VOLTAGE. DANGEROUS FOR USER'");
		}


        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Grenade);
            item.shoot = mod.ProjectileType("Grenadeproj");
            item.useAnimation = 30;
            item.rare = 8;
            item.useTime = 34;
            item.damage = 110;
			item.value = 1900;
        }

        public override void AddRecipes()
        {
            ModRecipe rcp = new ModRecipe(mod);
            rcp.AddIngredient(null, "MartianCore", 1);
            rcp.AddTile(TileID.MythrilAnvil);
            rcp.SetResult(this, 20);
            rcp.AddRecipe();

        }
    }
}