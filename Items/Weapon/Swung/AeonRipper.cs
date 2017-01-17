using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class AeonRipper : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Aeon Ripper";
            item.damage = 358;            
            item.melee = true;            
            item.width = 34;              
            item.height = 22;             
            item.toolTip = "'Feel the wrath'";  
            item.useTime = 5;
            item.autoReuse = true;
            item.useAnimation = 5;     
            item.useStyle = 1;        
            item.knockBack = 6;      
            item.value = 190000;        
            item.rare = 12;
            item.UseSound = SoundID.Item1;                  
            item.crit = 33;                     
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("SoulFlare"), 180);
        }
    }
}