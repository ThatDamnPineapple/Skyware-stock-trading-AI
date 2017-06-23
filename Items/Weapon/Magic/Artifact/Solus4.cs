using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic.Artifact
{
	public class Solus4 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Solus");
            Tooltip.SetDefault("'You are the Artifact Keeper of Asra Nox'\nShoots out three Bolts with varied effects\nPhoenix Bolts explode upon hitting foes and inflict 'Blaze'\nEnemies inflictted with 'Blaze' may randomly combust\nFrost Bolts may freeze enemies in place and explode into chilling wisps\nShadow Bolts pierce multiple enemies and inflict 'Shadow Burn,' which hinders enemy damage and deals large amounts of damage\nAttacks may release multiple different revolving embers with varied effects\n~Artifact Weapon~");
        }


        public override void SetDefaults()
		{
            item.damage = 87;
			item.magic = true;
			item.mana = 13;
			item.width = 58;
			item.height = 66;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 4;
            item.value = Terraria.Item.sellPrice(0, 7, 0, 50);
            item.rare = 10;
            item.crit = 6;
			item.UseSound = SoundID.Item74;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("PhoenixBolt");
			item.shootSpeed = 1f;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            if (Main.rand.Next(6) == 1)
            {
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("PhoenixBolt1"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("DarkBolt1"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("FreezeBolt1"), damage, knockBack, item.owner);

                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Ember1"), 50, 1, player.whoAmI);
                return false;
            }
           else if (Main.rand.Next(6) == 1)
            {
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("PhoenixBolt1"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("DarkBolt1"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("FreezeBolt1"), damage, knockBack, item.owner);

                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Ember2"), 50, 1, player.whoAmI);
                return false;
            }
           else if (Main.rand.Next(6) == 1)
            {
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("PhoenixBolt1"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("DarkBolt1"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(position.X, position.Y, speedX * (Main.rand.Next(500, 900) / 100), speedY * (Main.rand.Next(500, 900) / 100), mod.ProjectileType("FreezeBolt1"), damage, knockBack, item.owner);

                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Ember3"), 50, 1, player.whoAmI);
                return false;
            }
            else
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
            recipe.AddIngredient(null, "Solus3", 1);
            recipe.AddIngredient(null, "RadiantEmblem", 1);
            recipe.AddIngredient(null, "PlanteraBloom", 1);
            recipe.AddIngredient(null, "ApexFeather", 1);
            recipe.AddIngredient(null, "UnrefinedRuneStone", 1);
            recipe.AddIngredient(null, "Catalyst", 1);
            recipe.AddIngredient(null, "PrimordialMagic", 150);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
