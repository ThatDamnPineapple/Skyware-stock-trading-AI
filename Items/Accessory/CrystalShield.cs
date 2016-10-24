using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class CrystalShield : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Shield);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Crystal Shield";
            item.width = 30;
            item.height = 28;
            item.toolTip = "Walking leaves an aura of crystal";
			 item.toolTip2 = "'Forged with crystilium'";
            item.rare = 7;
			item.expert = true;
            item.defense = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>(mod).CrystalShield = true;
        }
    }
}
