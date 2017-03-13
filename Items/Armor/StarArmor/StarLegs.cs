using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.StarArmor
{
    public class StarLegs : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Legs);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Starplate Leggings";
            item.width = 22;
            item.height = 20;
             AddTooltip("Increases movement speed by 7% and critical strike chance by 5%");
            item.value = 3000;
            item.rare = 3;
            item.defense = 9;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.05f;
            player.meleeCrit += 5;
            player.thrownCrit += 5;
            player.rangedCrit += 5;
            player.magicCrit += 5;
        }
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamParts", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
