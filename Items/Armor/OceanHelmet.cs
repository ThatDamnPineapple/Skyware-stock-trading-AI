using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class OceanHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Ocean's Helmet";
            item.width = 24;
            item.height = 24;
            item.value = 4000;
            item.rare = 1;
            item.defense = 2;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 7);
            recipe.AddIngredient(ItemID.Seashell, 2);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("OceanChestplate") && legs.type == mod.ItemType("OceanGreaves");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Provides the Ability to double jump";
            player.doubleJumpSail = true;
        }

        public override void UpdateEquip(Player player)
        {

        }
    }
}