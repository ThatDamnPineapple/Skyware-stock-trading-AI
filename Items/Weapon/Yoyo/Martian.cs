using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Yoyo
{
    public class Martian : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.name = "Terrestrial Ultimatum";                      
            item.damage = 124;                            
            item.value = 43000;
            item.rare = 10;
            item.knockBack = 4;
            item.channel = true;
            item.useStyle = 5;
            item.useAnimation = 28;
            item.useTime = 25;
            item.shoot = mod.ProjectileType("MartianP");           
        }
    }
}