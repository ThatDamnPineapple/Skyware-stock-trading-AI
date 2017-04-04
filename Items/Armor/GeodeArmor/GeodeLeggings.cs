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
            item.toolTip = "Increases damage by 5% and increases critical strike chance by 6%";
            item.value = Terraria.Item.sellPrice(0, 0, 75, 0);
            item.rare = 5;

            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.05F;
            player.meleeDamage += 0.05F;
            player.minionDamage += 0.05F;
            player.magicDamage += 0.05F;
            player.rangedDamage += 0.05F;
            player.thrownCrit += 6;
            player.rangedCrit += 6;
            player.magicCrit += 6;
            player.meleeCrit += 6;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Geode", 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
