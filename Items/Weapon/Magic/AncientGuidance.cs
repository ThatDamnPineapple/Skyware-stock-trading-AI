using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Weapon.Magic
{
    public class AncientGuidance : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Ancient Guidance";
            item.damage = 155;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.magic = true;
            item.width = 28;
            item.height = 28;
            item.useTime = 24;
            item.mana = 27;
            AddTooltip("'Harness the elements of the cosmos'");
            AddTooltip("Shoots one of four projectiles with varied effects");
            item.useAnimation = 24;
            item.useStyle = 5;
            item.knockBack = 7;
            item.value = Terraria.Item.sellPrice(0, 12, 0, 0);
            item.value = Terraria.Item.buyPrice(0, 85, 0, 0);
            item.rare = 10;
            item.crit = 3;
            item.UseSound = SoundID.Item123;
            item.autoReuse = true;
            item.shootSpeed = 6;
            item.shoot = mod.ProjectileType("Starshock1");
        }
        public static Vector2[] randomSpread(float speedX, float speedY, int angle, int num)
        {
            var posArray = new Vector2[num];
            float spread = (float)(angle * 0.0274532925);
            float baseSpeed = (float)System.Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = System.Math.Atan2(speedX, speedY);
            double randomAngle;
            for (int i = 0; i < num; ++i)
            {
                randomAngle = baseAngle + (Main.rand.NextFloat() - 0.4f) * spread;
                posArray[i] = new Vector2(baseSpeed * (float)System.Math.Sin(randomAngle), baseSpeed * (float)System.Math.Cos(randomAngle));
            }
            return (Vector2[])posArray;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(7) == 0)
            {
                int pl = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("CultistIce"), damage, knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[pl].friendly = true;
                Main.projectile[pl].hostile = false;
                return false;
            }
            if (Main.rand.Next(5) == 0)
            {
                int pl = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("CultistStorm"), damage, knockBack, player.whoAmI, 0f, 0f);
                Main.projectile[pl].friendly = true;
                Main.projectile[pl].hostile = false;
                return false;
            }
            if (Main.rand.Next(3) == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    float spread = 30f * 0.0174f;//45 degrees converted to radians
                    float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
                    double baseAngle = Math.Atan2(speedX, speedY);
                    double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                    speedX = baseSpeed * (float)Math.Sin(randomAngle);
                    speedY = baseSpeed * (float)Math.Cos(randomAngle);
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("CultistFire"), item.damage, knockBack, item.owner, 0, 0);
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    float spread = 30f * 0.0174f;//45 degrees converted to radians
                    float baseSpeed = (float)Math.Sqrt(speedX * speedX + speedY * speedY);
                    double baseAngle = Math.Atan2(speedX, speedY);
                    double randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                    speedX = baseSpeed * (float)Math.Sin(randomAngle);
                    speedY = baseSpeed * (float)Math.Cos(randomAngle);
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("CultistLight"), item.damage, knockBack, item.owner, 0, 0);
                }
            }
            return false;
        }
        public override void AddRecipes()
        {

            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(null, "SteamParts", 10);
            modRecipe.AddIngredient(null, "TechDrive", 10);
            modRecipe.AddIngredient(null, "PrintPrime", 1);
            modRecipe.AddIngredient(null, "PrintProbe", 1);
            modRecipe.AddIngredient(null, "BlueprintTwins", 1);
            modRecipe.AddIngredient(null, "SpiritBar", 10);
            modRecipe.AddIngredient(null, "StellarBar", 10);
            modRecipe.AddIngredient(ItemID.FragmentVortex, 2);
            modRecipe.AddIngredient(ItemID.FragmentNebula, 2);
            modRecipe.AddIngredient(ItemID.FragmentStardust, 2);
            modRecipe.AddIngredient(ItemID.FragmentSolar, 2);
            modRecipe.AddIngredient(ItemID.Cog, 25);
            modRecipe.AddIngredient(ItemID.Ectoplasm, 6);
            modRecipe.AddIngredient(ItemID.LihzahrdPowerCell, 2);
            modRecipe.AddTile(134);
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
