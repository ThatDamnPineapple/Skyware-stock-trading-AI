using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.FrigidArmor
{
    [AutoloadEquip(EquipType.Head)]
    public class FrigidHelm : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frigid Faceplate");
            Tooltip.SetDefault("Increases melee damage by 3%\nIncreases maximum mana by 15");

        }


        int timer = 0;
        public override void SetDefaults()
        {
            item.width = 28;
            item.height = 24;
            item.value = 1100;
            item.rare = 1;
            item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.05f;
            player.statManaMax2 += 15;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("FrigidChestplate") && legs.type == mod.ItemType("FrigidLegs");
        }
        public override void UpdateArmorSet(Player player)
        {
            Player closest = Main.player[(int)Player.FindClosest(player.position, player.width, player.height)];

            player.setBonus = "Increases movement speed by 4%, magic critical strike chance by 3%, and melee speed by 2% when in the Snow Biome";

            if (closest.ZoneSnow)
            {
                player.maxRunSpeed += 0.04f;
                player.magicCrit += 3;
                player.meleeSpeed += 0.02f;
                if (Main.rand.Next(6) == 0)
                {
                    int dust = Dust.NewDust(player.position, player.width, player.height, 187);
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FrigidFragment", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
