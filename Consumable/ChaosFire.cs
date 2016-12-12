using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class ChaosFire : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Chaos Fire";
            item.width = item.height = 16;
            item.toolTip = "'Summons the king of the hallow'";
            item.rare = 4;
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
            if (!NPC.AnyNPCs(mod.NPCType("IlluminantMaster")) && !Main.dayTime)
                return true;
            return false;
        }
        public override bool UseItem(Player player)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("IlluminantMaster"));
            }
            else
            {
                NetMessage.SendData(61, -1, -1, "", player.whoAmI, mod.NPCType("IlluminantMaster"), 0f, 0f, 0, 0, 0);
            }

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(1332, 3);
            recipe.AddIngredient(547, 1);
			recipe.AddIngredient(548, 1);
			recipe.AddIngredient(549, 1);
			recipe.AddIngredient(502, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
			 ModRecipe recipe2 = new ModRecipe(mod);
            recipe2.AddIngredient(522, 3);
            recipe2.AddIngredient(547, 1);
			recipe2.AddIngredient(548, 1);
			recipe2.AddIngredient(549, 1);
			recipe2.AddIngredient(502, 10);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.SetResult(this);
            recipe2.AddRecipe();
        }
    }
}
