using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class GeodeHamaxe : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Geode Hamaxe";
            item.width = 42;
            item.height = 40;
            item.value = 40000;
            item.rare = 5;

            item.axe = 20;
            item.hammer = 80;

            item.crit = 6;
            item.damage = 16;
            item.knockBack = 6;

            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 25;

            item.melee = true;
            item.useTurn = true;
            item.autoReuse = true;

            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()  
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Geode", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.Next(12) == 0)
                target.AddBuff(BuffID.CursedInferno, 200, true);
            if (Main.rand.Next(12) == 0)
                target.AddBuff(BuffID.Frostburn, 200, true);
            if (Main.rand.Next(12) == 0)
                target.AddBuff(BuffID.OnFire, 200, true);
        }
    }
}
