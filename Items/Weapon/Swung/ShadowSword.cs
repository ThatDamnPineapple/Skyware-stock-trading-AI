using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class ShadowSword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Possessed Blade";     
            item.damage = 45;            
            item.melee = true;            
            item.width = 44;              
            item.height = 44;             
            item.useTime = 35;           
            item.useAnimation = 24;     
            item.useStyle = 1;        
            item.knockBack = 5;      
            item.value = 1000;        
            item.rare = 5;
            item.UseSound = SoundID.Item1;        
            item.autoReuse = true;
			item.value = Item.buyPrice(0, 4, 0, 0);
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.useTurn = true;
            item.crit = 8;                
        }
    }
}