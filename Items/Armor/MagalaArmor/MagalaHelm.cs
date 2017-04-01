using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.MagalaArmor
{
    public class MagalaHelm : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Gore Magala Veil";
            item.width = 22;
            item.height = 20;
             AddTooltip("Increases maximum health by 10, maximum mana by 60, and maximum number of minions by 1 \n ~Donator item~");
            item.value = 3000;
            item.rare = 5;
            item.defense = 15;
        }
        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 60;
            player.statLifeMax2 += 10;
            player.maxMinions += 1;
        }

            public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Attacks inflict Frenzy Virus on foes \n Attacks cause the player to become imbued with a modified Virus";
            player.GetModPlayer<MyPlayer>(mod).magalaSet = true;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("MagalaPlate") && legs.type == mod.ItemType("MagalaLegs");
        }
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MagalaScale", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
    }
}
