using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Armor.PrimalstoneArmor
{
    public class PrimalstoneFaceplate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }
        public override void SetDefaults()
        {
            item.name = "Primalstone Faceplate";
            item.width = 40;
            item.height = 30;
            item.toolTip = "Reduces damage taken by 7% at the cost of 5% movement speed";
            item.value = 10000;
            item.rare = 3;
            item.defense = 8;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("PrimalstoneBreastplate") && legs.type == mod.ItemType("PrimalstoneLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {            
            player.setBonus = "Melee hits on enemies trigger Unstable Afflction\nEnemies suffering from the Unstable Affliction have different effects\n Reduces your movement speed by 10%";
            player.GetModPlayer<MyPlayer>(mod).primalSet = true;
            player.moveSpeed -= 0.1F;
        }
        public override void UpdateEquip(Player player)
        {
            player.endurance += 0.07F;
            player.moveSpeed -= 0.05F;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ArcaneGeyser", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}