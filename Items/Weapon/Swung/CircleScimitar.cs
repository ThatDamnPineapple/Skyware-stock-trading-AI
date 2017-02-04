using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class CircleScimitar : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Circe's Scimitar";     
            item.damage = 48;            
            item.melee = true;            
            item.width = 34;              
            item.height = 40;             
            item.toolTip = "Occaisionally shoots out a marble block";  
            item.useTime = 25;           
            item.useAnimation = 25;     
            item.useStyle = 1;        
            item.knockBack = 4;      
            item.value = 10000;        
            item.rare = 5;
            item.UseSound = SoundID.Item1;         
            item.shoot = mod.ProjectileType("MarbleBrick");
            item.shootSpeed = 6f;            
            item.crit = 4;                     
        }
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
			int proj = Projectile.NewProjectile(position.X, position.Y, (speedX / 3) * 2, speedY, type, damage, knockBack, player.whoAmI);
		return true;
	}
    }
}