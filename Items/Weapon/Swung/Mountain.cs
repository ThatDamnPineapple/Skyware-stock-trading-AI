using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class Mountain : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "The Mountain";     
            item.damage = 14;            
            item.melee = true;            
            item.width = 34;              
            item.height = 40;             
            item.toolTip = "'Swinging the blade strengthens you'";  
            item.useTime = 32;           
            item.useAnimation = 32;     
            item.useStyle = 1;        
            item.knockBack = 6;      
            item.value = 10000;        
            item.rare = 1;
            item.UseSound = SoundID.Item1;       
			item.autoReuse = false;			
        }
        public override bool UseItem(Player player)
        {
			if (Main.rand.Next(6) == 0)
			{
            player.AddBuff(5, 130);
			}
            return true;
        }
		
    }
}