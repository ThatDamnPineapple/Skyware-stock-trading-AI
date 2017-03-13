using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.MagalaArmor
{
    public class MagalaLegs : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Gore Magala Greaves";
            item.width = 22;
            item.height = 20;
             AddTooltip("Increases maximum health by 10, maximum number of minions by 1, and movement speed by 13% \n ~Donator item~");
            item.value = 3000;
            item.rare = 6;
            item.defense = 17;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.13f;
            player.statLifeMax2 += 10;
            player.maxMinions += 1;
        }
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MagalaScale", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
