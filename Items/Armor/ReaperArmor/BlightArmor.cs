using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.ReaperArmor
{
    public class BlightArmor : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Reaper's Breastplate";
            item.width = 34;
            item.height = 24;
            AddTooltip("Increases melee speed and movement speed by 18%");
            item.value = 120000;
            item.rare = 8;
            item.defense = 26;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeSpeed += 0.18f;
            player.moveSpeed += 0.18f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CursedFire", 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
