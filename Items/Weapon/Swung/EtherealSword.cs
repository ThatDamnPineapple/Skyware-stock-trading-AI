using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class EtherealSword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Ethereal Sword";     
            item.damage = 49;            
            item.melee = true;            
            item.width = 42;              
            item.height = 42;             
            item.toolTip = "Inflicts Essence Trap";  
            item.useTime = 24;           
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
            item.crit = 6;                                
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("EssenceTrap"), 520);
        }
    }
}