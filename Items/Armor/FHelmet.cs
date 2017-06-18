using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class FHelmet : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Floran Helmet");
			Tooltip.SetDefault("4% Increased magic damage and critical strike chance \n It's natural, yet seems to be from somwhere else...");
		}


        int timer = 0;
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 22;
            item.value = Terraria.Item.sellPrice(0, 0, 12, 0);
            item.rare = 2;
            item.defense = 3;
        }
        public override void UpdateEquip(Player player)
        {
            player.magicCrit += 4;
            player.magicDamage += 0.04f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("FPlate") && legs.type == mod.ItemType("FLegs");  
        }
        public override void UpdateArmorSet(Player player)
        {
            timer++;

            if (timer == 20)
            {
                int dust = Dust.NewDust(player.position, player.width, player.height, 44);
                timer = 0;
            }

            player.setBonus = "Florrrann Sssstab- 5% Increased Damage";
            player.meleeDamage += 0.05f;
            player.thrownDamage += 0.05f;
            player.rangedDamage += 0.05f;
            player.magicDamage += 0.05f;
            player.minionDamage += 0.05f;


        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FloranBar", 12);
            recipe.AddTile(TileID.Anvils);   
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
