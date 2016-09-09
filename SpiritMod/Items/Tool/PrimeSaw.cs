using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class PrimeSaw : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Prime Saw";
            item.damage = 62;
            item.channel = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.width = 62;
            item.useSound = 23;
            item.height = 20;
            item.useTime = 35;
            item.useAnimation = 30;
            item.axe = 18;
            item.useStyle = 5;
            item.knockBack = 8;
            item.value = 80000;
            item.rare = 5;
            item.autoReuse = true;
            item.useTurn = true;
            item.shoot = mod.ProjectileType("PrimeSawProj");
            item.shootSpeed = 40f;
        }
            public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PrintPrime", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 6);
            recipe.AddIngredient(ItemID.SoulofFright, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}