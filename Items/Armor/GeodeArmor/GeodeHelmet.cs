using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.GeodeArmor
{
    public class GeodeHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Geode Helmet";
            item.width = 40;
            item.height = 30;
            item.toolTip = "Increases movement speed by 12%";
            item.value = Terraria.Item.sellPrice(0, 0, 75, 0);
            item.rare = 4;

            item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxRunSpeed += 0.12f;

        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("GeodeChestplate") && legs.type == mod.ItemType("GeodeLeggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Critical hits inflict frostburn and fire";
            player.GetModPlayer<MyPlayer>(mod).geodeSet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Geode", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
