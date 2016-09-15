using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Tool
{
    public class AntlionClaws : ModItem
    {
        public override void SetDefaults()
        {
            item.name = "Antlion Digging Claws";
            item.damage = 6;
            item.melee = true;
            item.width = 26;
            item.height = 24;
            item.useTime = 3;
            item.useAnimation = 5;
            item.pick = 40;               
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 1000;
            item.rare = 2;
            item.useSound = 1;
            item.autoReuse = true;
            item.useTurn = false;
        }
    }
}