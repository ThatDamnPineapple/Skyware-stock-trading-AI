using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.DepthArmor
{
    public class DepthHelm : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Depth Walker's Helmet";
            item.width = 20;
            item.height = 18;
            AddTooltip("Increases melee critical strike chance by 10% and minion damage by 10%");
            AddTooltip("Increases maximum number of minions by 1");
            item.value = 46000;
            item.rare = 5;
            item.defense = 9;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeCrit += 10;
            player.minionDamage += 0.1f;
            player.maxMinions += 1;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("DepthChest") && legs.type == mod.ItemType("DepthGreaves");  
        }
        public override void UpdateArmorSet(Player player)
        {
  
            player.setBonus = "Press a hotkey to release multiple mechanical shark minions that home onto enemies \n 45 second cooldown";
            player.GetModPlayer<MyPlayer>(mod).depthSet = true;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DepthShard", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}