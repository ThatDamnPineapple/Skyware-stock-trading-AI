using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class ScarabSword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Scarab Blade";
            item.damage = 9;            
            item.melee = true;            
            item.width = 50;
            item.autoReuse = true;           
            item.height = 50;             
            item.toolTip = "Shoots a cluster of sand and dust on swing";  
            item.useTime = 32;           
            item.useAnimation = 32;     
            item.useStyle = 1;        
            item.knockBack = 3;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item1;          
            item.shoot = mod.ProjectileType("ScarabProjectile");
            item.shootSpeed = 7; ;            
            item.crit = 8;                     
        }
    }
}