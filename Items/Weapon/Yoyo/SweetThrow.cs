using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Yoyo
{
	public class SweetThrow : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.name = "Sweet Throw";                      
            item.damage = 25;
            item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
            item.rare = 4;
            item.knockBack = 2;
            item.channel = true;
            item.toolTip = "Spawns forth bees to fight for you";
            item.useStyle = 5;
            item.useAnimation = 25;
            item.useTime = 27;
            item.shoot = mod.ProjectileType("SweetThrowProjectile");           
        }
    }
}