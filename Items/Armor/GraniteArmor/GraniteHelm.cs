using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.GraniteArmor
{
    public class GraniteHelm : ModItem
    {

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Granite Visor";
            item.width = 28;
            item.height = 24;
            AddTooltip("Reduces movement speed by 6%");
            AddTooltip("Reduces damage taken by 3%");
            item.value = 1100;
            item.rare = 2;
            item.defense = 8;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxRunSpeed -= 0.07f;
            player.endurance += 0.03f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("GraniteChest") && legs.type == mod.ItemType("GraniteLegs");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increases invincibility time after getting hit";

            player.longInvince = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GraniteChunk", 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
