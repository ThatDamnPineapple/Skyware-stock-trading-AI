using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class Cookiecutter : ModItem
    { 
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Cookiecutter");
			Tooltip.SetDefault("'Rapidly fires bullets'");
		}

       private Vector2 newVect;

        public override void SetDefaults()
        {
            item.damage = 19;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 9;
            item.useAnimation = 9;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 2;
            item.useTurn = false;
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
