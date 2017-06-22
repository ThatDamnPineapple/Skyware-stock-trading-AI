/*using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class EtherealFlame : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ethereal Wisp");
			Tooltip.SetDefault("'It seems to draw Spirits toward it...'");
		}


        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 26;
            item.rare = 6;
            item.maxStack = 99;
            item.value = 10000;
            item.shootSpeed = 5f;
            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = false;
            item.autoReuse = false;

            item.UseSound = SoundID.Item12;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(null, "SpiritBar", 4);
            modRecipe.AddIngredient(ItemID.SoulofSight, 1);
            modRecipe.AddTile(134);
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();

            ModRecipe modRecipe1 = new ModRecipe(mod);
            modRecipe1.AddIngredient(null, "SpiritBar", 4);
            modRecipe1.AddIngredient(ItemID.SoulofMight, 1);
            modRecipe1.AddTile(134);
            modRecipe1.SetResult(this, 1);
            modRecipe1.AddRecipe();


            ModRecipe modRecipe2 = new ModRecipe(mod);
            modRecipe2.AddIngredient(null, "SpiritBar", 4);
            modRecipe2.AddIngredient(ItemID.SoulofFright, 1);
            modRecipe2.AddTile(134);
            modRecipe2.SetResult(this, 1);
            modRecipe2.AddRecipe();
        }

    }
}*/
