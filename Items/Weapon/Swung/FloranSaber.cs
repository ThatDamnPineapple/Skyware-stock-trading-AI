using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
	public class FloranSaber : ModItem
	{
		public override void SetDefaults()
		{
            item.name = "Floran Saber";
            item.damage = 23;            
            item.melee = true;
            item.width = 40;
            item.height = 40;
			item.toolTip = " Vines occasionally ensnare the foes, reducing their movement speed";
			item.useTime = 30;
			item.useAnimation = 25;
            item.useStyle = 1;
			item.knockBack = 3;
            item.value = Terraria.Item.sellPrice(0, 0, 10, 0);
            item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}
        public override void AddRecipes()
        {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(null, "FloranBar", 15);
            modRecipe.AddTile(TileID.Anvils);
            modRecipe.SetResult(this);
            modRecipe.AddRecipe();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(5) == 0)
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 44);
            }
        }


        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)

        {
            {
                if (Main.rand.Next(5) == 0) target.AddBuff(mod.BuffType("VineTrap"), 180);
            }
        }

    }
}