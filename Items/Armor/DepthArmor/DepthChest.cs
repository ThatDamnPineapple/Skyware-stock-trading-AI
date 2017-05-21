using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.DepthArmor
{
    public class DepthChest : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Depth Walker's Platemail";
            item.width = 30;
            item.height = 20;
            AddTooltip("Increases melee and summon damage by 12%");
            AddTooltip("Increases maximum number of minions by 1");
            item.value = 6000;
            item.rare = 5;
            item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.12f;
            player.meleeDamage += 0.12f;
            player.maxMinions += 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DepthShard", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
