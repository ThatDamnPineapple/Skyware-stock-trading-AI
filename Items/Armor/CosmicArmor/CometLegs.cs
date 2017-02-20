using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.CosmicArmor
{
    public class CometLegs : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Cosmic Greaves";
            item.width = 22;
            item.height = 18;
            item.value = 190000;
            item.rare = 10;
            item.defense = 10;
            item.toolTip = "Increases throwing damage by 23% and throwing velocity by 30%";
        }
        public override void UpdateEquip(Player player)
        {

            player.thrownVelocity += .30f;
            player.thrownDamage += 0.23f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AccursedRelic", 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
