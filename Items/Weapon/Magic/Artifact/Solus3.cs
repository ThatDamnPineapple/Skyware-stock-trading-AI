using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic.Artifact
{
	public class Solus3 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solus");
            Tooltip.SetDefault("Shoots out three Bolts with varied effects\nPhoenix Bolts explode upon hitting foes and inflict 'Blaze'\nEnemies inflictted with 'Blaze' may randomly combust\nFrost Bolts may freeze enemies in place and explode into chilling wisps\nShadow Bolts pierce multiple enemies and inflict 'Shadow Burn,' which hinders enemy damage and deals large amounts of damage");
        }


        public override void SetDefaults()
		{
            item.damage = 49;
			item.magic = true;
			item.mana = 13;
			item.width = 46;
			item.height = 54;
			item.useTime = 26;
			item.useAnimation = 26;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 4;
            item.value = Terraria.Item.sellPrice(0, 7, 0, 50);
            item.rare = 7;
            item.crit = 3;
			item.UseSound = SoundID.Item74;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PhoenixBolt");
			item.shootSpeed = 1f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            {
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("PhoenixBolt1"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("DarkBolt1"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("FreezeBolt1"), damage, knockBack, item.owner);

            }
                return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Solus2", 1);
            recipe.AddIngredient(null, "SearingBand", 1);
            recipe.AddIngredient(null, "CursedMedallion", 1);
            recipe.AddIngredient(null, "DarkCrest", 1);
            recipe.AddIngredient(null, "BatteryCore", 1);
            recipe.AddIngredient(null, "PrimordialMagic", 100);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
