using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Yoyo
{
	public class Techno : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.name = "Techn-0";
            item.damage = 58;
            item.value = 15090;
            item.rare = 6;
            item.knockBack = 2;
            item.channel = true;
            item.useStyle = 5;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shoot = mod.ProjectileType("TechnoProjectile");
        }
    }
}