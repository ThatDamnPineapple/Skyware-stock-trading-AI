using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.AcidArmor
{
    public class AcidMask : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Acid Mask";
            item.width = 20;
            item.height = 18;
            item.toolTip = "Increases throwing velocity and throwing critical strike chance by 7%";
            item.value = 46000;
            item.rare = 5;
            item.defense = 7;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage+= 0.07f;
            player.thrownVelocity += 0.07f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("AcidBody") && legs.type == mod.ItemType("AcidLegs");  
        }
        public override void UpdateArmorSet(Player player)
        {
  
            player.setBonus = "Getting hurt may release an acid explosion, causing enemies to suffer Acid Burn \n Throwing hits may instantly kill non boss enemies extremely rarely.";
            player.GetModPlayer<MyPlayer>(mod).acidSet = true;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Acid", 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}