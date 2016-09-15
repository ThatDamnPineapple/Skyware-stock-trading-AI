using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class GNPC : GlobalNPC
    {
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            NInfo info = npc.GetModInfo<NInfo>(mod);
            if (info.fireStacks > 0)
            {
                if (npc.HasBuff(mod.BuffType("StackingFireBuff")) < 0)
                {
                    info.fireStacks = 0;
                    return;
                }

                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= 16;
                damage = info.fireStacks * 5;
            }
        }
		public override void NPCLoot(NPC npc)
		{
			if (npc.type == 113)
			{
				if (Main.rand.Next(200) <= 25)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThrowerEmblem"));
				}
			}
		}
    }
}
