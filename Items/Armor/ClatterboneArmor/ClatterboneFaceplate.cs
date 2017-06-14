using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.ClatterboneArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class ClatterboneFaceplate : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Clatterbone Faceplate");
			Tooltip.SetDefault("Increases melee damage by 3%");
		}

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 30;
            item.value = 11000;
            item.rare = 2;

            item.defense = 4;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ClatterboneBreastplate") && legs.type == mod.ItemType("ClatterboneLeggings");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Upon taking lethal damage, the amount of damage taken is returned to you. 6 minute cooldown";
            player.GetModPlayer<MyPlayer>(mod).clatterboneSet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.03F;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Carapace", 7);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
