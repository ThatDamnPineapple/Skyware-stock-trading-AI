using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class StarlightBow : ModItem
    {

        public override void SetDefaults()
        {
            item.name = "Star Spray";
            item.damage = 10;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.toolTip = "Let it Rain Stars!";
            item.height = 40;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useStyle = 5;
            item.shoot = 9;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 3;
            item.value = 1000;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shootSpeed = 20f;
        }        
    }
}