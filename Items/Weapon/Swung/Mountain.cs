using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class Mountain : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "The Mountain";
            item.damage = 32;
            item.melee = true;
            item.width = 34;
            item.height = 40;
            item.toolTip = "'Swinging the blade strengthens you'";
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = 1;
            item.knockBack = 6;
            item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override bool UseItem(Player player)
        {
            if (Main.rand.Next(6) == 0)
            {
                player.AddBuff(5, 130);
            }
            return true;
        }

    }
}