using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class LihzahrdHood : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Lihzahrd Hood";
            item.width = 18;
            item.height = 22;
            item.toolTip = "Increased movement speed and throwing damage";
            item.value = 0000;
            item.rare = 1;
            item.defense = 10;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.04f;
			player.thrownDamage += 0.05f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("LihzahrdPlate") && legs.type == mod.ItemType("LihzahrdLegs");  
        }
        public override void UpdateArmorSet(Player player)
        {
  
            player.setBonus = "Movement speed and thrown velocity increased by 50%";
            player.moveSpeed += 0.5f;
			player.thrownVelocity += 0.5f;

        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.StoneBlock, 40);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}