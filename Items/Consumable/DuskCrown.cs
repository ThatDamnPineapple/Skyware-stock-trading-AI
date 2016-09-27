using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class DuskCrown : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Dusk Crown";
            item.width = item.height = 16;
            item.toolTip = "'Beware the king of night'";
            item.rare = 4;
            item.maxStack = 99;

            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.useSound = 5;
        }

        public override bool CanUseItem(Player player)
        {
            if (!NPC.AnyNPCs(mod.NPCType("Dusking")))
                return true;
            return false;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Dusking"));
            }
            else
            {
                NetMessage.SendData(61, -1, -1, "", player.whoAmI, mod.NPCType("Dusking"), 0f, 0f, 0, 0, 0);
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritBar", 3);
            recipe.AddIngredient(ItemID.SoulofNight, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
