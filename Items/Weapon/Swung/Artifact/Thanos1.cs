using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung.Artifact
{
    public class Thanos1 : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shard of Thanos");
            Tooltip.SetDefault("'As old as the dawn of Man'\nOccasionally shoots out an afterimage of the Shard\nRight-click to summon a storm of rotating crystals around the player\n~Artifact Weapon~");

        }


        public override void SetDefaults()
        {
            item.damage = 15;            
            item.melee = true;            
            item.width = 42;              
            item.height = 40;
            item.useTime = 22;
            item.useAnimation = 22;     
            item.useStyle = 1;        
            item.knockBack = 5;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 50);
            item.shoot = mod.ProjectileType("Thanos1Proj");
            item.rare = 2;
            item.shootSpeed = 9f;
            item.UseSound = SoundID.Item69;        
            item.autoReuse = true;
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (player.altFunctionUse == 2)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Crystal"));

            }
            else
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("Crystal"));

            }
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.damage = 10;
                item.knockBack = 3;
            }
            else
            {
                item.damage = 15;
                item.knockBack = 5;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                Terraria.Projectile.NewProjectile(player.Center.X - 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 45, player.Center.Y -45, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X - 45, player.Center.Y +45, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X, player.Center.Y +40, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), damage, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X, player.Center.Y -40, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), damage, knockBack, item.owner);

            }
            else
            {
                if (Main.rand.Next(2) == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OddKeystone", 1);
            recipe.AddIngredient(null, "RootPod", 1);
            recipe.AddIngredient(null, "GildedIdol", 1);
            recipe.AddIngredient(null, "DemonLens", 1);
            recipe.AddIngredient(null, "PrimordialMagic", 50);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        
        }
    }
}