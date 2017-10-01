using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpiritMod.Items.Halloween
{
    public class Candy : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Candy");
			Tooltip.SetDefault("Increases all stats slightly");
		}

		bool CandyToolTip = false;
        public override void SetDefaults()
        {
            item.width = 20; 
            item.height = 30;
            item.rare = 2;
            item.maxStack = 1;

            item.useStyle = 2;
            item.useTime = item.useAnimation = 20;

            item.consumable = true;
            item.autoReuse = false;

            item.buffType = mod.BuffType("CandyBuff");
            item.buffTime = 14400;

            item.UseSound = SoundID.Item2;
        }
		
		public override void ModifyTooltips (List< TooltipLine > tooltips)
		{
			if (!CandyToolTip)
			{
					string[] CandyTable = {"Hellfire Tamales", "100 Gold", "Necro Wafers", "Stardust Burst" };
			int candynum = Main.rand.Next(CandyTable.Length);
					TooltipLine line = new TooltipLine(mod, "ItemName", (CandyTable[candynum]));
					//line.overrideColor = new Color(160, 80, 0);
					CandyToolTip = true;
			}
		}
    }
}
