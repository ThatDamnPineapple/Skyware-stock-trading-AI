using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.OverseerArmor
{
    public class ShadowSBody : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Shadowspirit Breastplate";
            item.width = 34;
            item.height = 24;
            AddTooltip("Increases movement speed by 30% and Increases max life by 50 \n Massively increases life regen'");
            item.value = 200000;
            item.rare = 11;
            item.defense = 30;
        }

        public override void UpdateEquip(Player player)
        { 
            player.moveSpeed += 0.30f;
            player.statLifeMax2 += 50;
            player.lifeRegen += 10;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EternityEssence", 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
