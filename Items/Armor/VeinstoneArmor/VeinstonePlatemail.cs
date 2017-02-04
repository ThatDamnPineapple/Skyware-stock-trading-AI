using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.VeinstoneArmor
{
    public class VeinstonePlatemail : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Veinstone Platemail";
            item.width = 34;
            item.height = 30;
            item.toolTip = "Increases maximum life by 20 and critical strike chance by 6%";
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;

            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 20;

            player.magicCrit += 6;
            player.meleeCrit += 6;
            player.rangedCrit += 6;
            player.thrownCrit += 6;            
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Veinstone", 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
