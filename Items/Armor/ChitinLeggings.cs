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
			             AddTooltip("+2% Magic and Ranged Damage");
			 AddTooltip("+5% Speed");
            item.value = 16000;
            item.rare = 2;
            item.defense = 1;
        }
		public override void UpdateEquip(Player player)
        {
			player.moveSpeed += 0.05f;
			player.magicDamage += 0.02f;
			player.rangedDamage += 0.02f;
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
