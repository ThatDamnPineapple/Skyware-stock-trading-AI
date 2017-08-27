using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class BlueMoonSpawn : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Moon Spawner");
			Tooltip.SetDefault("Spawns the blue moon");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 16;
            item.rare = 5;

            item.maxStack = 99;

            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item43;
        }

        public override bool CanUseItem(Player player)
        {
            if (Main.dayTime)
            {
                Main.NewText("The moon cannot be graced in daylight.", 200, 80, 130, true);
                return false;
            }

            return true;
        }

        public override bool UseItem(Player player)
        {
			Main.NewText("The Blue Moon is Rising...", 0, 90, 220, true);
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			MyWorld.BlueMoon = true; 
            return true;
        }

       
    }
}
