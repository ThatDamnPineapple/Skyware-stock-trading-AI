using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Material
{
	public class StarPiece : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Star Piece";
			item.width = 18;
			item.height = 18;
			item.toolTip = "Used with adamantite/titanium to craft Stellar items";
			item.value = 100;
            item.rare = 5;

            item.maxStack = 999;

			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override DrawAnimation GetAnimation()
		{
			return new DrawAnimationVertical(4, 4);
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return Color.White;
		}
	}
}