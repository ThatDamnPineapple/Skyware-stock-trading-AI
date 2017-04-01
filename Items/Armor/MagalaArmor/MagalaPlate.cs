using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.MagalaArmor
{
    public class MagalaPlate : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Gore Magala Plate";
            item.width = 22;
            item.height = 20;
             AddTooltip("Increases maximum health by 10, maximum number of minions by 1, and damage dealt by 9% \n ~Donator item~");
            item.value = 3000;
            item.rare = 5;
            item.defense = 23;
        }
        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.09f;
            player.rangedDamage += 0.09f;
            player.meleeDamage += 0.09f;
            player.magicDamage += 0.09f;
            player.thrownDamage += 0.09f;
            player.statLifeMax2 += 10;
            player.maxMinions += 1;
        }
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MagalaScale", 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
