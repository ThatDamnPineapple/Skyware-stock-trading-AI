using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class Longbowne : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Longbowne";
            item.damage = 22;
            item.noMelee = true;
            item.ranged = true;
            item.width = 22;
            item.height = 40;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.shoot = 3;
            item.useAmmo = 1;
            item.knockBack = 2;
            item.value = 1000;
            item.rare = 3;
            item.useSound = 5;
            item.shootSpeed = 6f;
        }               
    }
}