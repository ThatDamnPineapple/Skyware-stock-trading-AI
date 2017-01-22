using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.WitherArmor
{
    public class WitherLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Wither Greaves";
            item.width = 22;
            item.height = 18;
            item.value = 90000;
            item.rare = 8;
            item.defense = 19;
            item.toolTip = "Increases critical strike chance by 15%";
        }
        public override void UpdateEquip(Player player)
        {

            player.magicCrit += 15;
            player.meleeCrit += 15;
            player.rangedCrit += 15;
            player.thrownCrit += 15;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NightmareFuel", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
