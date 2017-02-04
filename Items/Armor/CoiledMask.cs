using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class CoiledMask : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Coiled Mask";
            item.width = 22;
            item.height = 20;
            item.toolTip = "Increases throwing velocity by 10%";
            item.value = 38000;
            item.rare = 3;
            item.defense = 5;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity += 0.1f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("CoiledChestplate") && legs.type == mod.ItemType("CoiledLeggings");
        }
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TechDrive", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void UpdateArmorSet(Player player)
        {

            player.setBonus = "Go into Overdrive when your health reaches a critical level...";

            if (player.statLife < player.statLifeMax2 / 4)
            {
                player.AddBuff(mod.BuffType("OverDrive"), 420);
                int dust = Dust.NewDust(player.position, player.width, player.height, 172); 
            }
        }
    }
}
