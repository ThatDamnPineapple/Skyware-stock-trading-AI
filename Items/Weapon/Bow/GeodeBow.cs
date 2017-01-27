using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class GeodeBow : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Geode Bownanza";
            item.damage = 39;
            item.ranged = true;
            item.width = 36;
            item.height = 36;
            item.useTime = 26;
            item.useAnimation = 26;            
            item.useStyle = 5;
			item.shoot = 3;
			item.shootSpeed = 10f;
            item.knockBack = 7;
            item.value = 10000;
            item.rare = 5;
            item.UseSound = SoundID.Item5;   
            item.autoReuse = true;
			item.useAmmo = AmmoID.Arrow;
            item.crit = 6;
            item.useTurn = true;
        }
        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Geode", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(12) == 0)
            {
                target.AddBuff(BuffID.CursedInferno, 300, true);
            }
            if (Main.rand.Next(12) == 0)
            {
                target.AddBuff(BuffID.Frostburn, 300, true);
            }
            if (Main.rand.Next(12) == 0)
            {
                target.AddBuff(BuffID.OnFire, 300, true);
            }
            if (Main.rand.Next(8) == 0)
            {
                target.AddBuff(BuffID.BrokenArmor, 600, true);
            }
        }
    }
}
