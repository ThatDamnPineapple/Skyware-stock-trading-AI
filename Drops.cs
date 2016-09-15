using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod
{
    class Drops : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
			if (npc.type == NPCID.ZombieEskimo)
                {
                    if (Main.rand.Next(8) == 1)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Snowflake"), 1);
                    }
                } 

                if (npc.type == NPCID.GoblinSorcerer && Main.hardMode)
                {
                    if (Main.rand.Next(10) == 1)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameStaff"), 1);
                    }
                    if (Main.rand.Next(15) == 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameBook"), 1);
                    }
                }
                
                //Gen for Magicite ore :P
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    Main.NewText("A Magic Aura spreads through the land", 219, 68, 227);
                    for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                    {
                        WorldGen.OreRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), (ushort)mod.TileType("MagiciteOre"));
                    }
                }
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
	

