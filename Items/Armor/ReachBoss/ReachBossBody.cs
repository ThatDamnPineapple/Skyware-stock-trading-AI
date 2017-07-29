using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.ReachBoss
{
    [AutoloadEquip(EquipType.Body)]
    public class ReachBossBody : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vinecaller's Garb");
            Tooltip.SetDefault("Increases throwing damage by 4%\nIncreases throwing critical strike chance by 4%\nIncreases maximum minions by 1");

        }


        int timer = 0;
        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 20;
            item.value = 30200;
            item.rare = 2;
            item.defense = 5;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.04f;
            player.thrownCrit += 4;
            player.maxMinions += 1;
        }
		 public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ReachFlowers", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
