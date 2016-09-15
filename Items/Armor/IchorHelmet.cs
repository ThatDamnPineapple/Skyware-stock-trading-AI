using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class IchorHelmet : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Ichor Helmet";
            item.width = 18;
            item.height = 18;
            item.toolTip = "33% Chance to not Consume throwed Item";
            item.toolTip2 = "10% Increased Ranged Damage";
            item.value = 10000;
            item.rare = 4;
            item.defense = 16;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("IchorBreastplate") && legs.type == mod.ItemType("IchorLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "15% More Thrown Damage + Permanent Weapon Imbue Ichor Buff"; 
            player.thrownDamage *= 1.15f;  
            player.AddBuff(BuffID.WeaponImbueIchor, 400);

        }

        public override void UpdateEquip(Player player)
        {
            player.thrownCost33 = true;
            player.rangedDamage = 1.10f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ichor, 3);
            recipe.AddIngredient(ItemID.CrimstoneBlock, 25);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        } 
    }
}