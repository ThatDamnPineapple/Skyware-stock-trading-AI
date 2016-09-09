using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon
{
	public class ShellHammer : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Shell Hammer";
			item.damage = 87;
			item.melee = true;
			item.width = 60;
			item.height = 60;
            item.hammer = 90;
			item.toolTip = "Lobs shells duuuude!";
			item.useTime = 35;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.knockBack = 9;
			item.value = 10000;
			item.rare = 6;
			item.useSound = 1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TurtleShell, 1);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}