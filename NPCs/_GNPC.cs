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
            #region Iriazul
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

            if (info.amberFracture)
            {
                if (npc.HasBuff(mod.BuffType("AmberFracture")) < 0)
                {
                    info.fireStacks = 0;
                    return;
                }

                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= 16;
                damage = 25;
            }
            #endregion
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

            #region Iriazul
            if (Main.hardMode && npc.lifeMax > 100)
            {
                if (Main.rand.Next(8) == 0)
                {
                    // Drop essence according to closest player location.
                    npc.TargetClosest(false);
                    Player closestPlayer = Main.player[npc.target];

                    if (closestPlayer.ZoneUndergroundDesert)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DuneEssence"));
                    else if (closestPlayer.ZoneSnow && closestPlayer.position.Y > WorldGen.worldSurfaceLow)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IcyEssence"));
                    else if (closestPlayer.ZoneJungle && closestPlayer.position.Y > WorldGen.worldSurfaceLow)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PrimevalEssence"));
                    else if (closestPlayer.position.X < 200 || closestPlayer.position.X > Main.mapMaxX - 200)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TidalEssence"));
                    else if (closestPlayer.position.Y > Main.mapMaxY - 200)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryEssence"));
                }
            }
            #endregion


            if (Main.rand.Next(40) == 0)
            {
                if (npc.type == NPCID.Paladin)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaladinHelm"));
                }
                if (npc.type == NPCID.Paladin)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaladinChestguard"));
                }
                if (npc.type == NPCID.Paladin)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaladinGreaves"));
                }
            }
            if (Main.bloodMoon)
            {
                if (Main.rand.Next(1) == 0)
                {
                    if (npc.type == NPCID.Clothier)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ZocklukasWings"));
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ZocklukasRing"));
                    }
                }

            }
            if (Main.rand.Next(98) == 0)
            {
                if (npc.type == NPCID.MartianTurret)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TeslaSpike"));
                }
                if (npc.type == NPCID.GigaZapper)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TeslaSpike"));
                }
            }
            if (Main.netMode == 1 || WorldGen.noTileActions || WorldGen.gen)
            {
                return;
            }
            if (npc.type == 134)
            {
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), mod.TileType("SpiritOreTile"), false, 0f, 0f, false, true);
                }
            }
            if (npc.type == 127)
            {
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), mod.TileType("SpiritOreTile"), false, 0f, 0f, false, true);
                }
            }
            if (npc.type == 125)
            {
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY), (double)WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(2, 4), mod.TileType("SpiritOreTile"), false, 0f, 0f, false, true);
                }
            }
            if (npc.type == 126)
            {
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY), (double)WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(2, 4), mod.TileType("SpiritOreTile"), false, 0f, 0f, false, true);
                }
            }
        }
    }
}
