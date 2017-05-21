using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Returning
{
	public class BallOfFlesh : ModItem
	{
		public override void SetDefaults()
		{
            item.name = "Ball of Flesh";
            item.damage = 36;  
            item.thrown = true;
            item.width = 40;
            item.height = 40;
			item.toolTip = "'Squishy, but powerful'";
			item.useTime = 30;
			item.useAnimation = 25;
            item.noUseGraphic = true;
            item.useStyle = 1;
			item.knockBack = 3;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 0);
            item.rare = 4;
			item.shootSpeed = 9f;
			item.shoot = mod.ProjectileType ("BallOfFlesh");
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
        public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
    }
}