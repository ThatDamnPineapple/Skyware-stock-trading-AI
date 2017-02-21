using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Yoyo
{
	public class EyeOfTheInferno : ModItem
    {

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.name = "Eye Of The Inferno";                      
            item.damage = 50;
            item.value = Terraria.Item.sellPrice(0, 8, 0, 0);
            item.rare = 6;
            item.toolTip = "Shoots out spurts of flame";
			item.crit = 4;
            item.knockBack = 2.9f;
            item.channel = true;
            item.useStyle = 5;
            item.useAnimation = 26;
            item.useTime = 26;
            item.shoot = mod.ProjectileType("EyeOfTheInfernoProj");           
        }
    }
}