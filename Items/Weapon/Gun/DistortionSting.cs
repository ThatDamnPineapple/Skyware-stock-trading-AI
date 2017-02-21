using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class DistortionSting : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Distortion Sting";  
            item.damage = 95;
            item.toolTip = "'Fashioned from Alien appendages' \n Shoots out globules of energy that distort enemies' gravity!";
            item.ranged = true;   
            item.width = 65;     
            item.height = 21;    
            item.useTime = 25;  
            item.useAnimation = 25;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 4;
            item.useTurn = true;
            item.value = Terraria.Item.sellPrice(0, 10, 0, 0);
            item.rare = 9;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("AlienSpit"); 
            item.shootSpeed = 8f;
        }
    }
}