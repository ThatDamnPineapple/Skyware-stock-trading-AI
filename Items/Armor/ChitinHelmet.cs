using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class ChitinHelmet : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Chitin Faceguard";
            item.width = 22;
            item.height = 20;
             AddTooltip("Increases Max Number of Minions");
			 AddTooltip("5% Increased Ranged and Summoning damage");
            item.value = 18000;
            item.rare = 2;
            item.defense = 2;
        }
         public override void UpdateEquip(Player player)
        {
			 player.maxMinions += 1;
			player.minionDamage +=0.05f;
            player.rangedDamage += 0.05f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ChitinChestplate") && legs.type == mod.ItemType("ChitinLeggings");
        }
		// public override void UpdateArmorSet(Player player)
       // {
      //     player.setBonus = "10% chance not to consume ammo";
      //  }
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Chitin", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
