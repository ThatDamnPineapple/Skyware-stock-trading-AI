using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class JewelCrown : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Jewel Crown";
            item.width = item.height = 16;
            item.toolTip = "'Summons the king of the skies'";
            item.rare = 2;
            item.maxStack = 99;

            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item43;
        }


        public override bool UseItem(Player player)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("AncientFlyer"));
            }
            else
            {
                NetMessage.SendData(61, -1, -1, "", player.whoAmI, mod.NPCType("AncientFlyer"), 0f, 0f, 0, 0, 0);
            }

            return true;
        }

    }
}
