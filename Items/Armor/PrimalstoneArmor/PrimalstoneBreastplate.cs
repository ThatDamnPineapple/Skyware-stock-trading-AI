using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Armor.PrimalstoneArmor
{
    public class PrimalstoneBreastplate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }
        public override void SetDefaults()
        {
            item.name = "Primalstone Breastplate";
            item.width = 34;
            item.height = 30;
            item.toolTip = "Increases life regen and crit chance by 3% if standing still";
            item.value = 10000;
            item.rare = 6;
            item.defense = 8;
        }
        public override void UpdateEquip(Player player)
        {
            if(player.velocity.X == 0 && player.velocity.Y == 0)
            {
                player.lifeRegen++;
                player.meleeCrit += 3;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ArcaneGeyser", 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}