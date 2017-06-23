using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung.Artifact
{
    public class Thanos2 : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shard of Thanos");
            Tooltip.SetDefault("Shoots out an afterimage of the Shard\nRight-click to summon two storms of rotating crystals around the player\nMelee or afterimage attacks may crystallize enemies, stopping them in place\n~Artifact Weapon~");

        }


        public override void SetDefaults()
        {
            item.damage = 31;            
            item.melee = true;            
            item.width = 44;              
            item.height = 42;
            item.useTime = 21;
            item.useAnimation = 21;     
            item.useStyle = 1;        
            item.knockBack = 6;
            item.value = Terraria.Item.sellPrice(0, 5, 0, 50);
            item.shoot = mod.ProjectileType("Thanos2Proj");
            item.rare = 4;
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
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(8) == 1)
            {
                target.AddBuff(mod.BuffType("Crystallize"), 180);
            }
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                item.damage = 22;
                item.knockBack = 3;
            }
            else
            {
                item.damage = 31;
                item.knockBack = 6;
            }
            return base.CanUseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.altFunctionUse == 2)
            {
                Terraria.Projectile.NewProjectile(player.Center.X - 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 11, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 11, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 45, player.Center.Y -45, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 11, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X - 45, player.Center.Y +45, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 11, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X, player.Center.Y +40, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 11, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X, player.Center.Y -40, speedX, speedY, mod.ProjectileType("Thanos1Crystal"), 11, knockBack, item.owner);

                Terraria.Projectile.NewProjectile(player.Center.X - 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos2Crystal"), 22, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 40, player.Center.Y, speedX, speedY, mod.ProjectileType("Thanos2Crystal"), 22, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 45, player.Center.Y - 45, speedX, speedY, mod.ProjectileType("Thanos2Crystal"), 22, knockBack, item.owner);
                Terraria.Projectile.NewProjectile(player.Center.X + 45, player.Center.Y - 45, speedX, speedY, mod.ProjectileType("Thanos2Crystal"), 22, knockBack, item.owner);

            }
            else
            {
                {
                    return true;
                }
            }
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Thanos1", 1);
            recipe.AddIngredient(null, "NecroticSkull", 1);
            recipe.AddIngredient(null, "TideStone", 1);
            recipe.AddIngredient(null, "StellarTech", 1);;
            recipe.AddIngredient(null, "PrimordialMagic", 75);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}