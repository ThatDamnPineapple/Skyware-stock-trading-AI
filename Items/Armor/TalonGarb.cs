using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class TalonGarb : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Talon Garb";
            item.width = 32;
            item.height = 22;
            AddTooltip("Increased Ranged and Magic Critical strike chance");
            AddTooltip2("5% Increased movement speed");
            item.value = 100;
            item.rare = 5;
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 6;
            player.rangedCrit += 6;
            player.moveSpeed += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Talon", 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
        }
    }
}