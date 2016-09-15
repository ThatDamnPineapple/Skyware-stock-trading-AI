using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Vanity
{
	class CandyCopterOutfit : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Body);
			equips.Add(EquipType.Legs);
			return true;
		}
		//this Item exists only for visual purposes, no need for default values.
	}
}
