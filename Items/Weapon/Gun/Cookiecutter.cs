using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class Cookiecutter : ModItem

    {private Vector2 newVect;

        public override void SetDefaults()
        {
            item.name = "The Cookiecutter";  
            item.damage = 19;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 9;
			 item.toolTip = "'Rapidly fires bullets'";
            item.useAnimation = 9;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 2;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
			item.UseSound = SoundID.Item36;
            item.autoReuse = true;
            item.shoot = 10; 
            item.shootSpeed = 15f;
            item.useAmmo = AmmoID.Bullet;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }		
    }
}
