using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class OceanGreaves : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Explorer's Greaves";
            item.width = 22;
            item.height = 18;
            AddTooltip("5% Increased Movement Speed");
            item.value = 3000;
            item.rare = 1;
            item.defense = 2;
        }

    public override void UpdateEquip(Player player)
    {
        player.moveSpeed *= 1.05f;
    }

    public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 6);
            recipe.AddIngredient(ItemID.Seashell, 2);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }       
    }
}