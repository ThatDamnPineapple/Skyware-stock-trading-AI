using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.ReachBoss
{
    [AutoloadEquip(EquipType.Head)]
    public class ReachBossHead : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vinecaller's Helmet");
            Tooltip.SetDefault("Increases throwing and summon damage by 4%\nIncreases throwing critical strike chance and minion knockback by 3%\nIncreases maximum minions by 1");

        }


        int timer = 0;
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = 3000;
            item.rare = 2;
            item.defense = 4;
        }
         public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.04f;
            player.thrownDamage += 0.04f;
            player.thrownCrit += 3;
            player.minionKB += 0.03f;
            player.maxMinions += 1;
        }
			public override void UpdateArmorSet(Player player)
        {

            player.setBonus = "'Prey on the weak'\nThrowing crits do 25% more damage to enemies under half health\nIncreases minion knockback by 3%";
            player.GetModPlayer<MyPlayer>(mod).reachSet = true;
            player.minionKB += 0.03f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ReachBossBody") && legs.type == mod.ItemType("ReachBossLegs");
        }
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ReachFlowers", 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
