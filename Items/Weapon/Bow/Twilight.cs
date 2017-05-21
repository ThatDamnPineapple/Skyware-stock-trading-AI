using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
	public class Twilight : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Duskrise Bow";
			item.width = 32;
			item.height = 58;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 7;
            AddTooltip("Converts arrows into Twilight Arrows");
            AddTooltip("Twilight Arrows explode into Shadowflame, as well as combusting and illuminating hit foes");
            AddTooltip("Shoots out three arrows consecutively");
            item.damage = 48;
			item.knockBack = 2.5f;
			item.useStyle = 5;
			item.useTime = 24;
			item.useAnimation = 72;
			item.useAmmo = AmmoID.Arrow;
			item.ranged = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("TwilightArrow");
			item.shootSpeed = 12f;
			item.UseSound = SoundID.Item5;
		}
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Terraria.Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("TwilightArrow"), damage, knockBack, player.whoAmI, 0f, 0f);
            return false;
        }
        public override void AddRecipes()
		{
			ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(null, "InfernalAppendage", 14);
            modRecipe.AddIngredient(null, "DuskStone", 14);
            modRecipe.AddIngredient(null, "IlluminatedCrystal", 14);
            modRecipe.AddIngredient(ItemID.ChlorophyteBar, 14);
            modRecipe.AddTile(134);
			modRecipe.SetResult(this, 1);
			modRecipe.AddRecipe();
		}
	}
}
