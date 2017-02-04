using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.GeodeArmor
{
    public class GeodeLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Geode Leggings";
            item.width = 28;
            item.height = 22;
            item.toolTip = "Increases throwing damage by 5% and increases throwing critical strike chance by 7%";
            item.value = 50000;
            item.rare = 5;

            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.05F;
            player.thrownCrit += 7;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Geode", 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
