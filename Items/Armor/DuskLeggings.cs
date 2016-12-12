using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class DuskLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Dusk Leggings";
            item.width = 34;
            item.height = 30;
            AddTooltip("Increased Crit Chance");
            item.value = 10;
            item.rare = 6;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit = 12;
            player.rangedCrit = 12;
            player.meleeCrit = 12;
            player.thrownCrit = 12;
        }       
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DuskStone", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}