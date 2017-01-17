using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class BismiteHelmet : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Bismite Helmet";
            item.width = 22;
            item.height = 20;
             AddTooltip("Increases Critical Strike Chance by 4%");
            item.value = 3000;
            item.rare = 2;
            item.defense = 2;
        }
         public override void UpdateEquip(Player player)
        {
            player.magicCrit += 4;
            player.meleeCrit += 4;
            player.thrownCrit += 4;
            player.rangedCrit += 4;
        }
			public override void UpdateArmorSet(Player player)
        {

            player.setBonus = "+4% Critical chance"; 
            player.magicCrit += 4;
            player.meleeCrit += 4;
            player.thrownCrit += 4;
            player.rangedCrit += 4;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("BismiteChestplate") && legs.type == mod.ItemType("BismiteLeggings");
        }
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BismiteCrystal", 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
