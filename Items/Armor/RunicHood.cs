using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class RunicHood : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Runic Hood";
            item.width = 34;
            item.height = 30;
            item.toolTip = "Increased Magic Damage and Movement Speed.";
            item.value = 10000;
            item.rare = 8;
            item.defense = 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("RunicPlate") && legs.type == mod.ItemType("RunicGreaves");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Setbonus Dont Works Currently!";
            player.GetModPlayer<MyPlayer>(mod).runicSet = true;
		}

        public override void UpdateEquip(Player player)
        {
            player.magicDamage = 1.12f;
            player.moveSpeed += 1.05f;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Rune", 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}