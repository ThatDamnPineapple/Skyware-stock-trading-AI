using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class Frostbite : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Frigid Bite";
            item.damage = 11;
            item.melee = true;
            item.width = 34;
            item.height = 40;
            item.autoReuse = false;
            item.toolTip = "Occasionally inflicts Frostburn";
            item.useTime = 29;
            item.useAnimation = 29;
            item.useStyle = 1;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrigidFragment", 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(7) == 0)
            {
                target.AddBuff(BuffID.Frostburn, 240, true);
            }
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 68);
            }
        }
    }
}