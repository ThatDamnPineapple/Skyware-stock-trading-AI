using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class StellarMask : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Stellar Mask";
            item.width = 34;
            item.height = 30;
            item.toolTip = "10% increased ranged critical strike chance";
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 5;
            item.defense = 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("StellarPlate") && legs.type == mod.ItemType("StellarLeggings");  
        }
		
        public override void UpdateArmorSet(Player player)
        {
			player.setBonus = "Increases the following stats while moving: \n Increases ranged damage by 9%";
            if (player.velocity.X != 0)
			{
				player.rangedDamage += 0.09f;
				player.rangedCrit += 8;
				player.moveSpeed += 0.10f;
                int dust = Dust.NewDust(player.position, player.width, player.height, 133);
                Main.dust[dust].scale = 0.5f;
				Main.dust[dust].noGravity = true;
			}
            else if (player.velocity.Y != 0)
            {
                player.rangedDamage += 0.09f;
                player.rangedCrit += 8;
                player.moveSpeed += 0.10f;
                int dust = Dust.NewDust(player.position, player.width, player.height, 133);
                Main.dust[dust].scale = 0.5f;
                Main.dust[dust].noGravity = true;
            }
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 10;
        }
        
		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StellarBar", 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
