using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.FieryArmor
{
    public class ObsidiusGreaves : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Fiery Leggings";
            item.width = 30;
            item.height = 20;
            AddTooltip("Increases throwing critical strike chance by 5% and movement speed by 8%");
            item.value = 24000;
            item.rare = 4;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 5;
            player.moveSpeed += 0.08f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CarvedRock", 19);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
