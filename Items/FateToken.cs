using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace SpiritMod.Items
{
    public class FateToken : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Fate Token";
            item.width = 36;
            item.height = 36;
            item.maxStack = 999;
            AddTooltip("For the next minute, taking fatal damage will instead return you to 500 health");
            item.rare = 10;
            item.value = Item.buyPrice(0, 50, 0, 0);
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }

     
        public override bool UseItem(Player player)
        {
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
			if (!modPlayer.fateToken)
			{
			modPlayer.fateToken = true;
			modPlayer.timeLeft = 3600;
            Main.NewText("Fate has blessed you");
			player.AddBuff(mod.BuffType("FateToken"), 3600);
            return true;
			}
			return false;
        }
    }
}
