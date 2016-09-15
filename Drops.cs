using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod
{
    class Drops : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.DesertBeast)
            {
                if (Main.rand.Next(Main.expertMode ? 10 : 20) == 0)
                {
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BasiliskHorn"));
                }
            }
            else if (npc.type == NPCID.ElfCopter)
            {
                if (Main.rand.Next(Main.expertMode ? 50 : 100) < 3)
                {
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CandyRotor"));
                }
            }

            if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneHoly && Main.rand.Next(100) == 0)
            {
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Mystic"), 1);
            }
            if (Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].ZoneJungle && Main.rand.Next(100) == 0)
            {
                if (NPC.downedPlantBoss)
                {
                    if (npc.type == NPCID.Bee)
                    {

                    }
                    else
                    {
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Chaparral"), 1);
                    }
                }
                return;
            }
            {
                if (npc.type == NPCID.QueenBee)
                {
                    if (Main.rand.Next(Main.expertMode ? 10 : 20) == 0)
                    {
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SweetThrow"));
                    }
                }
            }
            {
                if (npc.type == mod.GetNPC("DiseasedSlime").npc.type || npc.type == mod.GetNPC("DiseasedBat").npc.type)
                {
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BismiteCrystal"), Main.rand.Next(3) + 2);
                }
            }
            {
                {
                    if (npc.type == mod.GetNPC("JeweledSlime").npc.type || npc.type == mod.GetNPC("JeweledBat").npc.type)
                    {
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Geode"), Main.rand.Next(1) + 2);
                    }
                }
            }
            {
                if (npc.type == mod.GetNPC("WanderingSoul").npc.type || npc.type == mod.GetNPC("GladiatorSpirit").npc.type)
                {
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ancient Rune"), 3 + Main.rand.Next(3));
                }
            }
        }
		
		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			if (type == NPCID.WitchDoctor)
			{
				if (NPC.downedPlantBoss)
				{
					shop.item[nextSlot].SetDefaults(mod.ItemType("TikiArrow"));
					nextSlot++;
				}
			}
		}
	}
}
	

