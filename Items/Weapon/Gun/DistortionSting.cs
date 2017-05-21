using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class DistortionSting : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Distortion Sting";  
            item.damage = 105;
            AddTooltip("'Fashioned from Alien appendages'");
            AddTooltip("Shoots out globules of energy that distort enemies' gravity!");
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 16;  
            item.useAnimation = 16;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 4;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 6, 0, 0);
            item.rare = 9;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("AlienSpit"); 
            item.shootSpeed = 15f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
    }
}