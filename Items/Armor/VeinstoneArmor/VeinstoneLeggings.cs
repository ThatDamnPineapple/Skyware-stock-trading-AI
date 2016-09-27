using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.VeinstoneArmor
{
    public class VeinstoneLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Veinstone Leggings";
            item.width = 34;
            item.height = 30;
            item.toolTip = "Increased invincibility time and +6% crit chance";
            item.value = 10;
            item.rare = 6;

            item.defense = 12;
        }

        public override void UpdateEquip(Player player)
        {
            player.longInvince = true;

            player.magicCrit += 6;
            player.meleeCrit += 6;
            player.rangedCrit += 6;
            player.thrownCrit += 6;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Veinstone", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
