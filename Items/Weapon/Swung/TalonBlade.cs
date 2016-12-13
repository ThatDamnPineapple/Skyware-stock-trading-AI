using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class TalonBlade : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Talon Blade";     
            item.damage = 21;            
            item.melee = true;            
            item.width = 34;              
            item.height = 40;             
            item.toolTip = "Launches a feather";  
            item.useTime = 28;           
            item.useAnimation = 28;     
            item.useStyle = 1;        
            item.knockBack = 5;      
            item.value = 10000;        
            item.rare = 1;
            item.UseSound = SoundID.Item1;    
            item.shoot = 38;
            item.shootSpeed = 10f;            
            item.crit = 8;  
			item.autoReuse = true;
        }
      
		 public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		 {
			 Projectile proj = Main.projectile[Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI)];
proj.friendly = true;
proj.hostile = false;
proj.netUpdate = true;
			 return false;
		 }
    }
}
