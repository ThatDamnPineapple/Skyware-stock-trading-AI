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
             AddTooltip("Increases critical strike chance by 2%");
            item.value = 3000;
            item.rare = 1;
            item.defense = 4;
        }
         public override void UpdateEquip(Player player)
        {
            player.magicCrit += 2;
            player.meleeCrit += 2;
            player.thrownCrit += 2;
            player.rangedCrit += 2;
        }
			public override void UpdateArmorSet(Player player)
        {

            player.setBonus = "+3% Critical chance"; 
            player.magicCrit += 3;
            player.meleeCrit += 3;
            player.thrownCrit += 3;
            player.rangedCrit += 3;
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
