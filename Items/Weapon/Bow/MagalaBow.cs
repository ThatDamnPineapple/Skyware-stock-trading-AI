using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using SpiritMod.Projectiles;

namespace SpiritMod.Items.Weapon.Bow
{
    public class MagalaBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Entbehrung";
            item.damage = 40;
            item.noMelee = true;
            item.ranged = true;
            item.width = 48;
            item.height = 32;
            item.toolTip = "Converts arrows into spiny Magala Arrows \n 'You actually use a bow??` \n ~Donator Item~";
            item.useTime = 17;
            item.useAnimation = 17;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 4;
            item.rare = 6;
            item.UseSound = SoundID.Item5;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.autoReuse = true;
            item.shootSpeed = 12f;
            item.crit = 20;

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
			
			Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("MagalaArrow"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false; 
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MagalaScale", 12);
            recipe.AddIngredient(ItemID.DD2PhoenixBow);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}