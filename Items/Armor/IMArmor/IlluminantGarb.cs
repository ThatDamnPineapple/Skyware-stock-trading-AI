using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.IMArmor
{
    public class IlluminantGarb : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Illuminant Platemail";
            item.width = 34;
            item.height = 24;
            AddTooltip("Increases Max life by 30 and damage by 10%");
            item.value = 120000;
            item.rare = 7;
            item.defense = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.10f;
            player.meleeDamage += 0.10f;
            player.thrownDamage += 0.10f;
            player.rangedDamage += 0.10f;
            player.minionDamage += 0.10f;
            player.statLifeMax2 += 30;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IlluminatedCrystal", 16);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
