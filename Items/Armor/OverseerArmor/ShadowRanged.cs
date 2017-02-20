using System;
using System.Collections.Generic;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.OverseerArmor
{
    public class ShadowRanged : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Shadowspirit Shako";
            item.width = 40;
            item.height = 30;
            item.toolTip = "Increases ranged and throwing damage by 32% \n Increases ranged and thrower crit chance by 22% \n Increases movement speed by 30% \n Increases thrown velocity by 25%";
            item.value = 200000;
            item.rare = 11;

            item.defense = 22;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("ShadowSBody") && legs.type == mod.ItemType("ShadowLegs");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Ranged and thrower hits spawn Soul Shards to chase down foes! \n 'You have become the Guardian' \n Double tap to dash repeatedly \n You are surrounded by protective Spirits, which deflect projectiles.";
            player.GetModPlayer<MyPlayer>(mod).rangedshadowSet = true;
            player.GetModPlayer<MyPlayer>(mod).shadowSet = true;


            if (Main.rand.Next(4) == 1)
            {

                Dust.NewDust(player.position, player.width, player.height, 187);
            }
        }
        public override void ArmorSetShadows(Player player)
        {
            player.armorEffectDrawShadow = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedCrit += 22;
            player.thrownCrit += 22;
            player.rangedDamage += 0.32F;
            player.thrownDamage += 0.32F;
            player.thrownVelocity = 1.25f;
            player.moveSpeed += 0.30F;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "EternityEssence", 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
