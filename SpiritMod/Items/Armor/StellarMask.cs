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
            item.value = 10000;
            item.rare = 8;
            item.defense = 12;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("StellarPlate") && legs.type == mod.ItemType("StellarLeggings");  
        }
		
        public override void UpdateArmorSet(Player player)
        {
            if (player.velocity.X != 0)
			{
				player.setBonus = "Increased ranged stats while moving";
				player.rangedDamage += 0.30f;
				player.rangedCrit += 15;
				player.moveSpeed += 0.30f;
				int dust = Dust.NewDust(player.position, player.width, player.height, 64); 
				Main.dust[dust].scale = 2f;
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
            recipe.AddIngredient(null, "PutridPiece", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
