using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class ChitinLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Chitin Leggings";
            item.width = 22;
            item.height = 18;
			             AddTooltip("Increases magic and ranged damage by 4%");
			 AddTooltip("+5% increases movement speed");
            item.value = 16000;
            item.rare = 2;
            item.defense = 1;
        }
		public override void UpdateEquip(Player player)
        {
			player.moveSpeed += 0.05f;
			player.magicDamage += 0.04f;
			player.rangedDamage += 0.04f;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Chitin", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
