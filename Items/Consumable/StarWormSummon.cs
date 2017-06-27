using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable
{
    public class StarWormSummon : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starplate Beacon");
			Tooltip.SetDefault("'Look toward the night sky'");
		}


        public override void SetDefaults()
        {
            item.width = item.height = 16;
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
            if (!NPC.AnyNPCs(mod.NPCType("SteamRaiderHead")) && !Main.dayTime)
                return true;
            return false;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("SteamRaiderHead"));
           

            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "TechDrive", 2);
            recipe.AddIngredient(null, "StarEnergy", 1);
            recipe.AddIngredient(null, "FossilFeather", 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
