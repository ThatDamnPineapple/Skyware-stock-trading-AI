using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class CirrusCharm : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Cirrus Crystal";
            item.width = 36;
            item.height = 28;
            AddTooltip("Greatly increases jump height \n Leave a trail of chilly embers as you walk");
            AddTooltip("Throwing weapons may inflict Soul Burn");
            AddTooltip("Magic attacks may inflict Frostburn");
            item.value = Item.sellPrice(0, 2, 33, 0);
            item.rare = 5;
            item.defense = 3;
            item.accessory = true;
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.jumpSpeedBoost += 6f;
            player.GetModPlayer<MyPlayer>(mod).icytrail = true;
            player.GetModPlayer<MyPlayer>(mod).icySoul = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrigidWind", 1);
            recipe.AddIngredient(null, "FrostSoul", 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
