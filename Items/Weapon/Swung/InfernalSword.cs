using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Swung
{
    public class InfernalSword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Infernal Sword";
            item.width = item.height = 42;
            item.rare = 6;
            item.damage = 54;
            item.toolTip = "Inflicts a fiery debuff that stacks over time";
            item.knockBack = 8;
            item.value = Terraria.Item.sellPrice(0, 6, 70, 0);
            item.useStyle = 1;
            item.useTime = item.useAnimation = 25;
            item.melee = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;   
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