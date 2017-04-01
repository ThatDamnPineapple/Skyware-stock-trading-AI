using System;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Weapon.Magic
{
    public class Contraption : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Crazed Contraption";
            item.damage = 110;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.magic = true;
            item.width = 28;
            item.height = 28;
            item.useTime = 50;
            item.mana = 15;
            item.toolTip = "'What does it do? No one knows!'";
            item.useAnimation = 50;
            item.useStyle = 5;
            item.knockBack = 10;
            item.value = 200000;
            item.rare = 8;
            item.UseSound = SoundID.Item34;
            item.autoReuse = true;
            item.shootSpeed = 15;
            item.UseSound = SoundID.Item20;
            item.shoot = mod.ProjectileType("Starshock1");
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.Next(16) == 0)
            {
                item.shoot = ProjectileID.IceSickle;
                return true;
            }
            else if (Main.rand.Next(14) == 0)
            {
                item.shoot = ProjectileID.InfernoFriendlyBolt;
                return true;

            }
            else if (Main.rand.Next(148) == 0)
            {
                item.shoot = ProjectileID.SeedlerNut;
                return true;
            }
            else if (Main.rand.Next(18) == 0)
            {
                item.shoot = ProjectileID.FrostBlastFriendly;
                return true;
            }
            else if (Main.rand.Next(18) == 0)
            {
                item.shoot = ProjectileID.ToxicFlask;
                return true;
            }
            else if (Main.rand.Next(18) == 0)
            {
                item.shoot = ProjectileID.LightDisc;
                return true;
            }
            else if (Main.rand.Next(18) == 0)
            {
                item.shoot = ProjectileID.OrnamentFriendly;
                return true;
            }
            else if (Main.rand.Next(18) == 0)
            {
                item.shoot = ProjectileID.FlaironBubble;
                return true;
            }
            else if (Main.rand.Next(18) == 0)
            {
                item.shoot = ProjectileID.RedsYoyo;
                return true;
            }
            else if (Main.rand.Next(18) == 0)
            {
                item.shoot = ProjectileID.DD2FlameBurstTowerT1Shot;
                return true;
            }
            else if (Main.rand.Next(18) == 0)
            {
                item.shoot = ProjectileID.ChargedBlasterLaser;
                return true;
            }
            else if (Main.rand.Next(18) == 0)
            {
                item.shoot = ProjectileID.Meteor2;
                return true;
            }
            else if (Main.rand.Next(18) == 0)
            {
                item.shoot = ProjectileID.ExplosiveBunny;
                return true;
            }
            else if (Main.rand.Next(24) == 0)
            {
                item.shoot = ProjectileID.VampireKnife;
                return true;
            }
            else if (Main.rand.Next(24) == 0)
            {
                item.shoot = ProjectileID.Bat;
                return true;
            }
            else if (Main.rand.Next(24) == 0)
            {
                item.shoot = ProjectileID.MiniSharkron;
                return true;
            }
            else if (Main.rand.Next(24) == 0)
            {
                item.shoot = ProjectileID.CultistBossIceMist;
                return true;
            }
            return true;
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
            modRecipe.AddIngredient(ItemID.Cog, 25);
            modRecipe.AddIngredient(ItemID.Ectoplasm, 6);
            modRecipe.AddIngredient(ItemID.LihzahrdPowerCell, 2);
            modRecipe.AddTile(134);
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
    }
}
