using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.WitherArmor
{
    public class WitherPlate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Wither Chestplate";
            item.width = 24;
            item.height = 24;
            AddTooltip("Increases Damage by 18%");
            item.value = 120000;
            item.rare = 8;
            item.defense = 23;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.18f;
            player.meleeDamage += 0.18f;
            player.thrownDamage += 0.18f;
            player.rangedDamage += 0.18f;
			player.minionDamage += 0.18f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NightmareFuel", 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
