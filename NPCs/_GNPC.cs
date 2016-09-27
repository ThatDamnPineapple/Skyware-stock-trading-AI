using System;
using System.Linq;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace SpiritMod.NPCs
{
    public class GNPC : GlobalNPC
    {
        private int[] martianMobs = new int[] { NPCID.MartianDrone, NPCID.MartianEngineer, NPCID.MartianOfficer, NPCID.MartianProbe, NPCID.MartianSaucer, NPCID.MartianTurret, NPCID.MartianWalker };

        public override void ResetEffects(NPC npc)
        {
            NInfo data = npc.GetModInfo<NInfo>(mod);
            data.DoomDestiny = false;
            data.sFracture = false;
            if (npc.HasBuff(Buffs.TikiInfestation._ref.Type) < 0)
            {
                data.TikiStacks = 0;
                data.TikiSlot = 0;
            }
        }

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
            if(info.nebulaFlameStacks > 0)
            {
                if (npc.HasBuff(mod.BuffType("NebulaFlame")) < 0)
                {
                    info.nebulaFlameStacks = 0;
                    return;
                }

                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= 16;
                damage = info.fireStacks * 20;
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

            if (info.DoomDestiny)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 16;
                if (damage < 10)
                {
                    damage = 10;
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

        public override bool PreNPCLoot(NPC npc)
        {
            NInfo data = npc.GetModInfo<NInfo>(mod);
            if (npc.HasBuff(Buffs.TikiInfestation._ref.Type) >= 0)
            {
                Vector2 pos = npc.Center;
                for (int i = data.TikiStacks - 1; i >= 0; i--)
                {
                    //Spawn Tiki Spirits
                    TikiData source = data.TikiSources[i];
                    Projectile.NewProjectile(pos.X, pos.Y, 0f, 0f, Projectiles.Arrow.TikiBiter._ref.projectile.type, source.wasSpirit ? source.damage : (int)(source.damage * 0.75f), 0f, source.owner, -1f);
                }
            }
            return true;
        }

        public override void NPCLoot(NPC npc)
        {
            NInfo data = npc.GetModInfo<NInfo>(mod);
            Player closest = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];

            if (npc.type == NPCID.WallofFlesh)
            {
                if (Main.rand.Next(200) <= 25)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThrowerEmblem"));
                }
            }
			 if (npc.type == 491 || npc.type == 216)
            {
                if (Main.rand.Next(100) <= 5)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CaptainsRegards"));
                }
				if (Main.rand.Next(100) <= 6)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PirateCrate"));
                }
            }
			 if (npc.type == 398)
            {
                int Relics = Main.rand.Next(3,6);
				for (int H = 0; H < Relics; H++)
				{
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AccursedRelic"));
				}
            }

            #region Iriazul

            // Bubble Shield dropping.
            if(martianMobs.Contains(npc.type))
            {
                if(Main.rand.Next(100) <= 2)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BubbleShield"));
            }

            // Essence Dropping
            if (Main.hardMode && npc.lifeMax > 100)
            {
                if (Main.rand.Next(8) == 0)
                {
                    // Drop essence according to closest player location.
                    if (closest.ZoneUndergroundDesert)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DuneEssence"));
                    else if (closest.ZoneSnow && closest.position.Y > WorldGen.worldSurfaceLow)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IcyEssence"));
                    else if (closest.ZoneJungle && closest.position.Y > WorldGen.worldSurfaceLow)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PrimevalEssence"));
                    else if (closest.position.X < 200 || closest.position.X > Main.mapMaxX - 200)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TidalEssence"));
                    else if (closest.position.Y > Main.mapMaxY - 200)
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryEssence"));
                }
            }

            // Tundra Trident Dropping
            if(npc.type == NPCID.IceQueen)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TundraTrident"), Main.rand.Next(30, 61));
            else if(npc.type == NPCID.Flocko && Main.rand.Next(10) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TundraTrident"), Main.rand.Next(10, 21));
            #endregion//Vanilla NPCs

            if (npc.type == NPCID.Plantera)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThornbloomKnife"), Main.rand.Next(40, 60));
            }
            else if (npc.type == NPCID.DesertBeast)
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
            else if (npc.type == NPCID.QueenBee)
            {
                if (Main.rand.Next(Main.expertMode ? 10 : 20) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SweetThrow"));
                }
            }

            //Zone dependant
            if (closest.ZoneHoly)
            {
                if (Main.rand.Next(100) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Mystic"), 1);
                }
            }
            if (closest.ZoneJungle)
            {
                if (NPC.downedPlantBoss && Main.rand.Next(100) == 0)
                {
                    if (npc.type != NPCID.Bee)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Chaparral"), 1);
                    }
                }
            }

            if (npc.type == NPCID.Paladin)
            {
                if (Main.rand.Next(40) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaladinHelm"));
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaladinChestguard"));
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PaladinGreaves"));
                }
            }
            if (npc.type == NPCID.Zombie)
            {
                if (Main.rand.NextFloat() < 0.07F)
                {
                    int amount = Main.rand.Next(1, 3);
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OldLeather"), amount);
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
            if (npc.type == NPCID.MartianTurret || npc.type == NPCID.GigaZapper)
            {
                if (Main.rand.Next(98) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TeslaSpike"));
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TeslaSpike"));
                }
            }


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

            if (npc.type == mod.NPCType("DiseasedSlime") || npc.type == mod.NPCType("DiseasedBat"))
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BismiteCrystal"), Main.rand.Next(3) + 2);
            }
            if (npc.type == mod.NPCType("JeweledSlime") || npc.type == mod.NPCType("JeweledBat"))
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Geode"), Main.rand.Next(1) + 2);
            }
            if (npc.type == mod.NPCType("WanderingSoul") || npc.type == mod.NPCType("GladiatorSpirit"))
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ancient Rune"), 3 + Main.rand.Next(3));
            }

            // WORLDGEN NPCLOOT METHODS.
            if (Main.netMode == 1 || WorldGen.noTileActions || WorldGen.gen)
            {
                return;
            }

            if (npc.type == NPCID.SkeletronPrime || npc.type == NPCID.TheDestroyer ||
                (npc.type == NPCID.Spazmatism && !NPC.AnyNPCs(NPCID.Retinazer)) || (npc.type == NPCID.Retinazer && !NPC.AnyNPCs(NPCID.Spazmatism)))
            {
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY), (double)WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(2, 4), mod.TileType("SpiritOreTile"), false, 0f, 0f, false, true);
                }
            }
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            NInfo data = npc.GetModInfo<NInfo>(mod);
            if (data.sFracture)
            {
                if (Main.rand.Next(2) == 0) Dust.NewDust(npc.position, npc.width, npc.height, 133, (float)(Main.rand.Next(8) - 4), (float)(Main.rand.Next(8) - 4), 133);
            }
        }
    }
}
