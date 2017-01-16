using System;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class PrimeLaser : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "PrimeLaser";
            item.width = 50;
            item.height = 30;
            item.toolTip = "Shoots beams of Mechanical Energy!";
            item.value = Item.buyPrice(0, 20, 0, 0);
            item.rare = 4;
            item.crit += 8;
            item.damage = 34;
            item.useStyle = 5;
            item.useTime = 9;
            item.useAnimation = 10;
            item.mana = 8;
            item.reuseDelay = 5;
            item.magic = true;
            item.channel = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.shoot = 389;
            item.shootSpeed = 26f;
            
        }
            public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PrintPrime", 1);
            recipe.AddIngredient(ItemID.HallowedBar, 6);
            recipe.AddIngredient(ItemID.SoulofFright, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}

