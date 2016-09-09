using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class CultistArcherBlue : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            if (npc.type == 379)
            {
                npc.townNPC = true;
                npc.lifeMax = 5000;
                npc.knockBackResist = 0f;
            }
        }
		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			if (player.GetModPlayer<MyPlayer>(mod).ZoneSpirit)
			{
				spawnRate = (int)(spawnRate * 0.6f);
				maxSpawns = (int)(maxSpawns * 1.5f);
			}
        }
        public override void GetChat(NPC npc, ref string chat)
        {
            if (npc.type == 379)
            {

                int wizard = NPC.FindFirstNPC(108);
                if (wizard >= 0 && Main.rand.Next(7) == 0)
                {
                    chat = " " + Main.npc[wizard].displayName + " used to be one of us. He's a dirty traitor.";
                    return;
                }
                switch (Main.rand.Next(6))
                {
                    case 0:
                        chat = "You aren't susposed to be here. Join us or face the consequenses";
                        return;
                    case 1:
                        chat = "This is sacred ground. Leave this place.";
                        return;
                    case 2:
                        chat = "Humanity was never meant to see this. That's why we're here.";
                        return;
                    case 3:
                        chat = "Look carefully, mortal. This thing's sheer gaze can drive you to insanity.";
                        return;
                    case 4:
                        chat = "This is the only path to forgiveness.";
                        return;
					case 5:
                        chat = "I see you resurrected the spirits. We are not happy about that.";
                        return;
                    default:
                        chat = "Hail the lunar lord, human!";
                        return;
                }
            }
        }
    }
}