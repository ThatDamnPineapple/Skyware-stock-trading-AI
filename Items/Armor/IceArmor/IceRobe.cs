using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.IceArmor
{
    public class  IceRobe : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Blizzard Robes";
            item.width = 20;
            item.height = 18;
            item.toolTip = "Increases magic damage by 6% and magic critical strike chance by 5%";
            item.value = 86000;
            item.rare = 6;
            item.defense = 10;
        }
        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.06f;
            player.magicCrit += 5;

        }

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IcyEssence", 18);
            recipe.AddTile(null,"EssenceDistorter");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}