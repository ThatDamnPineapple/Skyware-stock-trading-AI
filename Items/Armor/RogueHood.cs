using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class RogueHood : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Rogue Hood";
            item.width = 20;
            item.height = 18;
            item.toolTip = "Increases throwing velocity by 2%";
            item.value = 600;
            item.rare = 1;
            item.defense = 1;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity += 0.02f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("RoguePlate") && legs.type == mod.ItemType("RoguePants");  
        }
        public override void UpdateArmorSet(Player player)
        {
  
            player.setBonus = "Increases throwing velocity by 2% and movement speed by 3%";
            player.maxRunSpeed += 0.03f;
            player.thrownVelocity += 0.02f;
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OldLeather", 3);
			recipe.AddIngredient(ItemID.CopperBar, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
			
			recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OldLeather", 3);
			recipe.AddIngredient(ItemID.TinBar, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}