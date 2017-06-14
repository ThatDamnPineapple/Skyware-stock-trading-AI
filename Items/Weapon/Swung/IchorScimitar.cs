using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class IchorScimitar : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ichor Scimitar");
			Tooltip.SetDefault("Inflicts foes with ichor");
		}


        public override void SetDefaults()
        {
            item.damage = 54;            
            item.melee = true;            
            item.width = 60;              
            item.height = 72;             
            item.useTime = 37;           
            item.useAnimation = 37;     
            item.useStyle = 1;        
            item.knockBack = 3;             
            item.rare = 5;
            item.UseSound = SoundID.Item1;        
            item.autoReuse = true;
			item.value = Item.buyPrice(0, 12, 0, 0);
			item.value = Item.sellPrice(0, 3, 0, 0);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FleshClump", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
			if (Main.rand.Next(3) == 1)
			{
            player.HealEffect(4);
            player.statLife += 4;
			}
        {
                target.AddBuff(BuffID.Ichor, 180);
            }
    }
    }
}