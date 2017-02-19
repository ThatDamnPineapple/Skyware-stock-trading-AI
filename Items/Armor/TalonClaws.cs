using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class TalonClaws : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Talon Claws";
            item.width = 26;
            item.height = 12;
            AddTooltip("7% Increased magic damage and reduced mana cost");
            AddTooltip2("5% increased movement speed");
            item.value = 10000;
            item.rare = 3;
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.07f;
            player.manaCost -= 0.07f;
            player.moveSpeed += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Talon", 12);
            recipe.AddIngredient(null, "FossilFeather", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}