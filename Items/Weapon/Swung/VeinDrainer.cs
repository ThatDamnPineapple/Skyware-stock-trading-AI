using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class VeinDrainer : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Vein Drainer";     
            item.damage = 61;            
            item.melee = true;            
            item.width = 60;              
            item.height = 72;             
            item.toolTip = "Lifesteals rarely";  
            item.useTime = 39;           
            item.useAnimation = 39;     
            item.useStyle = 1;        
            item.knockBack = 4;      
            item.value = 1000;        
            item.rare = 5;
            item.useSound = 1;       
            item.autoReuse = true;
			item.value = Item.buyPrice(0, 4, 0, 0);
			item.value = Item.sellPrice(0, 1, 0, 0);
            item.crit = 0;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Veinstone", 8);
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
        }
    }
}