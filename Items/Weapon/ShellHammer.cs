using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon
{
	public class ShellHammer : ModItem
	{
        int shellCooldown;

		public override void SetDefaults()
		{
			item.name = "Shell Hammer";
            item.width = 60;
            item.height = 60;
            item.toolTip = "Lobs shells duuuude!";
            item.value = Item.sellPrice(0, 6, 20, 0);
            item.rare = 6;

            item.hammer = 90;

            item.damage = 87;
            item.knockBack = 9;

            item.useStyle = 1;
            item.useTime = 35;
			item.useAnimation = 35;

            item.melee = true;
            item.autoReuse = true;

            item.shoot = mod.ProjectileType("ShellHammerProjectile");
            item.shootSpeed = 4;

            item.useSound = 1;

            this.shellCooldown = 120;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (shellCooldown > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].active() || Main.tile[Player.tileTargetX, Player.tileTargetY].wall > 0)
                return false;

            return true;
        }

        public override void UpdateInventory(Player player)
        {
            shellCooldown--;
        }

        public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 18);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}