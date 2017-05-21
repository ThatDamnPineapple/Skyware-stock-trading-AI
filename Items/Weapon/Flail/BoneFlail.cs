using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Flail
{
    public class BoneFlail : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Serpent Spine";
            item.width = 20;
            item.height = 20;
            item.rare = 3;
            AddTooltip("Retracts on contact with enemies or blocks");
            item.noMelee = true;
            item.useStyle = 5; 
            item.useAnimation = 50;
            item.autoReuse = true; 
            item.useTime = 50;
            item.knockBack = 5;
            item.value = Item.sellPrice(0, 0, 20, 0);
            item.damage = 24;
            item.noUseGraphic = true; 
            item.shoot = mod.ProjectileType("BoneFlailHead");
            item.shootSpeed = 14f;
            item.UseSound = SoundID.Item1;
            item.melee = true; 
            item.channel = true; 
        }
    }
}