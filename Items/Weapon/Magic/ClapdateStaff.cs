using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class ClapdateStaff : ModItem
    {
		private Vector2 newVect;
        public override void SetDefaults()
        {
            item.name = "Clapdated Staff";
            item.damage = 15;
            item.magic = true;
            item.mana = 8;
            item.width = 46;
            item.height = 46;
            item.useTime = 22;
            item.crit += 2;
            item.useAnimation = 22;
            item.useStyle = 5;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 3.5f;
            item.value = 20000;
            item.rare = 2;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("Sandstorm");
            item.shootSpeed = 9f;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Carapace", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
