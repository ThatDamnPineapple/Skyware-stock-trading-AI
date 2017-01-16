using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class TalonBurst : ModItem
    {
		private int memes;
        public override void SetDefaults()
        {
            item.name = "Talon Burst";  
            item.damage = 15;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 12;
            item.useAnimation = 24;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 6;
            item.value = 100000;
            item.rare = 6;
            item.UseSound = SoundID.Item36;
            item.autoReuse = false;
            item.shoot = 10; 
			item.crit = 8;
            item.shootSpeed = 5f;
            item.useAmmo = AmmoID.Bullet;
        }
		
    }
}
