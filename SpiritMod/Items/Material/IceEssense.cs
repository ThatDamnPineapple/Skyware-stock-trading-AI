using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
	public class IceEssense : ModItem
	{
		// TODO -- Velocity Y smaller, post NewItem?
		public override void SetDefaults()
		{
			item.name = "Icy Essence";
			item.width = 18;
			item.height = 18;
			item.maxStack = 999;
			item.toolTip = "'I don't know what to put here.'";
			item.value = 1000;
			item.rare = 3;
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override DrawAnimation GetAnimation()
		{
			// ticksperframe, frameCount
			return new DrawAnimationVertical(55, 4);
		}
	}

	public class IceSoulGlobalNPC : GlobalNPC
	{
		public override void NPCLoot(NPC npc)
		{
			if (Main.player[Main.myPlayer].ZoneSnow && Main.rand.Next(5) == 3)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IceEssense"), 1);
			}
		}
	}
}