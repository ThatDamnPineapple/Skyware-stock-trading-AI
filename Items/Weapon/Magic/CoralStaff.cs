using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
	public class CoralStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Coral Staff";
			item.damage = 14;
			item.magic = true;
			item.mana = 22;
			item.width = 46;
			item.height = 46;
			item.useTime = 36;
			item.useAnimation = 28;
			item.useStyle = 5;
			Item.staff[item.type] = true;
			item.noMelee = true; 
			item.knockBack = 0;
			item.value = 20000;
			item.rare = 3;
			item.useSound = 20;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("CoralStaffProj");
			item.shootSpeed = 30f;
            item.toolTip = "Creates a whirlpool to damage your enemies";
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
            Terraria.Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, type, damage, knockBack, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Coral, 12);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
	}
}
