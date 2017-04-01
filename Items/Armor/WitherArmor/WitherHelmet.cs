using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.WitherArmor
{
    public class WitherHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }
        public override void SetDefaults()
        {
            item.name = "Wither Visor";
            item.width = 28;
            item.height = 24;
            item.toolTip = "Increases critical strike chance by 12% and life regen by 5";
            item.value = Terraria.Item.sellPrice(0, 2, 0, 0);
            item.rare = 8;
            item.defense = 15;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("WitherPlate") && legs.type == mod.ItemType("WitherLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {            
            player.setBonus = "A mass of wither energy follows you, attacking nearby enemies";
            player.GetModPlayer<MyPlayer>(mod).witherSet = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 5;

            player.magicCrit += 12;
            player.meleeCrit += 12;
            player.rangedCrit += 12;
            player.thrownCrit += 12;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "NightmareFuel", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}