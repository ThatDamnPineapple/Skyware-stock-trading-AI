using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
	public class StarPiece : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Star piece";
			item.width = 18;
			item.height = 18;
			item.toolTip = "Used with adamantite/titanium to craft stellar items";
			item.value = 100;
            item.maxStack = 999;
			item.rare = 3;
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