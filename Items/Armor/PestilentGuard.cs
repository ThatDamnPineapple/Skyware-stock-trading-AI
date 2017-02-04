using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class PestilentGuard : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Pestilent Guard";
            item.width = 34;
            item.height = 30;
            item.toolTip = "Increases arrow and bullet damage by 9%, and ranged critical strike chance by 3%";
            item.value = 100000;
            item.rare = 5;
            item.defense = 7;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("PestilentPlatemail") && legs.type == mod.ItemType("PestilentLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Leave a deadly trail of cursed flames when you walk";
			((MyPlayer)player.GetModPlayer(mod, "MyPlayer")).flametrail = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.arrowDamage += 0.09f;
			player.bulletDamage += 0.09f;
            player.rangedCrit += 3;
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
