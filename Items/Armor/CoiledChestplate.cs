using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class CoiledChestplate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Coiled Chestplate";
            item.width = 30;
            item.height = 20;
            AddTooltip("Increases critical strike chance by 8%");
            item.value = 32000;
            item.rare = 2;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 8;
            player.meleeCrit += 8;
            player.thrownCrit += 8;
            player.rangedCrit += 8;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TechDrive", 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
