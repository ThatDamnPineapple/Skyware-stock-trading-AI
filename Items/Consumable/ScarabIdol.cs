using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class ScarabIdol : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Scarab Idol";
            item.width = item.height = 16;
            item.toolTip = "???";
            item.rare = 2;
            item.maxStack = 99;

            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item43;
        }

        public override bool CanUseItem(Player player)
        {
            if (!NPC.AnyNPCs(mod.NPCType("Scarabeus")))
                return true;
            return false;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Scarabeus"));
            }
            else
            {
                NetMessage.SendData(61, -1, -1, "", player.whoAmI, mod.NPCType("Scarabeus"), 0f, 0f, 0, 0, 0);
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Sapphire, 1);
            recipe.AddIngredient(ItemID.Topaz, 1);
			recipe.AddIngredient(323, 3);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
