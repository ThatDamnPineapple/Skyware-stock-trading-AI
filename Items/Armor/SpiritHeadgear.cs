using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class SpiritHeadgear : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Headgear");
			Tooltip.SetDefault("Increases max life by 10 and increases melee damage by 12%");
		}

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.value = 40000;
            item.rare = 5;
            item.defense = 14;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("SpiritBodyArmor") && legs.type == mod.ItemType("SpiritLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Spirits grant you various buffs based on your health \n Increaes damage by 8% when above 400 health \n Increases defense by 6 when above 200 Health \n Greatly increases life regen when above 50 Health \n Provides knockback immunity when under 25 Health";
            player.GetModPlayer<MyPlayer>(mod).reaperSet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 10;
            player.meleeDamage += 0.12f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritBar", 18);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}