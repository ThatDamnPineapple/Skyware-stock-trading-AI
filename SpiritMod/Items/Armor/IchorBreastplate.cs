using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class IchorBreastplate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Ichor Breastplate";
            item.width = 18;
            item.height = 18;
            item.toolTip = "Increased Thrown Velocity";
            item.toolTip2 = "15% Increased Ranged Crit";
            item.value = 10;
            item.rare = 4;
            item.defense = 14;
        }

        public override void UpdateEquip(Player player)
        {
            player.thrownVelocity = +1.1f;
            player.rangedCrit += 15;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Ichor, 5);               
            recipe.AddIngredient(ItemID.CrimstoneBlock, 30);
            recipe.AddIngredient(ItemID.SoulofNight, 1);
            recipe.AddTile(TileID.MythrilAnvil);   
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}