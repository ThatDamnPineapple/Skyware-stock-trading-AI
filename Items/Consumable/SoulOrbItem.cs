using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class SoulOrbItem : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Soul Orb";
            item.width = item.height = 16;
            item.toolTip = "'Legend says touching it gives good luck'";
            item.rare = 1;
            item.maxStack = 99;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

        }
        public override bool UseItem(Player player)
        {
            NPC.NewNPC((int)player.Center.X, (int)player.Center.Y, mod.NPCType("SoulOrb"));
            return true;
        }

        }
}
