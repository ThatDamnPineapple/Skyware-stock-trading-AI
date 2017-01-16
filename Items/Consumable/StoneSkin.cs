using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class StoneSkin : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Stone Skin";
            item.width = item.height = 16;
            item.toolTip = "???";
            item.rare = 4;
            item.maxStack = 99;

            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item43;
        }

        public override bool CanUseItem(Player player)
        {
            if (!NPC.AnyNPCs(mod.NPCType("Atlas")))
                return true;
            return false;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(15, (int)player.Center.X, (int)player.Center.Y, 0);
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 600, mod.NPCType("Atlas"));

            Main.NewText("The earth is trembling", 255, 60, 255);
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddIngredient(ItemID.CrimtaneBar, 6);
            recipe.AddIngredient(ItemID.GrassSeeds);
            recipe.AddIngredient(154, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();

            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddIngredient(ItemID.DemoniteBar, 6);
            recipe.AddIngredient(ItemID.GrassSeeds);
            recipe.AddIngredient(154, 10);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
