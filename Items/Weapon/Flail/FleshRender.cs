using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Flail
{
    public class FleshRender : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Flesh Render";
            item.width = 20;
            item.height = 20;
            item.rare = 2;
            item.noMelee = true;
            item.toolTip = "Seeks out the nearest enemy \n Inflicts Blood Corruption";
            item.useStyle = 5; 
            item.useAnimation = 34; 
            item.useTime = 34;
            item.knockBack = 4;
            item.value = Item.sellPrice(0, 1, 0, 0);
            item.damage = 19;
            item.noUseGraphic = true; 
            item.shoot = mod.ProjectileType("FleshRenderProj");
            item.shootSpeed = 10f;
            item.UseSound = SoundID.Item1;
            item.melee = true; 
            item.channel = true; 
        }
    }
}