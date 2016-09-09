using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class Butcher : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Butcher";     
            item.damage = 16;            
            item.melee = true;            
            item.width = 40;              
            item.height = 47;             
            item.toolTip = "Inflicts Blood Corruption";  
            item.useTime = 32;           
            item.useAnimation = 24;     
            item.useStyle = 1;        
            item.knockBack = 5;      
            item.value = 1000;        
            item.rare = 2;
            item.useSound = 1;       
            item.autoReuse = true;
			item.value = Item.buyPrice(0, 4, 0, 0);
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.useTurn = true;
            item.crit = 8;              
                         
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("BCorrupt"), 120);
        }
    }
}