
using Terraria;
using Terraria.ModLoader;
using SpiritMod.NPCs;
using Microsoft.Xna.Framework;

namespace SpiritMod.Buffs.Glyph
{
	public class DevouringVoid : ModBuff
	{
		public static int _type;

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Devouring Void");
			Description.SetDefault("");
			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override bool ReApply(NPC npc, int time, int buffIndex)
		{
			return true;
		}
		

		public override void Update(NPC npc, ref int buffIndex)
		{
			GNPC npcData = npc.GetGlobalNPC<GNPC>();

			if (Main.rand.NextDouble() < 0.08f + npcData.voidStacks * 0.0012f)
				Dust.NewDustDirect(npc.position - new Vector2(4), npc.width + 8, npc.height + 8, Dusts.VoidDust._type).customData = npc;
			
			if (npcData.voidStacks > 1)
				npc.buffTime[buffIndex] = 2;
			else
				npc.DelBuff(buffIndex);
		}

		public override void ModifyBuffTip(ref string tip, ref int rare)
		{
		}
	}
}
