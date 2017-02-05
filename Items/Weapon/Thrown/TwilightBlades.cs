using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Thrown
{
	public class TwilightBlades : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Shuriken);
            item.name = "Twilight Blades";
            item.width = 32;
            item.height = 32;           
            item.shoot = mod.ProjectileType("TwilightBladesProjectile");
            item.toolTip = "Occasionally inflicts Confused Debuff on hit";
            item.useAnimation = 18;
            item.useTime = 18;
            item.shootSpeed = 12f;
            item.damage = 60;
            item.knockBack = 0f;
			item.value = Terraria.Item.buyPrice(0, 0, 2, 50);
            item.crit = 8;
            item.rare = 6;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.HallowedBar, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 1);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 111);
            recipe.AddRecipe();
        }
    }
}