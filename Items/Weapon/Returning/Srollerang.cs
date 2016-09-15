using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Returning
{
	public class Srollerang : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodenBoomerang);
            item.name = "Srollerang";                      
            item.damage = 140;                            
            item.value = 100;
            item.rare = 4;
			item.shootSpeed = 14;
            item.knockBack = 2;
            item.useStyle = 5;
            item.useAnimation = 30;
            item.useTime = 30;
            item.shoot = mod.ProjectileType("SrollerangProjectile"); 
 
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