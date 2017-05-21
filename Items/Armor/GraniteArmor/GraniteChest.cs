using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.GraniteArmor
{
    public class GraniteChest : ModItem
    {

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Granite Breastplate";
            item.width = 28;
            item.height = 24;
            AddTooltip("Reduces movement speed by 15%");
            AddTooltip("Increases damage dealt by 3%");
            item.value = 1100;
            item.rare = 2;
            item.defense = 8;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxRunSpeed -= 0.15f;
            player.meleeDamage += 0.03f;
            player.rangedDamage += 0.03f;
            player.magicDamage += 0.03f;
            player.thrownDamage += 0.03f;
            player.minionDamage += 0.03f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GraniteChunk", 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
