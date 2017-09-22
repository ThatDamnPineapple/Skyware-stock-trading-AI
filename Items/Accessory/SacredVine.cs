using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace SpiritMod.Items.Accessory
{
<<<<<<< HEAD
    public class SacredVine : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sacred Vine");
            Tooltip.SetDefault("Empowers Oak Heart: Oak Heart now inflicts 'Pollinating Poison'\nIncreases throwing critical strike chance by 4% and melee damage by 4%");
=======
	public class SacredVine : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sacred Vine");
			Tooltip.SetDefault("Empowers Oak Heart: Oak Heart now inflicts 'Pollinating Poison'\nIncreases throwing critical strike chance by 4%");
		}
>>>>>>> fa4f832c99c4926d56e19517ec763ad973d66f1b


		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = Item.sellPrice(0, 2, 0, 0);
			item.rare = 2;
			item.accessory = true;
		}

<<<<<<< HEAD
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 2;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>(mod).sacredVine = true;
            player.thrownCrit += 4;
			player.meleeDamage += .04f;
=======
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<MyPlayer>(mod).sacredVine = true;
			player.thrownCrit += 4;
>>>>>>> fa4f832c99c4926d56e19517ec763ad973d66f1b
		}
	}
}
