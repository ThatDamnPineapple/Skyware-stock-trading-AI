using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
	public class BoneCharm : ModItem
	{
        public override bool Autoload(ref string name, ref string texture, System.Collections.Generic.IList<EquipType> equips)
        {
            equips.Add(EquipType.Neck);
            return true;
        }

        public override void SetDefaults()
		{
			item.name = "Bone Charm";
			item.width = 26;
			item.height = 24;
            item.toolTip = "Increases Mana by 40 when below 50% Health.";
            item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = 2;

			item.accessory = true;
			item.defense = 1;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense -= 8;
			if (player.statLife <= player.statLifeMax2 / 2)
			{
                player.statManaMax2 += 60;
            }
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 20);
            recipe.AddIngredient(ItemID.ManaCrystal);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}
