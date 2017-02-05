using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class TeslaSpike : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Tesla Spike";     
            item.damage = 65;
            item.magic = true;
            item.mana = 10;
            item.width = 52;       
            item.height = 24;      
            item.toolTip = "'Electriiiiiiiic'";    
            item.useTime = 19;  
            item.useAnimation = 19;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 2;
            item.value = 35000;
            item.rare = 8;
            item.UseSound = SoundID.Item12;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("TeslaSpikeProjectile");
            item.shootSpeed = 20f;
        }
    }
}
