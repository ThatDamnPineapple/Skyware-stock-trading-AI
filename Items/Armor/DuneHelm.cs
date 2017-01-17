using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class DuneHelm : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Dune Helm";
            item.width = 20;
            item.height = 18;
            item.toolTip = "Increases Throwing Velocity by 10% and Thrown Damage by 20%";
            item.value = 46000;
            item.rare = 6;
            item.defense = 12;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage+= 0.20f;
            player.thrownVelocity += 0.10f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("RoguePlate") && legs.type == mod.ItemType("RoguePants");  
        }
        public override void UpdateArmorSet(Player player)
        {
  
            player.setBonus = "8 successful hits on enemies with thrower weapons grants you Desert Winds buff, allowing you to dash once";
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DuneEssence", 16);
            recipe.AddTile(null,"EssenceDistorter");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}