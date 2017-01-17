using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Yoyo
{
	public class SlickThrow : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.name = "Slick Throw";                      
            item.damage = 16;                            
            item.value = 900;
            item.rare = 2;
            item.knockBack = 3;
            item.channel = true;
            item.useStyle = 5;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shoot = mod.ProjectileType("SlickThrowProjectile");           
        }
    }
}