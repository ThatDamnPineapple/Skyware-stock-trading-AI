using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class DusksMusket : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Dusk's Musket";  
            item.damage = 45;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 28;  
            item.useAnimation = 28;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 4;
            item.value = 12980;
            item.rare =5;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = 10; 
            item.shootSpeed = 16f;
            item.useAmmo = AmmoID.Bullet;
        }
    }
}