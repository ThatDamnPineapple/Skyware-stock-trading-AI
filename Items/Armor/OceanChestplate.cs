using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class OceanChestplate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Diver's Chestplate";
            item.width = 26;
            item.height = 18;
            item.value = 1200;
            AddTooltip("Increases movement speed by 6% \n Allows the player to breathe underwater");
            item.rare = 1;
            item.defense = 5;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.06f;
            player.ignoreWater = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 8);
            recipe.AddIngredient(ItemID.Seashell, 2);
            recipe.AddIngredient(ItemID.BottledWater, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}