using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class SpiritBodyArmor : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Spirit Body Armor";
            item.width = 34;
            item.height = 30;
            AddTooltip("Increases melee damage and critical strike chance by 10%, as well as reducing damage taken by 10%");
            item.value = 50000;
            item.rare = 5;
            item.defense = 18;
        }

        public override void UpdateEquip(Player player)
        {

            player.meleeDamage += 0.10f;
            player.meleeCrit += 10;

            player.endurance = .10f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritBar", 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}