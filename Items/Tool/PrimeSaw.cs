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
            item.width = 62;
            item.height = 20;
            item.value = 80000;
            item.rare = 5;

            item.axe = 18;

            item.damage = 62;
            item.knockBack = 8;

            item.useStyle = 5;
            item.useTime = 35;
            item.useAnimation = 30;

            item.channel = true;
            item.useTurn = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.noUseGraphic = true;

            item.shoot = mod.ProjectileType("PrimeSawProj");
            item.shootSpeed = 40f;
			item.melee = true;
            item.useSound = 23;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PrintPrime");
            recipe.AddIngredient(ItemID.HallowedBar, 6);
            recipe.AddIngredient(ItemID.SoulofFright, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}