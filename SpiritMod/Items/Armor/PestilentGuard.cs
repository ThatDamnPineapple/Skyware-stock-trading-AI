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
            item.toolTip = "Increased arrow and bullet damage, and ranged critical strike chance";
            item.value = 10000;
            item.rare = 8;
            item.defense = 10;
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
            player.arrowDamage += 0.17f;
			player.bulletDamage += 0.17f;
            player.rangedCrit += 6;
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
