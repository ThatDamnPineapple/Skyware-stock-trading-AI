using System;
using System;
using System.Linq;
using System.Collections.Generic;
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
            data.SoulFlare = false;
            data.Etrap = false;
            if (npc.FindBuffIndex (Buffs.TikiInfestation._ref.Type) < 0)
            {
                data.TikiStacks = 0;
                data.TikiSlot = 0;
            }
            data.felBrand = false;
        }
        public override bool PreAI(NPC npc)
        {
            NInfo info = npc.GetModInfo<NInfo>(mod);
            if (info.SoulFlare && Main.rand.Next(4) == 1)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 187);
            }
                Player player = Main.player[Main.myPlayer];
            Vector2 dist = npc.position - player.position;
            if (Main.netMode == 0)
            {
                if (player.GetModPlayer<MyPlayer>(mod).HellGaze == true && Math.Sqrt((dist.X * dist.X) + (dist.Y * dist.Y)) < 160 && Main.rand.Next(80) == 1 && !npc.friendly)
                {
                    npc.AddBuff(24, 130, false);
                }
            }
            return base.PreAI(npc);
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            #region Iriazul
            NInfo info = npc.GetModInfo<NInfo>(mod);
            if (info.fireStacks > 0)
            {
                if (npc.FindBuffIndex (mod.BuffType("StackingFireBuff")) < 0)
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
                if (npc.FindBuffIndex (mod.BuffType("NebulaFlame")) < 0)
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
                if (npc.FindBuffIndex (mod.BuffType("AmberFracture")) < 0)
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
            if (info.SoulFlare)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 9;

            }
            if (info.felBrand)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 10;
                if (damage < 10)
                {
                    damage = 8;
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
            if (type == 178)
            {
                    shop.item[nextSlot].SetDefaults(mod.ItemType("SpiritSolution"));
                    nextSlot++;
            }
        }

        public override bool PreNPCLoot(NPC npc)
        {
            NInfo data = npc.GetModInfo<NInfo>(mod);
            if (npc.FindBuffIndex (Buffs.TikiInfestation._ref.Type) >= 0)
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
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            for (int k = 0; k < 255; k++)
            {
                //THANKS MY HOMEBOY HARAMBE (and divermansam)
                Player player = Main.player[k];
                if (player.GetModPlayer<MyPlayer>(mod).ZoneSpirit && !(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust))
                {
                    pool.Clear(); //remove ALL spawns here
                    pool.Add(mod.NPCType("WanderingSoul"), 1f); // a modded enemy
                    pool.Add(mod.NPCType("UnstableWisp"), 1f); // a modded enemy
                    pool.Add(mod.NPCType("SpiritSkull"), 1f); // a modded enemy
                    pool.Add(mod.NPCType("SoulOrb"), 0.1f); // a modded enemy
                    pool.Add(mod.NPCType("NetherBane"), 0.05f); // a modded enemy
                    pool.Add(mod.NPCType("Hedron"), 1f); // a modded enemy
                }
                return;
            }
        }
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == 140)
            {
                if (Main.rand.Next(100) <= 8)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowSword"));
                }
                if (Main.rand.Next(100) <= 8)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowAxe"));
                }
                    if (Main.rand.Next(100) <= 8)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowHammer"));
                }
                if (Main.rand.Next(100) <= 8)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowBody"));
                }
                if (Main.rand.Next(100) <= 8)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowHelmet"));
                }
                if (Main.rand.Next(100) <= 8)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowLeggings"));
                }

            }
            NInfo data = npc.GetModInfo<NInfo>(mod);
            Player closest = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];

            if (npc.type == NPCID.CultistBoss)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StardustEmblem"));
                }
                else if (Main.rand.Next(3) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VortexEmblem"));
                }
                else if (Main.rand.Next(3) == 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SolarEmblem"));
                }
                else if (Main.rand.Next(4) == 3)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NebulaEmblem"));
                }
            }
            if (npc.type == 48 && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarlightBow"));
            }
            if (npc.type == 48 && Main.rand.Next(20) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BreathOfTheZephyr"));
            }
            if (npc.type == 127)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PrintPrime"), Main.rand.Next(2) + 1);
            }
            if (npc.type == 125 || npc.type == 126)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlueprintTwins"), Main.rand.Next(2) + 1);
            }
            if (npc.type == 134)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PrintProbe"), Main.rand.Next(2) + 1);
            }
            if (npc.type == NPCID.WallofFlesh)
            {

                if (Main.rand.Next(200) <= 25)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThrowerEmblem"));
                }
                if (Main.rand.Next(200) >= 175)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BallOfFlesh"));
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
                if (Main.rand.Next(100) <= 6)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulSiphon"));
                }
            }
            if (npc.type == 398)
            {
                int Relics = Main.rand.Next(3, 6);
                for (int H = 0; H < Relics; H++)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AccursedRelic"));
                }
            }
            if (npc.type == 409 && Main.rand.Next(40) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarlightStaff"));
            }
            if (npc.type == 425 && Main.rand.Next(40) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StormPhaser"));
            }
            if (npc.type == 426 && Main.rand.Next(40) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DistortionSting"));
            }
            #region Iriazul

            // Bubble Shield dropping.
            if (martianMobs.Contains(npc.type))
            {
                if (Main.rand.Next(100) <= 2)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BubbleShield"));
            }

            // Essence Dropping
            if (Main.hardMode && npc.FindBuffIndex(mod.BuffType("EssenceTrap")) > -1 && npc.lifeMax > 99)
            {
                if (Main.rand.Next(8) == 0)
                {
                    // Drop essence according to closest player location.
                    if (closest.ZoneUndergroundDesert)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DuneEssence"));
                    }
                    if (closest.ZoneSnow && closest.position.Y > WorldGen.worldSurfaceLow)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IcyEssence"));
                    }
                    if (closest.ZoneJungle && closest.position.Y > WorldGen.worldSurfaceLow)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PrimevalEssence"));
                    }
                    if (closest.ZoneBeach)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TidalEssence"));
                    }
                    if (closest.ZoneUnderworldHeight)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryEssence"));
                    }
                }
            }

            // Tundra Trident Dropping
            if (npc.type == NPCID.IceQueen)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TundraTrident"), Main.rand.Next(30, 61));
            else if (npc.type == NPCID.Flocko && Main.rand.Next(10) == 0)
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TundraTrident"), Main.rand.Next(10, 21));
            #endregion//Vanilla NPCs

            if (npc.type == NPCID.Plantera)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThornbloomKnife"), Main.rand.Next(40, 60));
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
            if (npc.type == NPCID.Zombie || npc.type == NPCID.BaldZombie || npc.type == NPCID.SlimedZombie || npc.type == NPCID.SwampZombie || npc.type == NPCID.TwiggyZombie || npc.type == NPCID.ZombieRaincoat || npc.type == NPCID.PincushionZombie)
            {
                if (Main.rand.Next(3) == 0)
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
                }
            }
            if (npc.type == NPCID.SolarDrakomire || npc.type == NPCID.SolarDrakomireRider)
            {
                if (Main.rand.Next(25) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SolarRattle"));
                }
            }
            if (npc.type == 385 || npc.type == 382 || npc.type == 381)
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EngineeringRod"));
                }
            }
            if (npc.type == NPCID.EyeofCthulhu)
            {
                if (Main.rand.Next(5) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Eyeshot"));
                }
            }
            if (npc.type == 508)
            {
                if (Main.rand.Next(60) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AntlionClaws"));
                }
            }
            if (npc.type == 392)
            {
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Martian"));
                }
            }
            if (npc.type == 6)
            {
                if (Main.rand.Next(20) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PMicrobe"));
                }
            }
            if (npc.type == 439)
            {
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ancient"));
                }
            }
            if (npc.type == 417) //sroller
            {
                if (Main.rand.Next(35) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Srollerang"));
                }
            }
            if (npc.type == 166) //sroller
            {
                if (Main.rand.Next(28) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Murk"));
                }
            }
            if (npc.type == 268) //ichor pendant
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IchorPendant"));
                }
            }
            if (npc.type == 260 || npc.type == 257) //ichor pendant
            {
                if (Main.rand.Next(20) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Fungus"));
                }
            }
            if (npc.type == 370) //ichor pendant
            {
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Typhoon"));
                }
            }
            if (npc.type == 31) //ichor pendant
            {
                if (Main.rand.Next(25) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlazingWheel"));
                }
            }
            if (npc.type == 170 || npc.type == 171 || npc.type == 180) 
            {
                if (Main.rand.Next(22) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PigronStaff"));
                }
            }
            if (npc.type == 113)
            {
                if (Main.rand.Next(1) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FamineScepter"));
                }
            }
            if (npc.type == 24)
            {
                if (Main.rand.Next(18) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TheFireball"));
                }
            }
            if (npc.type == 101) //cursed pendant
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedPendant"));
                }
            }
            if (npc.type == 29) //cursed pendant
            {
                if (Main.rand.Next(20) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosBall"));
                }
            }
            if (npc.type == NPCID.DemonEye || npc.type == NPCID.DemonEye2 || npc.type == NPCID.DemonEyeOwl || npc.type == NPCID.DemonEyeSpaceship)
            {
                if (Main.rand.Next(20) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagnifyingGlass"), 1);
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
            if (npc.type == mod.NPCType("WanderingSoul"))
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ancient Rune"), 3 + Main.rand.Next(3));
            }

            // WORLD METHODS.
            if (Main.netMode == 1 || WorldGen.noTileActions || WorldGen.gen)
            {
                return;
            }

            
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            NInfo data = npc.GetModInfo<NInfo>(mod);
            if (data.sFracture)
            {
                if (Main.rand.Next(2) == 0) Dust.NewDust(npc.position, npc.width, npc.height, 133, (float)(Main.rand.Next(8) - 4), (float)(Main.rand.Next(8) - 4), 133);
            }
            if (data.felBrand)
            {
                if (Main.rand.Next(2) == 0) Dust.NewDust(npc.position, npc.width, npc.height, 75, (float)(Main.rand.Next(8) - 4), (float)(Main.rand.Next(8) - 4), 75);
            }
        }
    }
}
