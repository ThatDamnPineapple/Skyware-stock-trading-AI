using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.AcidArmor
{
    public class AcidLegs : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Acid Leggings";
            item.width = 22;
            item.height = 18;
            AddTooltip("Increases movement speed by 12%");
            item.value = 16000;
            item.rare = 5;
            item.defense = 7;
        }
		public override void UpdateEquip(Player player)
        {
            player.maxRunSpeed += 0.12f;
            player.runAcceleration += 0.12f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Acid", 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
