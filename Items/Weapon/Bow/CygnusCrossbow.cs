using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using SpiritMod.Projectiles;

namespace SpiritMod.Items.Weapon.Bow
{
    public class CygnusCrossbow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Cygnus Crossbow";
            item.damage = 45;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.height = 38;
            item.toolTip = "Arrows shot inflict Star Fracture";
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 1;
            item.knockBack = 3;
            item.value = 1000;
            item.rare = 5;
            item.useSound = 5;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.autoReuse = false;
            item.shootSpeed = 11f;
            item.crit = 4;

        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
			Main.projectile[p].GetModInfo<SpiritProjectileInfo>(mod).shotFromStellarCrosbow = true;
			return false;
		}
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "StellarBar", 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}