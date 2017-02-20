using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.CosmicArmor
{
    public class CometArmor : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Cosmic Chestplate";
            item.width = 24;
            item.height = 24;
            AddTooltip("Increases movement speed by 20%, throwing velocity by 10%, and throwing critical strike chance by 10%");
            item.value = 120000;
            item.rare = 10;
            item.defense = 27;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity += .10f;
            player.moveSpeed += 0.20f;
            player.thrownCrit += 10;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AccursedRelic", 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
