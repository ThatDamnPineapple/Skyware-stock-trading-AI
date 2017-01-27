using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.ReaperArmor
{
    public class BlightHelm : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }
        public override void SetDefaults()
        {
            item.name = "Reaper's Crown";
            item.width = 28;
            item.height = 24;
            item.toolTip = "Increases max life by 50 and increases life regen";
            item.value = 100000;
            item.rare = 8;
            item.defense = 17;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("BlightArmor") && legs.type == mod.ItemType("BlightLegs");  
        }
        public override void UpdateArmorSet(Player player)
        {            
            player.setBonus = "You launch a barrage of cursed souls at foes when hurt \n Increases damage dealt by 10%";
            player.magicDamage += 0.10f;
            player.meleeDamage += 0.10f;
            player.thrownDamage += 0.10f;
            player.rangedDamage += 0.10f;
            player.minionDamage += 0.10f;
            player.GetModPlayer<MyPlayer>(mod).reaperSet = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 50;
            player.lifeRegen += 3;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CursedFire", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}