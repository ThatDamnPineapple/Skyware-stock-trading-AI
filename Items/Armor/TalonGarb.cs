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
            AddTooltip("Increased ranged and magic critical strike chance by 4%");
            AddTooltip2("4% increased movement speed");
            item.value = 10000;
            item.rare = 3;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 4;
            player.rangedCrit += 4;
            player.moveSpeed += 0.04f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Talon", 16);
            recipe.AddIngredient(null, "FossilFeather", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
