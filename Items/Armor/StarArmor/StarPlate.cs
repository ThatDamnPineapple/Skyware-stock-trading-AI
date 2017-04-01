using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.StarArmor
{
    public class StarPlate : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Starplate Chestguard";
            item.width = 22;
            item.height = 20;
             AddTooltip("Reduces damage taken by 3%, and increases max life by 10");
            item.value = Terraria.Item.sellPrice(0, 0, 38, 0);
            item.rare = 3;
            item.defense = 9;
        }
        public override void UpdateEquip(Player player)
        {
            player.endurance += 0.03f;
            player.statLifeMax2 += 10;
        }
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamParts", 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
