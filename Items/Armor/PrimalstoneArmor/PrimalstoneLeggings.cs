using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Armor.PrimalstoneArmor
{
    public class PrimalstoneLeggings : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }
        public override void SetDefaults()
        {
            item.name = "Primalstone Leggings";
            item.width = 34;
            item.height = 30;
            item.toolTip = "Increases melee and magic damage by 9%\n Reduces mana cost by 5% and movement speed by 10%";
            item.value = 10;
            item.rare = 9;
            item.defense = 17;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.09f;
            player.magicDamage += 0.09f;
            player.manaCost -= .05f;
            player.moveSpeed -= .1f;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ArcaneGeyser", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}