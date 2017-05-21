using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.IMArmor
{
    public class IlluminantHead : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }
        public override void SetDefaults()
        {
            item.name = "Illuminant Cowl";
            item.width = 28;
            item.height = 24;
            item.toolTip = "Increases max damage by 6% and reduuces damage taken by 5%";
            item.value = 100000;
            item.rare = 7;
            item.defense = 14;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("IlluminantGarb") && legs.type == mod.ItemType("IlluminantLegs");  
        }
        public override void UpdateArmorSet(Player player)
        {            
            player.setBonus = "Your attakcs bathe enemies in Holy Light \n Holy Light reduces your foes' attack and defense \n Wisps of illuminant energy surround for you ";
            player.GetModPlayer<MyPlayer>(mod).illuminantSet = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.06f;
            player.meleeDamage += 0.06f;
            player.thrownDamage += 0.06f;
            player.rangedDamage += 0.06f;
            player.minionDamage += 0.06f;

            player.endurance += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IlluminatedCrystal", 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}