using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon
{
    public class InfernalSword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Infernal Sword";
            item.width = item.height = 42;
            item.toolTip = "???";
            item.rare = 4;

            item.damage = 10;
            item.knockBack = 2;

            item.useStyle = 1;
            item.useTime = item.useAnimation = 25;

            item.melee = true;
            item.autoReuse = true;

            item.useSound = 1;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(2) == 0)
                target.AddBuff(mod.BuffType("StackingFireBuff"), 300);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight, 2);
            recipe.AddIngredient(ItemID.HellstoneBar, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
