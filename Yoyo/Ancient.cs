using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Yoyo
{
	public class Ancient : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.name = "Ancient";                      
            item.damage = 104;                            
            item.value = 70000;
            item.rare = 9;
            item.knockBack = 3;
            item.channel = true;
            item.useStyle = 5;
            item.useAnimation = 28;
            item.useTime = 25;
            item.shoot = mod.ProjectileType("AncientP");           
        }
    }
}