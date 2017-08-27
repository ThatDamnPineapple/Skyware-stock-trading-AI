using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
	 [AutoloadEquip(EquipType.Head)]
	public class MadHat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mad Hat");
			Tooltip.SetDefault("Can be thrown or worn \nIncreases magic damage by 10% \nIncreases magical crit chance by 8%");
		}


		public override void SetDefaults()
		{
			item.damage = 43;
			 item.magic = true;
			item.width = 18;
			item.mana = 7;
			item.height = 28;
            item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 5;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("MadHatProj");
			item.shootSpeed = 11f;
			item.noUseGraphic = true;
			item.defense = 6;
		}
         public override void UpdateEquip(Player player)
        {
            player.magicCrit += 8;
           player.magicDamage += 0.02f;
        }
		  public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
