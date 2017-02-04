using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class BismiteLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Bismite Leggings";
            item.width = 22;
            item.height = 18;
            AddTooltip("Increases critical strike chance by 2%");
            item.value = 4000;
            item.rare = 2;
            item.defense = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 2;
            player.meleeCrit += 2;
            player.thrownCrit += 2;
            player.rangedCrit += 2;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BismiteCrystal", 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
