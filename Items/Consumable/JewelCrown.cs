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
            item.toolTip = "'Summons the ruler of the skies'";
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
            
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("AncientFlyer"));
           

            return true;
        }

    }
}
