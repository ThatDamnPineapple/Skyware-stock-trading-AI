using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.VeinstoneArmor
{
    public class VeinstoneHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Veinstone Helmet";
            item.width = 40;
            item.height = 30;
            item.toolTip = "Increases life regen and critical strike chance by 6%";
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;

            item.defense = 13;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("VeinstonePlatemail") && legs.type == mod.ItemType("VeinstoneLeggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Getting hit has a 10% chance to spawn blood from the sky";
            player.GetModPlayer<MyPlayer>(mod).veinstoneSet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.lifeRegen += 4;

            player.magicCrit += 6;
            player.meleeCrit += 6;
            player.rangedCrit += 6;
            player.thrownCrit += 6;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Veinstone", 11);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
