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
            item.toolTip = "+5% throwing damage and +8% throwing crit chance";
            item.value = 10000;
            item.rare = 5;

            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.05F;
            player.thrownCrit += 8;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("GeodeChestplate") && legs.type == mod.ItemType("GeodeLeggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "'Press T to crystallize nearby enemies'";
            //player.GetModPlayer<MyPlayer>(mod).geodeSet = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Geode", 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
