using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class ReaperMask : ModItem
    {

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Reaper's Mask";
            item.width = 22;
            item.height = 20;
            AddTooltip("Increases ranged damage by 9%, ranged critical strike chance by 10% \n Press E to turn into an invulnerable wraith");
            item.value = 3000;
            item.rare = 7;
            item.defense = 9;
        }
         public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.1f;
            player.rangedCrit += 9;
            player.GetModPlayer<MyPlayer>(mod).reaperMask = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FieryEssence", 5);
            recipe.AddIngredient(null, "BloodFire", 5);
            recipe.AddIngredient(ItemID.SoulofNight, 6);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
