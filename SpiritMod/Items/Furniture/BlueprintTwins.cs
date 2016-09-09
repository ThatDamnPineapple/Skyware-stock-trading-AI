using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Furniture
{
	public class BlueprintTwins : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Twins Blueprint";
            item.width = 94;
			item.height = 62;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 15000;
            item.toolTip = "They can't kill what they don't see, but they see everything.";
            item.rare = 6;
            item.createTile = mod.TileType("TwinsPrint");
		}
	}
}