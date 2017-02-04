using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class PestilentVisor : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Pestilent Visor";
            item.width = 34;
            item.height = 30;
            item.toolTip = "Increased rocket damage 8% and critical strike chance by 4%";
            item.value = 10000;
            item.rare = 5;

            item.defense = 6;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("PestilentPlatemail") && legs.type == mod.ItemType("PestilentLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Every 4th hit with a pestilent weapon causes an explosion of cursed flames";
			player.GetModPlayer<MyPlayer>(mod).putridSet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.rocketDamage += 0.08f;
            player.rangedCrit += 4;
        }
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PutridPiece", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
