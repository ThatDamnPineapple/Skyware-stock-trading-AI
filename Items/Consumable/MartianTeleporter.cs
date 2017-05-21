using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class MartianTeleporter : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Strange Beacon";
            item.width = item.height = 16;
            item.toolTip = "'How exactly does this work? I think I need to aim upwards'";
            item.toolTip2 = "'Hopefully it calls down something friendly...'";
            item.rare = 9;
            item.maxStack = 99;
            item.value = 100000;
            item.shoot = mod.ProjectileType("Starshock2");
            item.shootSpeed = 5f;
            item.useStyle = 4;
            item.useTime = item.useAnimation = 20;

            item.noMelee = true;
            item.consumable = true;
            item.autoReuse = false;

            item.UseSound = SoundID.Item43;
        }

        

        public override bool UseItem(Player player)
        {
            NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Martian Scientist"));
            return true;
        }
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(ItemID.Ectoplasm, 8);
            modRecipe.AddIngredient(ItemID.LihzahrdPowerCell, 1);
            modRecipe.AddIngredient(ItemID.MartianConduitPlating, 100);
            modRecipe.AddTile(134);
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }

    }
}
