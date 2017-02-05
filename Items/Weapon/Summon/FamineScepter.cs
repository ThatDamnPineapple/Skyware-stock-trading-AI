using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Summon
{
    public class FamineScepter : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Famine Scepter";
            item.width = 26;
            item.height = 28;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 4;
            item.crit = 4;
            item.toolTip = "Summons a hungry to fight for you... on you...";
            item.mana = 14;
            item.damage = 24;
            item.knockBack = 3;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.summon = true;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("HungryMinion");
            item.buffType = mod.BuffType("HungryMinionBuff");
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
    }
}
