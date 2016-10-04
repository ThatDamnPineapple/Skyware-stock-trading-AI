using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.PrimalstoneArmor
{
    public class PrimalstoneFaceplate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Primalstone Faceplate";
            item.width = 40;
            item.height = 30;
            item.toolTip = "+5% damage reduction but -5% move speed";
            item.value = 10000;
            item.rare = 6;

            item.defense = 4;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("PrimalstoneBreastplate") && legs.type == mod.ItemType("PrimalstoneLeggings");  
        }
        public override void UpdateArmorSet(Player player)
        {            
            player.setBonus = "Press a Hotkey unleash a pulse of 'Primal Energy'\nEnemies caught in the blast will suffer Unstable Affliction for 6 seconds";
            MyPlayer mp = player.GetModPlayer<MyPlayer>(mod);
            player.moveSpeed -= 0.1F;
        }

        public override void UpdateEquip(Player player)
        {
            player.endurance += 0.05F;
            player.moveSpeed -= 0.05F;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "ArcaneGeyser", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}