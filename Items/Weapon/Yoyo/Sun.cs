using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Yoyo
{
	public class Sun : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.name = "Sun";                      
            item.damage = 97;                            
            item.value = 23300;
            item.rare = 10;
            item.knockBack = 3;
            item.channel = true;
            item.useStyle = 5;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shoot = mod.ProjectileType("SunProjectile");           
        }
    }
}