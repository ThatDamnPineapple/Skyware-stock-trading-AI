using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Gun
{
    public class PolymorphGun : ModItem
    {
		private Vector2 newVect;
        public override void SetDefaults()
        {
            item.name = "Polymorph Gun";
            item.magic = true;
            item.damage = 35;
            item.mana = 18;
            item.width = 54;     
            item.height = 26;    
            item.useTime = 25;  
			item.toolTip = "Turns Enemies into Harmless Bunnies!";
            item.useAnimation = 25;
            item.useStyle = 5;    
            item.noMelee = true; 
            item.knockBack = 4;
            item.value = 100000;
            item.rare = 6;
            item.UseSound = SoundID.Item11;
            item.autoReuse = true;
            item.shootSpeed = 18f;
			item.shoot = mod.ProjectileType("Polyshot");
        }
    }
}