using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    public class TalonHeaddress : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Head);
            return true;
        }

        public override void SetDefaults()
        {
            item.name = "Talon Headdress";
            item.width = 38;
            item.height = 26;
            item.toolTip = "8% increased Ranged damage and Critical Strike Chance";
            item.value = 10000;
            item.rare = 3;
            item.defense = 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("TalonGarb") && legs.type == mod.ItemType("TalonClaws");  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Wind Spirits guide you, granting you double jumps and extra attacks.";
            player.doubleJumpCloud = true;
            player.GetModPlayer<MyPlayer>(mod).talonSet = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.08f;
            player.rangedCrit += 8;
            player.moveSpeed += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Talon", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
        }
    }
}
