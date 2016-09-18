using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class DistortionSting : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Distortion Sting";  
            item.damage = 75;  
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 25;  
            item.useAnimation = 25;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 4;
            item.value = 100000;
            item.rare = 6;
            item.useSound = 11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("AlienSpit"); 
            item.shootSpeed = 5f;
        }
    }
}