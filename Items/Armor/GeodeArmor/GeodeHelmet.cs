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
            item.toolTip = "Increases throwing damage by 7% and increases throwing critical strike chance by 8%";
            item.value = Terraria.Item.sellPrice(0, 0, 75, 0);
            item.rare = 4;

            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.07F;
            player.thrownCrit += 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("GeodeChestplate") && legs.type == mod.ItemType("GeodeLeggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Thrown attacks inflict frostburn and fire rarely";
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
