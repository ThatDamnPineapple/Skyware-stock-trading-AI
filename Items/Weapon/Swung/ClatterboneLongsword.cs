using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class ClatterboneLongsword : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Clatterbone Longsword";     
            item.damage = 24;            
            item.melee = true;            
            item.width = 34;              
            item.height = 40;             
            item.toolTip = "Attacks occasionally pierce through enemies, lowering their defense";  
            item.useTime = 34;           
            item.useAnimation = 34;     
            item.useStyle = 1;        
            item.knockBack = 6;
            item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item1;       
			item.autoReuse = false;			
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Carapace", 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.Next(6) == 0)
            {
                target.AddBuff(mod.BuffType("ClatterPierce"), 180);
            }
        }
    }
}