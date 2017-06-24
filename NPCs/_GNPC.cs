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
		public override bool InstancePerEntity
		{
			get
			{
				return true;
			}
		}
        public int fireStacks;
        public int nebulaFlameStacks;
        public int GhostJellyStacks;
        public bool amberFracture;

        public bool felBrand = false;
        public bool soulBurn = false;
        public bool SoulFlare = false;
        public bool afflicted = false;
        public bool starDestiny = false;
        public bool Death = false;
        public bool pestilence = false;
        public bool moonBurn = false;
        public bool holyBurn = false;

        public bool DoomDestiny = false;

        public bool sFracture = false;
        public bool Etrap = false;
        public bool necrosis = false;
        public bool blaze = false;
        public bool blaze1 = false;


        public int titanicSetStacks;
        public int duneSetStacks;
        public int acidBurnStacks;
        private int[] martianMobs = new int[] { NPCID.MartianDrone, NPCID.MartianEngineer, NPCID.MartianOfficer, NPCID.MartianProbe, NPCID.MartianSaucer, NPCID.MartianTurret, NPCID.MartianWalker };
        public override void ResetEffects(NPC npc)
        {
		
            DoomDestiny = false;
            sFracture = false;
            Death = false;
            starDestiny = false;
            SoulFlare = false;
            afflicted = false;
            Etrap = false;
            soulBurn = false;
            necrosis = false;
            moonBurn = false;
            blaze = false;
            blaze1 = false;
            felBrand = false;
            holyBurn = false;
            pestilence = false;
        }
        public override bool PreAI(NPC npc)
        {
                Player player = Main.player[Main.myPlayer];
            Vector2 dist = npc.position - player.position;
            if (Main.netMode == 0)
            {
                if (player.GetModPlayer<MyPlayer>(mod).HellGaze == true && Math.Sqrt((dist.X * dist.X) + (dist.Y * dist.Y)) < 160 && Main.rand.Next(80) == 1 && !npc.friendly)
                {
                    npc.AddBuff(24, 130, false);
                }
            }
            if (Main.netMode == 0)
            {
                if (player.FindBuffIndex(mod.BuffType("FateBuff")) >= 0)
                {
                    if (!npc.boss)
                    {
                        npc.life = 0;
                        return false;
                    }
                }
            }
            return base.PreAI(npc);
        }

        public override void HitEffect(NPC npc, int hitDirection, double damage)
        {
            if (npc.type == NPCID.CultistBoss)
            {
                if (Main.netMode != 1 && npc.life < 0 && !NPC.AnyNPCs(mod.NPCType("Lunatic")))
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, mod.NPCType("Lunatic"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                }
            }
            if (npc.type == NPCID.MartianSaucer)
            {
                if (Main.netMode != 1 && npc.life < 0 && !NPC.AnyNPCs(mod.NPCType("Martian")))
                {
                    NPC.NewNPC((int)npc.Center.X, (int)npc.position.Y + npc.height, mod.NPCType("Martian"), npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                }
            }
        }
        public override void OnHitPlayer(NPC npc, Player target, int damage, bool crit)
        {
            if (npc.type == mod.NPCType("TideCaller"))
            {
                {
                    npc.lifeRegen += (int)Math.Sqrt(npc.lifeMax - npc.life) / 2 + 1;
                }
            }
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            {
                if (npc.type == mod.NPCType("Overseer"))
                {
                    if (projectile.type == 632)
                    {
                        damage /= 3;
                    }
                }
            }
        }
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            #region Iriazul
            if (fireStacks > 0)
            {
                if (npc.FindBuffIndex (mod.BuffType("StackingFireBuff")) < 0)
                {
                    fireStacks = 0;
                    return;
                }

                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= 16;
                damage = fireStacks * 5;
            }
            if (acidBurnStacks > 0)
            {
                if (npc.FindBuffIndex(mod.BuffType("AcidBurn")) < 0)
                {
                    acidBurnStacks = 0;
                    return;
                }

                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= 6;
                damage = fireStacks * 2;
            }
            if (nebulaFlameStacks > 0)
            {
                if (npc.FindBuffIndex (mod.BuffType("NebulaFlame")) < 0)
                {
                    nebulaFlameStacks = 0;
                    return;
                }

                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= 16;
                damage = fireStacks * 20;
            }
            if (amberFracture)
            {
                if (npc.FindBuffIndex (mod.BuffType("AmberFracture")) < 0)
                {
                    fireStacks = 0;
                    return;
                }

                if (npc.lifeRegen > 0)
                    npc.lifeRegen = 0;
                npc.lifeRegen -= 16;
                damage = 25;
            }
            #endregion

            if (DoomDestiny)
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
            if (starDestiny)
            {
                npc.lifeRegen = 0;
                npc.lifeRegen -= 150;
                damage = 75;
            }
            if (soulBurn)
            {
                npc.lifeRegen = 0;
                npc.lifeRegen -= 8;
                damage = 2;
            }
            if (afflicted)
            {
                npc.lifeRegen = 0;
                npc.lifeRegen -= 20;
                damage = 20;
            }
            if (Death)
            {
                npc.lifeRegen = 0;
                npc.lifeRegen -= 10000;
                damage = 10000;
            }
            if (SoulFlare)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 9;

            }
            if (felBrand)
            {
                npc.lifeRegen = 0;
                npc.lifeRegen -= 40;
                damage = 10;
            }
            if (moonBurn)
            {
                npc.lifeRegen = 0;
                npc.lifeRegen -= 8;
                damage = 6;
            }
            if (necrosis)
            {
                npc.lifeRegen = 0;
                npc.lifeRegen -= 30;
                damage = 10;
            }
            if (holyBurn)
            {
                npc.lifeRegen = 0;
                npc.lifeRegen -= 10;
                damage = 3;
            }
            if (pestilence)
            {
                npc.lifeRegen = 0;
                npc.lifeRegen -= 3;
                damage = 3;
            }
            if (blaze)
            {
                npc.lifeRegen = 0;
                npc.lifeRegen -= 4;
                damage = 2;
            }
            if (blaze1)
            {
                npc.lifeRegen = 0;
                npc.lifeRegen -= 20;
                damage = 2;
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
            if (type == NPCID.Steampunker)
            {
                    shop.item[nextSlot].SetDefaults(mod.ItemType("SpiritSolution"));
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(mod.ItemType("SoullessSolution"));
                    nextSlot++;
            }
       
            if (type == 17)
            {
                shop.item[nextSlot].SetDefaults(base.mod.ItemType("Copper"), false);
                nextSlot++;
            }
            if (type == 20)
            {
                shop.item[nextSlot].SetDefaults(base.mod.ItemType("Dryad"), false);
                nextSlot++;
            }
            if (type == 178)
            {
                shop.item[nextSlot].SetDefaults(base.mod.ItemType("Cog"), false);
                nextSlot++;
            }
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (InvasionWorld.invasionType == SpiritMod.customEvent)
            {
                spawnRate = (int)(spawnRate * 0.09f);
                maxSpawns = (int)(maxSpawns * 3f);
            }
        }
      /*  public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (player.GetModPlayer<MyPlayer>(mod).ZoneReach && !(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust))
                {
                    pool.Add(mod.NPCType("Reachman"), 4f);
                }
                else if (player.GetModPlayer<MyPlayer>(mod).ZoneReach && !(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust || !Main.dayTime))
                {
                    pool.Add(mod.NPCType("GroveCaster"), 0.6f);
                    pool.Add(mod.NPCType("GrassVine"), 1.8f);
                    pool.Add(mod.NPCType("ReachObserver"), 2f);
                }
                else if (player.GetModPlayer<MyPlayer>(mod).ZoneReach && !(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust || NPC.downedBoss2 || !Main.dayTime ))
                {
                    pool.Add(mod.NPCType("Mycoid"), 0.4f);
                }
            }
        }
        */
        public override void NPCLoot(NPC npc)
        {
            #region Artifact
            {
                
                if (Main.rand.Next(20) == 1 && !npc.SpawnedFromStatue)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PrimordialMagic"));
                }
                if (npc.type == mod.NPCType("Reachman") || npc.type == mod.NPCType("ReachObserver") || npc.type == mod.NPCType("GrassVine") || npc.type == mod.NPCType("ReachShaman"))
                {
                    if (Main.rand.Next(Main.expertMode ? 140 : 190) < 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RootPod"));
                    }
                    if (Main.hardMode && Main.rand.Next(Main.expertMode ? 250 : 350) < 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RootPod"));
                    }
                    if (NPC.downedMechBossAny && Main.rand.Next(Main.expertMode ? 300 : 350) < 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RootPod"));
                    }
                }
                if (npc.type == mod.NPCType("Scarabeus"))
                {
                    if (Main.rand.Next(Main.expertMode ? 90 : 100) < 8)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GildedIdol"));
                    }
                }
                if (npc.type == NPCID.EyeofCthulhu)
                {
                    if (Main.rand.Next(Main.expertMode ? 90 : 100) < 8)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DemonLens"));
                    }
                }
                if (npc.type == NPCID.IceSlime || npc.type == NPCID.IceBat || npc.type == NPCID.UndeadViking)
                {
                    if (Main.rand.Next(Main.expertMode ? 200 : 250) < 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostLotus"));
                    }
                }
                if (npc.type == NPCID.GoblinSorcerer)
                {
                    if (Main.rand.Next(Main.expertMode ? 100 : 150) < 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosEmber"));
                    }
                }
                if (npc.type == NPCID.Tim)
                {
                    if (Main.rand.Next(Main.expertMode ? 100 : 150) < 8)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosEmber"));
                    }
                }
                if (npc.type == NPCID.FireImp || npc.type == NPCID.Demon)
                {
                    if (Main.rand.Next(Main.expertMode ? 175 : 225) < 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FireLamp"));
                    }
                }
                if (npc.type == NPCID.AngryBones || npc.type == NPCID.AngryBonesBig || npc.type == NPCID.AngryBonesBigMuscle)
                {
                    if (Main.rand.Next(Main.expertMode ? 200 : 250) < 2)
                     {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NecroticSkull"));
                        }
                        if (Main.hardMode && Main.rand.Next(Main.expertMode ? 225 : 275) < 3)
                        {
                            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NecroticSkull"));
                        }
                }
                if (npc.type == mod.NPCType("Clamper") || npc.type == mod.NPCType("GreenFinTrapper") || npc.type == mod.NPCType("MindFlayer") || npc.type == mod.NPCType("MurkTerror"))
                {
                    if (Main.rand.Next(Main.expertMode ? 175 : 225) < 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TideStone"));
                    }
                    if (Main.hardMode && Main.rand.Next(Main.expertMode ? 225 : 275) < 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TideStone"));
                    }
                }
                if (npc.type == mod.NPCType("SteamRaiderHead"))
                {
                    if (Main.rand.Next(Main.expertMode ? 90 : 100) < 9)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StellarTech"));
                    }
                }
                if (npc.type == mod.NPCType("Infernon"))
                {
                    if (Main.rand.Next(Main.expertMode ? 90 : 100) < 8)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SearingBand"));
                    }
                }
                if (npc.type == mod.NPCType("Dusking"))
                {
                    if (Main.rand.Next(Main.expertMode ? 90 : 100) < 8)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DarkCrest"));
                    }
                }
                if (npc.type == NPCID.PirateCorsair || npc.type == NPCID.PirateDeadeye || npc.type == NPCID.PirateCrossbower)
                {
                    if (Main.rand.Next(Main.expertMode ? 175 : 225) < 3)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedMedallion"));
                    }
                    if (NPC.downedMechBoss1 && Main.rand.Next(Main.expertMode ? 150 : 200) < 2)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedMedallion"));
                    }
                }
                if (npc.type == NPCID.SkeletronPrime && NPC.downedMechBoss1 && NPC.downedMechBoss2)
                {
                    if (Main.rand.Next(Main.expertMode ? 95 : 105) < 8)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BatteryCore"));
                    }
                }
                if (npc.type == NPCID.Plantera)
                {
                    if (Main.rand.Next(Main.expertMode ? 95 : 105) < 8)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PlanteraBloom"));
                    }
                }
                if (npc.type == NPCID.Mothron && NPC.downedPlantBoss)
                {
                    if (Main.rand.Next(Main.expertMode ? 95 : 105) < 12)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ApexFeather"));
                    }
                }
                if (npc.type == mod.NPCType("IlluminantMaster"))
                {
                    if (Main.rand.Next(Main.expertMode ? 90 : 100) < 8)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RadiantEmblem"));
                    }
                }
                if (npc.type == mod.NPCType("Atlas"))
                {
                    if (Main.rand.Next(Main.expertMode ? 90 : 100) < 8)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("UnrefinedRuneStone"));
                    }
                }
            }
            #endregion
            if (npc.type == 140)
            {
            if (Main.rand.Next(100) <= 2)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowSword"));
            }
            if (Main.rand.Next(100) <= 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowAxe"));
                }
                    if (Main.rand.Next(100) <= 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowHammer"));
                }
                if (Main.rand.Next(100) <= 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowBody"));
                }
                if (Main.rand.Next(100) <= 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowHelmet"));
                }
                if (Main.rand.Next(100) <= 2)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowLeggings"));
                }

            }
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
            if (npc.type == 48 && Main.rand.Next(35) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarlightBow"));
            }
            if (npc.type == 48 && Main.rand.Next(35) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BreathOfTheZephyr"));
            }
            if (npc.type == 48 && Main.rand.Next(35) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("HarpyBlade"));
            }
            if (npc.type == 48 && Main.rand.Next(4) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Talon"), Main.rand.Next(2) + 2);
            }
            if (npc.type == 206 && Main.rand.Next(30) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemID.SnowGlobe);
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

                if (Main.rand.Next(200) >= 175)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BallOfFlesh"));
                }
            }
            if (npc.type == 120 && Main.rand.Next(50) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosCrystal"));
            }

                if (npc.type == 491 || npc.type == 216)
            {
                if (Main.rand.Next(50) <= 5)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CaptainsRegards"));
                }
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

            if (npc.type == NPCID.GoblinThief && Main.rand.Next(3) == 1)
            {
                int zzz = Main.rand.Next(3, 4);
                for (int H = 0; H < zzz; H++)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TechDrive"));
                }
            }
            if (npc.type == 409 && Main.rand.Next(40) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarlightStaff"));
            }
            if (npc.type == 39 && Main.rand.Next(16) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BoneFlail"));

            }
            if (npc.type == 199 && Main.rand.Next(500) == 1 || npc.type == 198 && Main.rand.Next(500) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SnakeStaff"));

            }
            if (npc.type == 477 && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && Main.rand.Next(5) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenStaff"));
            }
            if (npc.type == 477 && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && Main.rand.Next(5) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenParts"));
            }
            if (npc.type == 543 && Main.rand.Next(33) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Thresher"));
            }
            if (npc.type == 32 && Main.rand.Next(35) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DungeonStaff"));
            }
            if (npc.type == 269 && Main.rand.Next(100) == 1 || npc.type == 270 && Main.rand.Next(100) == 1 || npc.type == 271 && Main.rand.Next(100) == 1 || npc.type == 272 && Main.rand.Next(100) == 1 || npc.type == 273 && Main.rand.Next(100) == 1 || npc.type == 274 && Main.rand.Next(100) == 1 || npc.type == 275 && Main.rand.Next(100) == 1 || npc.type == 276 && Main.rand.Next(100) == 1 || npc.type == 277 && Main.rand.Next(100) == 1 || npc.type == 278 && Main.rand.Next(100) == 1 || npc.type == 279 && Main.rand.Next(100) == 1 || npc.type == 280 && Main.rand.Next(100) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Swordsplosion"));
            }
            if (npc.type == 544 && Main.rand.Next(33) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Cookiecutter"));
            }
            if (npc.type == NPCID.ZombieEskimo)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrigidFragment"));
            }
            if (npc.type == 545 && Main.rand.Next(33) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Mako"));
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
                if (Main.rand.Next(4) == 0)
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
            if (Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && npc.lifeMax > 99)
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

            #endregion//Vanilla NPCs

            if (npc.type == NPCID.ElfCopter)
            {
                if (Main.rand.Next(Main.expertMode ? 25 : 50) < 3)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CandyRotor"));
                }
            }
            if (npc.type == NPCID.QueenBee)
            {
                if (Main.rand.Next(Main.expertMode ? 10 : 20) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SweetThrow"));
                }
            }

            //Zone dependant
            if (closest.ZoneHoly)
            {
                if (Main.rand.Next(200) == 0)
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
            if (npc.type == NPCID.Zombie || npc.type == NPCID.BaldZombie || npc.type == NPCID.SlimedZombie || npc.type == NPCID.SwampZombie || npc.type == NPCID.TwiggyZombie || npc.type == NPCID.ZombieRaincoat || npc.type == NPCID.PincushionZombie)
            {
                if (Main.rand.Next(3) == 0)
                {
                    int amount = Main.rand.Next(1, 3);
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OldLeather"), amount);
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
                if (Main.rand.Next(50) == 0)
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
            if (npc.type == NPCID.BloodZombie)
            {
                if (Main.rand.Next(25) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BZombieArm"));
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
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Martian"));
                }
            }
            if (npc.type == 6)
            {
                if (Main.rand.Next(40) == 0)
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
                if (Main.rand.Next(40) == 0)
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
            if (npc.type == 290) //sroller
            {
                if (Main.rand.Next(25) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnchantedPaladinsHammerStaff"));
                }
            }
            if (npc.type == 268) //ichor pendant
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IchorPendant"));
                }
            }
            if (npc.type == 156) 
            {
                if (Main.rand.Next(40) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryPendant"));
                }
            }
            if (npc.type == 260 || npc.type == 257)
            {
                if (Main.rand.Next(25) == 0)
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
            if (npc.type == 62 && NPC.downedBoss3)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CarvedRock"), Main.rand.Next(1) + 2);
                }
            }
            if (npc.type == 31) //ichor pendant
            {
                if (Main.rand.Next(45) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlazingWheel"));
                }
            }
            if (npc.type == 170 || npc.type == 171 || npc.type == 180) 
            {
                if (Main.rand.Next(25) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PigronStaff"));
                }
            }
            if (npc.type == 113)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FamineScepter"));
                }
            }
            if (npc.type == 113)
            {
                if (Main.rand.Next(4) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThrowerEmblem"));
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
            if (npc.type == NPCID.EaterofSouls)
            {
                if (Main.rand.Next(28) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EaterStaff"), 1);
                }
            }
            if (npc.type == NPCID.FaceMonster)
            {
                if (Main.rand.Next(28) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CreeperStaff"), 1);
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
            if (npc.type == mod.NPCType("Scarabeus") && Main.rand.Next(5) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ScarabMask"), 1);
            }
            if (npc.type == mod.NPCType("AncientFlyer") && Main.rand.Next(5) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FlierMask"), 1);
            }
            if (npc.type == mod.NPCType("SteamRaiderHead") && Main.rand.Next(5) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarplateMask"), 1);
            }
            if (npc.type == mod.NPCType("Infernon") && Main.rand.Next(5) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("InfernonMask"), 1);
            }
            if (npc.type == mod.NPCType("Dusking") && Main.rand.Next(5) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DuskingMask"), 1);
            }
            if (npc.type == mod.NPCType("IlluminantMaster") && Main.rand.Next(5) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IlluminantMask"), 1);
            }
            if (npc.type == mod.NPCType("Atlas") && Main.rand.Next(5) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AtlasMask"), 1);
            }
            if (npc.type == mod.NPCType("Overseer") && Main.rand.Next(5) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OverseerMask"), 1);
            }
            // Donator Items

            //Folv
            if (npc.type == mod.NPCType("Scarabeus") || npc.type == mod.NPCType("AncientFlyer") || npc.type == mod.NPCType("Atlas"))
            {
                if (Main.rand.Next(10) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FolvBlade1"), 1);
                }
            }
            if (npc.type == mod.NPCType("Infernon") || npc.type == mod.NPCType("Dusking"))
            {
                if (Main.rand.Next(8) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Whetstone"), 1);
                }
            }
            if (npc.type == mod.NPCType("IlluminantMaster"))
            {
                if (Main.rand.Next(2) == 1)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Enchantment"), 1);
                }
            }
            if (npc.type == mod.NPCType("Overseer"))
            {
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Hilt"), 1);
                }
            }
            //End Folv

            if (npc.type == 156)
            {
                if (Main.rand.Next(80) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CombatShotgun"));
                }
            }

            // WORLD METHODS.
            if (Main.netMode == 1 || WorldGen.noTileActions || WorldGen.gen)
            {
                return;
            }

            
        }

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (sFracture)
            {
                if (Main.rand.Next(2) == 0) Dust.NewDust(npc.position, npc.width, npc.height, 133, (float)(Main.rand.Next(8) - 4), (float)(Main.rand.Next(8) - 4), 133);
            }
            if (felBrand)
            {
                if (Main.rand.Next(2) == 0) Dust.NewDust(npc.position, npc.width, npc.height, 75, (float)(Main.rand.Next(8) - 4), (float)(Main.rand.Next(8) - 4), 75);
            }
        }
    }
}
