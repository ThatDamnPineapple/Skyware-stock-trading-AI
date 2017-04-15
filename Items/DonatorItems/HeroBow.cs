using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using SpiritMod.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems
{
    public class HeroBow : ModItem
    {
        int charger;
        public override void SetDefaults()
        {
            item.name = "Hero's Bow";
            item.damage = 65;
            item.noMelee = true;
            item.ranged = true;
            item.width = 22;
            item.toolTip = "Right-click to shoot either fiery, icy, and light arrows with different effects \n -Fiery arrows can inflict multiple different burns on foes \n -Icy Arrows can freeze an enemy in place and frostburn hit foes \n -Light Arrows have a 2% chance to instantly kill any non-boss enemy\n -Regular Arrows have powerful damage and knockback";
            item.toolTip2 = "~Donator Item~";
            item.height = 46;
            item.useTime = 22;
            item.useAnimation = 22;
            item.useStyle = 5;
            item.shoot = 1;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 7;
            item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 8;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useTurn = false;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {

                if (Main.rand.Next(3) == 1)
                {
                    int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                    Main.projectile[p].GetModInfo<SpiritProjectileInfo>(mod).HeroBow3 = true;
                    item.damage = 45;
                    item.knockBack = 3;

                    return false;
                }

                else if (Main.rand.Next(2) == 1)
                {
                    int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                    Main.projectile[p].GetModInfo<SpiritProjectileInfo>(mod).HeroBow2 = true;
                    item.damage = 45;
                    item.knockBack = 3;

                    return false;
                }
                else
                {
                    int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                    Main.projectile[p].GetModInfo<SpiritProjectileInfo>(mod).HeroBow1 = true;
                    item.damage = 45;
                    item.knockBack = 3;

                    return false;
                }
                return false;
            }
            else
            {

                int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
                item.damage = 65;
                item.useTime = 22;
                item.useAnimation = 22;
                item.knockBack = 7;
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Quasar", 1);
            recipe.AddIngredient(null, "AncientBark", 10);
            recipe.AddIngredient(null, "OldLeather", 10);
            recipe.AddIngredient(null, "SpiritBar", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}