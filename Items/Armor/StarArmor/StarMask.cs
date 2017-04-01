using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.StarArmor
{
    public class StarMask : ModItem
    {
        int timer = 0;

        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Starplate Crown";
            item.width = 22;
            item.height = 20;
             AddTooltip("Increases damage by 4%, and max life by 10");
            item.value = Terraria.Item.sellPrice(0, 0, 30, 0);
            item.rare = 3;
            item.defense = 8;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.04f;
            player.rangedDamage += 0.04f;
            player.thrownDamage += 0.04f;
            player.minionDamage += 0.04f;
            player.magicDamage += 0.04f;
            player.statLifeMax2 += 10;
        }

            public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Reduces damage taken by 5% \n Leave a trail of electrical stars where you walk";
            player.GetModPlayer<MyPlayer>(mod).starSet = true;
            player.endurance += 0.05f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("StarPlate") && legs.type == mod.ItemType("StarLegs");
        }
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SteamParts", 4);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
