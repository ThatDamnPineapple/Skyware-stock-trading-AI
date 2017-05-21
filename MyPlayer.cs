using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Graphics.Shaders;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

using SpiritMod.NPCs;
using SpiritMod.Mounts;

namespace SpiritMod
{
    public class MyPlayer : ModPlayer
    {
        public bool SoulStone = false;
        public bool geodeSet = false;
        public bool ToxicExtract = false;
        public bool cultistScarf = false;
        public bool fateToken = false;
        public bool Fierysoul = false;
        public bool shamanBand = false;
        public bool ChaosCrystal = false;
        public bool HellGaze = false;
        public bool hungryMinion = false;
        public bool EaterSummon = false;
        public bool CreeperSummon = false;
        public bool CrystalShield = false;
        public bool moonHeart = false;
        public bool babyClampers = false;
        public bool Phantom = false;
        public bool onGround = false;
        public bool moving = false;
        public bool flying = false;
        public bool gremlinTooth = false;
        public bool BlueDust = false;
        public bool swimming = false;

        public bool copterBrake = false;
        public bool copterFiring = false;
        public int copterFireFrame = 1000;

        public int beetleStacks = 1;
        public int shootDelay = 0;

        public bool unboundSoulMinion = false;
        public bool cragboundMinion = false;
        public bool crawlerockMinion = false;
        public bool pigronMinion = false;
        
        public bool cthulhuMinion = false;

        public double pressedSpecial;

        float DistYT = 0f;
        float DistXT = 0f;
        float DistY = 0f;
        float DistX = 0f;
        public Entity LastEnemyHit = null;
        public bool TiteRing = false;
        public bool NebulaPearl = false;
        public bool CursedPendant = false;
        public bool IchorPendant = false;
        public bool KingRock = false;
        public bool spiritNecklace = false;
        private bool loaded = false;
        public bool starMap = false;
        private const int saveVersion = 0;
        public bool minionName = false;
        public bool Ward = false;
        public static bool hasProjectile;
        public bool DoomDestiny = false;
        public int HitNumber;
        public bool ZoneSpirit = false;
        public bool ZoneReach = false;
        public int PutridHits = 0;
        public bool flametrail = false;
        public bool icytrail = false;
        public bool EnchantedPaladinsHammerMinion = false;
        public bool ProbeMinion = false;

        public int weaponAnimationCounter;
        public int hexBowAnimationFrame;
        public bool carnivorousPlantMinion = false;
        public bool skeletalonMinion = false;
        public bool babyClamper = false;
        public bool beetleMinion = false;
        public bool steamMinion = false;
        public bool aeonMinion = false;
        public bool lihzahrdMinion = false;
        public bool ReachSummon = false;
        public bool gasopodMinion = false;
        public bool OG = false;
        public bool Flayer = false;

        public int soulSiphon;

        // Armor set booleans.
        public bool duskSet;
        public bool runicSet;
        public bool icySet;
        public bool depthSet;
        public bool primalSet;
        public bool spiritSet;
        public bool putridSet;
        public bool illuminantSet;
        public bool duneSet;
        public bool acidSet;
        public bool leatherSet;
        public bool witherSet;
        public bool titanicSet;
        public bool reaperSet;
        public bool shadowSet;
        public bool oceanSet;
        public bool cometSet;
        public bool hellSet;
        public bool bloodfireSet;
        public bool reaperMask;
        public bool magicshadowSet;
        public bool rangedshadowSet;
        public bool meleeshadowSet;
        public bool infernalSet;
        public bool bloomwindSet;
        public bool fierySet;
        public bool starSet;
        public bool magalaSet;
        public bool veinstoneSet;
        public bool clatterboneSet;
        public bool ichorSet1;
        public bool ichorSet2;
        public bool talonSet;
        public bool OverseerCharm = false;
        public bool Bauble = false;
        // Accessory booleans.
        public bool OriRing;
        public bool SRingOn;
        public bool goldenApple;
        public bool hpRegenRing;
        public bool bubbleShield;
        public bool icySoul;
        public bool mythrilCharm;
        public bool infernalShield;
        public bool shadowGauntlet;
        public bool moonGauntlet;
        public bool starCharm;

        public int timeLeft = 0;
        int timer = 0;

        public int infernalHit;
        public int infernalDash;
        public int infernalSetCooldown;

        public int bubbleTimer;
        public int clatterboneTimer;
        public int baubleTimer;
        public int cometTimer;

        public bool concentrated; // For the leather armor set.
        public int concentratedCooldown;

        public bool basiliskMount;
        public bool drakomireMount;

        public int drakomireFlameTimer;

        public bool toxify;
        public bool acidImbue;
        public bool spiritBuff;
        public bool gremlinBuff;
        public override void UpdateBiomeVisuals()
        {
            bool useFire = NPC.AnyNPCs(mod.NPCType("Overseer"));
            player.ManageSpecialBiomeVisuals("SpiritMod:Overseer", useFire);
            bool useFire2 = NPC.AnyNPCs(mod.NPCType("IlluminantMaster"));
            player.ManageSpecialBiomeVisuals("SpiritMod:IlluminantMaster", useFire2);
            bool useRock = NPC.AnyNPCs(mod.NPCType("Atlas"));
            player.ManageSpecialBiomeVisuals("SpiritMod:Atlas", useRock);

        }
        public override void UpdateBiomes()
        {
            ZoneSpirit = ((MyWorld.SpiritTiles1 + MyWorld.SpiritTiles2 + MyWorld.SpiritTiles3 + MyWorld.SpiritTiles4) > 200);
            ZoneReach = (MyWorld.ReachTiles + MyWorld.ReachTiles1 + MyWorld.ReachTiles2 > 40);
        }
        public override bool CustomBiomesMatch(Player other)
        {
            MyPlayer modOther = other.GetModPlayer<MyPlayer>(mod);
            return ZoneSpirit == modOther.ZoneSpirit;
        }
        public override void CopyCustomBiomesTo(Player other)
        {
            MyPlayer modOther = other.GetModPlayer<MyPlayer>(mod);
            modOther.ZoneSpirit = ZoneSpirit;
            modOther.ZoneReach = ZoneReach;
        }
        public override void SendCustomBiomes(BinaryWriter writer)
        {
            byte flags = 0;
            if (ZoneSpirit)
            {
                flags |= 1;
            }
            if (ZoneReach)
            {
                flags |= 2;
            }
            writer.Write(flags);
        }
        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            byte flags = reader.ReadByte();
            ZoneSpirit = ((flags & 1) == 1);
            ZoneReach = ((flags & 1) == 1);
        }
        public override void ResetEffects()
        {
            ChaosCrystal = false;
            ToxicExtract = false;
            cultistScarf = false;
            moonHeart = false;
            Fierysoul = false;
            gremlinTooth = false;
            SoulStone = false;
            geodeSet = false;
            HellGaze = false;
            Bauble = false;

            OverseerCharm = false;
            hungryMinion = false;
            EaterSummon = false;
            CreeperSummon = false;
            CrystalShield = false;
            babyClamper = false;
            Phantom = false;
            IchorPendant = false;
            Ward = false;
            CursedPendant = false;
            BlueDust = false;
            starCharm = false;
            minionName = false;
            starMap = false;
            NebulaPearl = false;
            TiteRing = false;
            KingRock = false;
            cthulhuMinion = false;
            flametrail = false;
            icytrail = false;
            EnchantedPaladinsHammerMinion = false;
            ProbeMinion = false;
            crawlerockMinion = false;
            pigronMinion = false;
            skeletalonMinion = false;
            cragboundMinion = false;
            beetleMinion = false;
            shamanBand = false;
            lihzahrdMinion = false;
            aeonMinion = false;
            gasopodMinion = false;
            Flayer = false;
            steamMinion = false;
            OG = false;

            this.drakomireMount = false;
            this.basiliskMount = false;
            this.toxify = false;
            this.gremlinBuff = false;
            this.spiritBuff = false;
            this.carnivorousPlantMinion = false;

            // Reset armor set booleans.
            this.duskSet = false;
            this.runicSet = false;
            this.primalSet = false;
            this.shadowSet = false;
            this.cometSet = false;
            this.meleeshadowSet = false;
            this.rangedshadowSet = false;
            this.magicshadowSet = false;
            this.witherSet = false;
            this.hellSet = false;
            this.reaperSet = false;
            this.spiritSet = false;
            this.reaperMask = false;
            this.ichorSet1 = false;
            this.ichorSet2 = false;
            this.icySet = false;
            this.fierySet = false;
            this.putridSet = false;
            this.duneSet = false;
            this.leatherSet = false;
            this.starSet = false;
            this.bloodfireSet = false;
            this.oceanSet = false;
            this.titanicSet = false;
            this.illuminantSet = false;
            this.magalaSet = false;
            this.depthSet = false;
            this.acidSet = false;
            this.infernalSet = false;
            this.bloomwindSet = false;
            this.veinstoneSet = false;
            this.clatterboneSet = false;
            this.talonSet = false;

            // Reset accessory booleans.
            this.OriRing = false;
            this.SRingOn = false;
            this.goldenApple = false;
            this.hpRegenRing = false;
            this.bubbleShield = false;
            this.mythrilCharm = false;
            this.spiritNecklace = false;
            this.infernalShield = false;
            this.shadowGauntlet = false;
            this.moonGauntlet = false;

            unboundSoulMinion = false;

            if (player.FindBuffIndex(Buffs.BeetleFortitude._ref.Type) < 0)
            {
                beetleStacks = 1;
            }

            copterFireFrame++;

            onGround = false;
            moving = false;
            flying = false;
            swimming = false;

            if (player.velocity.Y != 0f)
            {
                if (player.mount.Active && player.mount.FlyTime > 0 && player.jump == 0 && player.controlJump && !player.mount.CanHover)
                {
                    flying = true;
                }
                else if (player.wet)
                {
                    swimming = true;
                }
            }
            else
            {
                onGround = true;
            }
            if (player.velocity.X != 0f)
            {
                moving = true;
            }
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (junk)
            {
                return;
            }
            if (player.GetModPlayer<MyPlayer>(mod).ZoneSpirit && NPC.downedMechBossAny && Main.rand.Next(6) == 0)
            {
                caughtType = mod.ItemType("SpiritCrate");
            }
            if (player.GetModPlayer<MyPlayer>(mod).ZoneSpirit && NPC.downedMechBossAny && Main.rand.Next(5) == 0)
            {
                caughtType = mod.ItemType("SpiritKoi");
            }
            //  if (player.gravDir == -1f && questFish == mod.ItemType("ExampleQuestFish") && Main.rand.Next(2) == 0)
            //  {
            //      caughtType = mod.ItemType("ExampleQuestFish");
            //  }
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (this.reaperMask)
            {
                if (SpiritMod.WraithKey.JustPressed)
                {
                    {
                        if (player.FindBuffIndex(ModLoader.GetMod("SpiritMod").BuffType("WraithCooldown")) < 0)
                        {

                            player.AddBuff(mod.BuffType("WraithCooldown"), 3600);
                            player.AddBuff(mod.BuffType("Wraith"), 300);

                        }
                    }
                }
            }
            if (this.cometSet)
            {
                if (SpiritMod.SpecialKey.JustPressed)
                {
                    {
                        if (player.FindBuffIndex(ModLoader.GetMod("SpiritMod").BuffType("StarCooldown")) < 0)
                        {

                            player.AddBuff(mod.BuffType("StarCooldown"), 3600);
                            Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("Star1"), 75, 0, player.whoAmI);
                            Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("Star2"), 75, 0, player.whoAmI);
                            Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("Star3"), 75, 0, player.whoAmI);
                            Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("Star4"), 75, 0, player.whoAmI);
                            Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("Star5"), 75, 0, player.whoAmI);
                            Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("Star6"), 75, 0, player.whoAmI);
                        }
                    }
                }
            }
            if (this.depthSet)
            {
                if (SpiritMod.DepthKey.JustPressed)
                {
                    {
                        if (player.FindBuffIndex(ModLoader.GetMod("SpiritMod").BuffType("SharkAttackBuff")) < 0)
                        {
                            MyPlayer gp = (MyPlayer)Main.player[Main.myPlayer].GetModPlayer(mod, "MyPlayer");
                            CombatText.NewText(new Rectangle((int)gp.player.position.X, (int)gp.player.position.Y - 60, gp.player.width, gp.player.height), new Color(29, 240, 255, 100),
                            "Shark Attack!");
                            player.AddBuff(mod.BuffType("SharkAttackBuff"), 2700);                            
                            
                                Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("SharkBlast"), 35, 0, player.whoAmI);
                            
                        }
                    }
                }
            }
            if (this.ichorSet1)
            {
                if (SpiritMod.GoreKey.JustPressed)
                {
                    {
                        if (player.FindBuffIndex(ModLoader.GetMod("SpiritMod").BuffType("GoreCooldown1")) < 0)
                        {

                            player.AddBuff(mod.BuffType("GoreCooldown1"), 3600);
                            Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("Gores"), 4, 0, player.whoAmI);
                        }
                    }
                }
            }
            if (this.ichorSet2)
            {
                if (SpiritMod.IchorKey.JustPressed)
                {
                    {
                        if (player.FindBuffIndex(ModLoader.GetMod("SpiritMod").BuffType("GoreCooldown2")) < 0)
                        {

                            player.AddBuff(mod.BuffType("GoreCooldown2"), 3600);
                            Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("Gore1"), 21, 0, player.whoAmI);
                            Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("Gore1"), 21, 0, player.whoAmI);
                            Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("Gore1"), 21, 0, player.whoAmI);
                        }
                    }
                }
            }
        }
        public override void OnHitAnything(float x, float y, Entity victim)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            if (modPlayer.TiteRing && modPlayer.LastEnemyHit == victim && Main.rand.Next(10) == 2)
            {
                player.AddBuff(59, 145);
            }
            if (modPlayer.hpRegenRing && modPlayer.LastEnemyHit == victim && Main.rand.Next(3) == 2)
            {
                player.AddBuff(58, 120);
            }
            if (modPlayer.OriRing && modPlayer.LastEnemyHit == victim && Main.rand.Next(10) == 2)
            {
                Vector2 mouse = new Vector2(victim.position.X, victim.position.Y);
                if (player.position.Y <= victim.position.Y)
                {
                    float Xdis = player.position.X - victim.position.X;  // change myplayer to nearest player in full version
                    float Ydis = player.position.Y - victim.position.Y; // change myplayer to nearest player in full version
                    float Angle = (float)Math.Atan(Xdis / Ydis);
                    DistXT = (float)(Math.Sin(Angle) * 300);
                    DistYT = (float)(Math.Cos(Angle) * 300);
                    DistX = (player.position.X + (0 - DistXT));
                    DistY = (player.position.Y + (0 - DistYT));
                }
                if (player.position.Y > victim.position.Y)
                {
                    float Xdis = player.position.X - victim.position.X;  // change myplayer to nearest player in full version
                    float Ydis = player.position.Y - victim.position.Y; // change myplayer to nearest player in full version
                    float Angle = (float)Math.Atan(Xdis / Ydis);
                    DistXT = (float)(Math.Sin(Angle) * 300);
                    DistYT = (float)(Math.Cos(Angle) * 300);
                    DistX = (player.position.X + DistXT);
                    DistY = (player.position.Y + DistYT);
                }
                Vector2 direction = victim.Center - player.Center;
                direction.Normalize();
                direction.X *= 20f;
                direction.Y *= 20f;

                float A = (float)Main.rand.Next(-100, 100) * 0.01f;
                float B = (float)Main.rand.Next(-100, 100) * 0.01f;
                // Projectile.NewProjectile(DistX, DistY, (0 - DistX) / 50, (0 - DistY) / 50, mod.ProjectileType("ManaStarProjectile"), damage, knockBack, player.whoAmI, 0f, 0f);
                //return false;
                Projectile.NewProjectile(DistX, DistY, direction.X + A, direction.Y + B, mod.ProjectileType("OriPetal"), 30, 1, player.whoAmI, 0f, 0f);
            }
            LastEnemyHit = victim;
            base.OnHitAnything(x, y, victim);
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (this.titanicSet && item.melee)
            {
                NInfo info = target.GetModInfo<NInfo>(mod);
                if (info.titanicSetStacks++ >= 4)
                {
                    Projectile newProj = Main.projectile[Projectile.NewProjectile(target.Center, Vector2.Zero, mod.ProjectileType("WaterMass"), 40, 2, player.whoAmI)];
                    newProj.timeLeft = 3;
                    newProj.netUpdate = true;

                    info.titanicSetStacks = 0;
                }
            }
            if (this.duneSet && item.thrown)
            {
                NInfo info = target.GetModInfo<NInfo>(mod);
                if (info.duneSetStacks++ >= 4)
                {
                    player.AddBuff(mod.BuffType("DesertWinds"), 180);

                    Projectile.NewProjectile(player.position.X + 20, player.position.Y, 0, -2, mod.ProjectileType("DuneKnife"), 40, 0, Main.myPlayer);

                    info.duneSetStacks = 0;
                }
            }
            if (this.icySet && item.magic && Main.rand.Next(14) == 2)
            {
                {
                    player.AddBuff(mod.BuffType("BlizzardWrath"), 240);
                }
            }

            if (this.meleeshadowSet && Main.rand.Next(10) == 2 && item.melee)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 12, mod.ProjectileType("SpiritShardFriendly"), 60, 0, Main.myPlayer);
            }
            if (this.magicshadowSet && Main.rand.Next(10) == 2 && item.magic)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 12, mod.ProjectileType("SpiritShardFriendly"), 60, 0, Main.myPlayer);
            }
            if (this.magicshadowSet && Main.rand.Next(10) == 2 && item.summon)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 12, mod.ProjectileType("SpiritShardFriendly"), 60, 0, Main.myPlayer);
            }
            if (this.rangedshadowSet && Main.rand.Next(10) == 2 && item.ranged)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 12, mod.ProjectileType("SpiritShardFriendly"), 60, 0, Main.myPlayer);
            }
            if (this.rangedshadowSet && Main.rand.Next(10) == 2 && item.thrown)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 12, mod.ProjectileType("SpiritShardFriendly"), 60, 0, Main.myPlayer);

            }
            if (this.spiritNecklace && Main.rand.Next(10) == 2 && item.melee)
            {
                target.AddBuff(mod.BuffType("EssenceTrap"), 240);
                damage = damage + (target.defense);

            }
            if (this.magalaSet && Main.rand.Next(6) == 2 && item.thrown)
            {
                target.AddBuff(mod.BuffType("FrenzyVirus"), 240);



            }
            if (this.magalaSet && Main.rand.Next(6) == 2 && item.melee)
            {
                target.AddBuff(mod.BuffType("FrenzyVirus"), 240);

            }
            if (this.magalaSet && Main.rand.Next(6) == 2 && item.magic)
            {
                target.AddBuff(mod.BuffType("FrenzyVirus"), 240);

            }
            if (this.magalaSet && Main.rand.Next(6) == 2 && item.ranged)
            {
                target.AddBuff(mod.BuffType("FrenzyVirus"), 240);

            }
            if (this.ToxicExtract && Main.rand.Next(5) == 1 && item.magic)
            {
                target.AddBuff(70, 240);
            }
            if (this.magalaSet && item.magic && Main.rand.Next(14) == 2)
            {
                {
                    player.AddBuff(mod.BuffType("FrenzyVirus1"), 240);
                }

            }

            if (this.magalaSet && item.ranged && Main.rand.Next(14) == 2)
            {
                {
                    player.AddBuff(mod.BuffType("FrenzyVirus1"), 240);
                }
            }
            if (this.magalaSet && item.melee && Main.rand.Next(14) == 2)
            {
                {
                    player.AddBuff(mod.BuffType("FrenzyVirus1"), 240);
                }
            }
            if (this.magalaSet && item.thrown && Main.rand.Next(14) == 2)
            {
                {
                    player.AddBuff(mod.BuffType("FrenzyVirus1"), 240);
                }
            }
            if (this.geodeSet && crit && Main.rand.Next(5) == 2)
            {
                target.AddBuff(BuffID.Frostburn, 180);
                target.AddBuff(BuffID.OnFire, 180);

            }
            if (this.gremlinBuff && item.melee)
            {
                {
                    target.AddBuff(BuffID.Poisoned, 120);
                }
            }
        }
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (this.KingRock && Main.rand.Next(5) == 2 && proj.magic)
            {
                Projectile.NewProjectile(player.position.X + Main.rand.Next(-350, 350), player.position.Y - 350, 0, 12, mod.ProjectileType("PrismaticBolt"), 55, 0, Main.myPlayer);
                Projectile.NewProjectile(player.position.X + Main.rand.Next(-350, 350), player.position.Y - 350, 0, 12, mod.ProjectileType("PrismaticBolt"), 55, 0, Main.myPlayer);
            }
            if (this.magalaSet && proj.thrown)
            {
                target.AddBuff(mod.BuffType("FrenzyVirus"), 180);

            }
            if (this.geodeSet && crit && Main.rand.Next(5) == 2)
            {
                target.AddBuff(BuffID.Frostburn, 180);
                target.AddBuff(BuffID.OnFire, 180);

            }
            if (this.shamanBand && proj.magic && Main.rand.Next(15) == 2)
            {
                target.AddBuff(BuffID.OnFire, 180);

            }
            if (this.bloodfireSet && proj.magic && Main.rand.Next(15) == 2)
            {
                target.AddBuff(mod.BuffType("BCorrupt"), 180);

            }
            if (this.bloodfireSet && proj.magic && Main.rand.Next(30) == 2)
            {
                player.statLife += 2;
                player.HealEffect(2);

            }
            if (this.magalaSet && proj.melee)
            {
                target.AddBuff(mod.BuffType("FrenzyVirus"), 180);

            }
            if (this.acidImbue && Main.rand.Next(11) == 1 && proj.thrown)
            {
                target.AddBuff(mod.BuffType("AcidBurn"), 240);

            }
            if (this.magalaSet && proj.minion)
            {
                target.AddBuff(mod.BuffType("FrenzyVirus"), 180);

            }
            if (this.magalaSet && proj.magic)
            {
                target.AddBuff(mod.BuffType("FrenzyVirus"), 180);

            }
            if (this.magalaSet && proj.ranged)
            {
                target.AddBuff(mod.BuffType("FrenzyVirus"), 180);


            }
            if (this.spiritNecklace && proj.thrown)
            {
                target.AddBuff(mod.BuffType("EssenceTrap"), 180);

            }
            if (this.gremlinBuff && proj.melee)
            {
                target.AddBuff(BuffID.Poisoned, 120);
            }
            if (this.gremlinBuff && proj.thrown)
            {
                target.AddBuff(BuffID.Poisoned, 120);
            }
            if (this.gremlinBuff && proj.minion)
            {
                target.AddBuff(BuffID.Poisoned, 120);
            }
            if (this.gremlinBuff && proj.magic)
            {
                target.AddBuff(BuffID.Poisoned, 120);
            }
            if (this.gremlinBuff && proj.ranged)
            {
                target.AddBuff(BuffID.Poisoned, 120);
            }
  
            if (this.Fierysoul && proj.minion  && Main.rand.Next(14) == 2)
            {
                {
                    target.AddBuff(BuffID.OnFire, 240);
                }

            }
            if (this.spiritNecklace && proj.melee)
            {
                target.AddBuff(mod.BuffType("EssenceTrap"), 180);
                damage = damage + (target.defense);
            }
            if (this.spiritNecklace && proj.minion)
            {
                target.AddBuff(mod.BuffType("EssenceTrap"), 180);

            }
            if (this.spiritNecklace && proj.magic)
            {
                target.AddBuff(mod.BuffType("EssenceTrap"), 180);

            }
            if (this.spiritNecklace && proj.ranged)
            {
                target.AddBuff(mod.BuffType("EssenceTrap"), 180);

            }
            if (this.magicshadowSet && Main.rand.Next(4) == 2 && proj.magic)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 12, mod.ProjectileType("SpiritShardFriendly"), 60, 0, Main.myPlayer);
            }
            if (this.magicshadowSet && Main.rand.Next(4) == 2 && proj.magic)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 12, mod.ProjectileType("SpiritShardFriendly"), 60, 0, Main.myPlayer);
            }
            if (this.ToxicExtract && Main.rand.Next(5) == 1 && proj.magic)
            {
                target.AddBuff(70, 240);
            }
            if (this.fierySet && Main.rand.Next(10) == 1 && proj.ranged)
            {
                target.AddBuff(24, 180);
            }

            if (this.fierySet && Main.rand.Next(10) == 1 && proj.thrown)
            {
                target.AddBuff(24, 180);
            }
            if (this.meleeshadowSet && Main.rand.Next(4) == 2 && proj.melee)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 12, mod.ProjectileType("SpiritShardFriendly"), 60, 0, Main.myPlayer);
            }
            if (this.meleeshadowSet && Main.rand.Next(4) == 2 && proj.melee)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 12, mod.ProjectileType("SpiritShardFriendly"), 60, 0, Main.myPlayer);
            }
            if (this.rangedshadowSet && Main.rand.Next(4) == 2 && proj.ranged)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 12, mod.ProjectileType("SpiritShardFriendly"), 60, 0, Main.myPlayer);
            }
            if (spiritBuff && Main.rand.Next(4) == 2 && proj.magic)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 4, 4, ProjectileID.SpectreWrath, 60, 0, Main.myPlayer);
            }
            if (this.rangedshadowSet && Main.rand.Next(4) == 2 && proj.thrown)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 12, mod.ProjectileType("SpiritShardFriendly"), 60, 0, Main.myPlayer);
            }
            if (this.NebulaPearl && Main.rand.Next(8) == 2 && proj.magic)
            {
                Item.NewItem((int)target.position.X, (int)target.position.Y, target.width, target.height, 3454);
            }
            if (this.hellSet && Main.rand.Next(8) == 2 && proj.ranged)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 0, mod.ProjectileType("FireExplosion"), 39, 0, Main.myPlayer);
            }

            if (this.duneSet && proj.thrown)
            {
                NInfo info = target.GetModInfo<NInfo>(mod);
                if (info.duneSetStacks++ >= 4)
                {
                    player.AddBuff(mod.BuffType("DesertWinds"), 180);

                    Projectile.NewProjectile(player.position.X + 20, player.position.Y, 0, - 2, mod.ProjectileType("DuneKnife"), 40, 0, Main.myPlayer);

                    info.duneSetStacks = 0;
                }
            }
            if (this.icySet && proj.magic && Main.rand.Next(14) == 2)
            {
                {
                    player.AddBuff(mod.BuffType("BlizzardWrath"), 240);
                }
            }
            if (this.magalaSet && proj.minion && Main.rand.Next(6) == 2)
            {
                {
                    player.AddBuff(mod.BuffType("FrenzyVirus1"), 240);
                }

            }
            if (this.magalaSet && proj.magic && Main.rand.Next(6) == 2)
            {
                {
                    player.AddBuff(mod.BuffType("FrenzyVirus1"), 240);
                }

            }
            if (this.magalaSet && proj.ranged && Main.rand.Next(6) == 2)
            {
                {
                    player.AddBuff(mod.BuffType("FrenzyVirus1"), 240);
                }
            }
            if (this.magalaSet && proj.melee && Main.rand.Next(6) == 2)
            {
                {
                    player.AddBuff(mod.BuffType("FrenzyVirus1"), 240);
                }
            }
            if (this.magalaSet && proj.thrown && Main.rand.Next(6) == 2)
            {
                {
                    player.AddBuff(mod.BuffType("FrenzyVirus1"), 240);
                }
            }
            if (this.titanicSet && proj.melee)
            {
                NInfo info = target.GetModInfo<NInfo>(mod);
                if (info.titanicSetStacks++ >= 4)
                {
                    Projectile.NewProjectile(player.position.X + 20, player.position.Y + 30, 0, 12, mod.ProjectileType("WaterMass"), 60, 0, Main.myPlayer);

                    info.titanicSetStacks = 0;
                }
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if (this.bubbleTimer > 0)
                return false;
            if (player.FindBuffIndex(mod.BuffType("Sturdy")) >= 0)
                return false;

            return true;
        }
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (SRingOn)
            {
                for (int h = 0; h < 3; h++)
                {
                    Vector2 vel = new Vector2(0, -1);
                    float rand = Main.rand.NextFloat() * 6.283f;
                    vel = vel.RotatedBy(rand);
                    vel *= 2f;
                    int proj = Projectile.NewProjectile(Main.player[Main.myPlayer].Center.X, Main.player[Main.myPlayer].Center.Y, vel.X, vel.Y, 297, 45, 0, Main.myPlayer);
                }
            }
            if (moonHeart)
            {
                int n = 5;
                int deviation = Main.rand.Next(0, 180);
                for (int i = 0; i < n; i++)
                {
                    Vector2 vel = new Vector2(0, -1);
                    float rand = Main.rand.NextFloat() * 10f;
                    vel = vel.RotatedBy(rand);
                    vel *= 5f;
                    int proj1 = Projectile.NewProjectile(Main.player[Main.myPlayer].Center.X, Main.player[Main.myPlayer].Center.Y, vel.X, vel.Y, mod.ProjectileType("AlienSpit"), 65, 0, Main.myPlayer);
                }
            }
            if (ChaosCrystal && Main.rand.Next(2) == 1)
            {
            bool canSpawn = false;
                int teleportStartX = (int)(Main.player[Main.myPlayer].position.X / 16) - 35;
            int teleportRangeX = 70;
                int teleportStartY = (int)(Main.player[Main.myPlayer].position.Y / 16) - 35;
                int teleportRangeY = 70;
                Vector2 vector2 = this.TestTeleport(ref canSpawn, teleportStartX, teleportRangeX, teleportStartY, teleportRangeY);
                if (canSpawn)
                {
                    Vector2 newPos = vector2;
                    Main.player[Main.myPlayer].Teleport(newPos, 2, 0);
                    Main.player[Main.myPlayer].velocity = Vector2.Zero;
                    if (Main.netMode == 2)
                    {
                        RemoteClient.CheckSection(Main.myPlayer, Main.player[Main.myPlayer].position, 1);
                        NetMessage.SendData(65, -1, -1, "", 0, (float)Main.myPlayer, newPos.X, newPos.Y, 3, 0, 0);
                    }
                }
        
    }

            // IRIAZUL
            if (this.veinstoneSet && Main.rand.Next(8) == 0)
            {
                int amount = Main.rand.Next(2, 5);
                for (int i = 0; i < amount; ++i)
                {
                    Vector2 position = new Vector2(player.position.X + player.width * 0.5f + Main.rand.Next(-200, 201), player.Center.Y - 600f);
                    position.X = (position.X * 10f + player.position.X) / 11f + (float)Main.rand.Next(-100, 101);
                    position.Y -= 150;
                    float speedX = player.position.X + player.width * 0.5f + Main.rand.Next(-200, 201) - position.X;
                    float speedY = player.Center.Y - position.Y;
                    if (speedY < 0f)
                        speedY *= -1f;
                    if (speedY < 20f)
                        speedY = 20f;

                    float length = (float)Math.Sqrt((double)(speedX * speedX + speedY * speedY));
                    length = 12 / length;
                    speedX *= length;
                    speedY *= length;
                    speedX = speedX + (float)Main.rand.Next(-40, 41) * 0.03f;
                    speedY = speedY + (float)Main.rand.Next(-40, 41) * 0.03f;
                    speedX *= (float)Main.rand.Next(75, 150) * 0.01f;
                    position.X += (float)Main.rand.Next(-50, 51);
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("VeinstoneBlood"), 40, 1, player.whoAmI);
                }

            }
            if (this.acidSet && Main.rand.Next(3) == 0)
            {
                Projectile.NewProjectile(player.position.X, player.position.Y, 0, -2, mod.ProjectileType("AcidBlast"), 25, 0, Main.myPlayer);

            }
            if (this.infernalSet && Main.rand.Next(10) == 0)
            {
                Projectile.NewProjectile(player.position.X, player.position.Y, 0, -2, mod.ProjectileType("InfernalBlast"), 50, 7, Main.myPlayer);

            }
            if (this.starCharm && Main.rand.Next(1) == 0)
            {
                int amount = Main.rand.Next(4, 6);
                for (int i = 0; i < amount; ++i)
                {
                    Vector2 position = new Vector2(player.position.X + player.width * 0.5f + Main.rand.Next(-200, 201), player.Center.Y - 600f);
                    position.X = (position.X * 10f + player.position.X) / 11f + (float)Main.rand.Next(-100, 101);
                    position.Y -= 150;
                    float speedX = player.position.X + player.width * 0.5f + Main.rand.Next(-200, 201) - position.X;
                    float speedY = player.Center.Y - position.Y;
                    if (speedY < 0f)
                        speedY *= -1f;
                    if (speedY < 20f)
                        speedY = 20f;

                    float length = (float)Math.Sqrt((double)(speedX * speedX + speedY * speedY));
                    length = 12 / length;
                    speedX *= length;
                    speedY *= length;
                    speedX = speedX + (float)Main.rand.Next(-40, 41) * 0.03f;
                    speedY = speedY + (float)Main.rand.Next(-40, 41) * 0.03f;
                    speedX *= (float)Main.rand.Next(75, 150) * 0.01f;
                    position.X += (float)Main.rand.Next(-50, 51);
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Starshock1"), 35, 1, player.whoAmI);
                }

            }
            if (this.gremlinTooth && Main.rand.Next(3) == 0)
            {
                player.AddBuff(mod.BuffType("ToothBuff"), 300);
            }
                if (this.starMap && Main.rand.Next(3) == 0)
            {
                int amount = Main.rand.Next(2, 3);
                for (int i = 0; i < amount; ++i)
                {
                    Vector2 position = new Vector2(player.position.X + player.width * 0.5f + Main.rand.Next(-300, 301), player.Center.Y - 800f);
                    position.X = (position.X * 10f + player.position.X) / 11f + (float)Main.rand.Next(-100, 101);
                    position.Y -= 150;
                    float speedX = player.position.X + player.width * 0.5f + Main.rand.Next(-200, 201) - position.X;
                    float speedY = player.Center.Y - position.Y;
                    if (speedY < 0f)
                        speedY *= -1f;
                    if (speedY < 30f)
                        speedY = 30f;

                    float length = (float)Math.Sqrt((double)(speedX * speedX + speedY * speedY));
                    length = 12 / length;
                    speedX *= length;
                    speedY *= length;
                    speedX = speedX + (float)Main.rand.Next(-40, 41) * 0.03f;
                    speedY = speedY + (float)Main.rand.Next(-40, 41) * 0.03f;
                    speedX *= (float)Main.rand.Next(75, 150) * 0.01f;
                    position.X += (float)Main.rand.Next(-10, 11);
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, mod.ProjectileType("Starshock1"), 24, 1, player.whoAmI);
                }

            }
            if (this.Bauble && player.statLife < player.statLifeMax2 / 2)
            {
                if (this.baubleTimer <= 0)
                {
                    Vector2 vel = new Vector2(0, -1);
                    float rand = Main.rand.NextFloat() * 0;
                    vel = vel.RotatedBy(rand);
                    int proj = Projectile.NewProjectile(Main.player[Main.myPlayer].Center.X, Main.player[Main.myPlayer].Center.Y, vel.X, vel.Y, mod.ProjectileType("IceReflector"), 0, 0, Main.myPlayer);
                    player.endurance += .30f;
                    this.baubleTimer = 7200;
                }
            }
            if (this.OverseerCharm && Main.rand.Next(2) == 0)
            {
                for (int h = 0; h < 8; h++)
                {
                    Vector2 vel = new Vector2(0, -1);
                    float rand = Main.rand.NextFloat() * 6.283f;
                    vel = vel.RotatedBy(rand);
                    vel *= 8f;
                    int proj = Projectile.NewProjectile(Main.player[Main.myPlayer].Center.X, Main.player[Main.myPlayer].Center.Y, vel.X, vel.Y, mod.ProjectileType("SpiritShardFriendly"), 250, 0, Main.myPlayer);
                }
            }
            if (babyClamper == true && Main.rand.Next(6) == 1)
            {
                Projectile.NewProjectile(player.position.X + 20, player.position.Y, 0, -2, mod.ProjectileType("ClampOrb"), 0, 0, Main.myPlayer);
                player.endurance += 0.1F;
            }
            if (this.reaperSet)
            {
                for (int h = 0; h < 3; h++)
                {
                    Vector2 vel = new Vector2(0, -1);
                    vel *= 2f;
                    int proj = Projectile.NewProjectile(Main.player[Main.myPlayer].Center.X, Main.player[Main.myPlayer].Center.Y, vel.X, vel.Y, mod.ProjectileType("FelShot"), 80, 0, Main.myPlayer);
                }
            }
            if (this.mythrilCharm && Main.rand.Next(2) == 0)
            {
                int mythrilCharmDamage = (int)(damage / 4);
                if (mythrilCharmDamage < 1) mythrilCharmDamage = 5;

                Rectangle mythrilCharmCollision = new Rectangle((int)player.Center.X - 120, (int)player.Center.Y - 120, 240, 240);
                for (int i = 0; i < 200; ++i)
                {
                    if (Main.npc[i].active && Main.npc[i].Hitbox.Intersects(mythrilCharmCollision))
                    {
                        Main.npc[i].StrikeNPCNoInteraction(mythrilCharmDamage, 0, 0);
                    }
                }

                for (int i = 0; i < 15; ++i)
                {
                    Dust.NewDust(new Vector2(mythrilCharmCollision.X, mythrilCharmCollision.Y), mythrilCharmCollision.Width, mythrilCharmCollision.Height, DustID.LunarOre);
                }
            }
        }

        public override void PreUpdate()
        {
            if (icytrail == true && player.velocity.X != 0)
            {
                Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("FrostTrail"), 35, 0f, player.whoAmI, 0f, 0f);
            }
            if (this.starSet == true && player.velocity.X != 0 && Main.rand.Next(10) == 1)
            {
                Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("StarTrail"), 13, 0f, player.whoAmI, 0f, 0f);
            }
            if (flametrail == true && player.velocity.X != 0)
            {
                Projectile.NewProjectile(player.position.X, player.position.Y + 40, 0f, 0f, mod.ProjectileType("CursedFlameTrail"), 35, 0f, player.whoAmI, 0f, 0f);
            }
            if (CrystalShield == true && player.velocity.X != 0 && Main.rand.Next(3) == 1)
            {
                if (player.velocity.X < 0)
                {
                    Projectile.NewProjectile(player.position.X, player.Center.Y, Main.rand.Next(6, 10), Main.rand.Next(-3, 3), 90, 36, 0f, player.whoAmI, 0f, 0f);
                }
                if (player.velocity.X > 0)
                {
                    Projectile.NewProjectile(player.position.X, player.Center.Y, Main.rand.Next(-10, -6), Main.rand.Next(-3, 3), 90, 36, 0f, player.whoAmI, 0f, 0f);
                }
            }
        }

        public override void UpdateBadLifeRegen()
        {
            if (DoomDestiny)
            {
                if (player.lifeRegen > 0)
                {
                    player.lifeRegen = 0;
                }
                player.lifeRegenTime = 0;
                player.lifeRegen -= 16;
            }
        }
        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (SRingOn == true)
            {
                int newProj = Terraria.Projectile.NewProjectile(player.Center.X, player.Center.Y, (2 * 3), 2 * 3, 356, 40, 0f, Main.myPlayer);

                int dist = 800;
                int target = -1;
                for (int i = 0; i < 200; ++i)
                {
                    if (Main.npc[i].active && Main.npc[i].CanBeChasedBy(Main.projectile[newProj], false))
                    {
                        if ((Main.npc[i].Center - Main.projectile[newProj].Center).Length() < dist)
                        {
                            target = i;
                            break;
                        }
                    }
                }

                Main.projectile[newProj].ai[0] = target;
            }
            
            if (Fierysoul == true)
            {
                int newProj = Terraria.Projectile.NewProjectile(player.Center.X, player.Center.Y, (2 * 3), 2 * 3, ProjectileID.MolotovFire2, 30, 0f, Main.myPlayer);


            }

            if (spiritBuff == true && Main.rand.Next(3) == 1)
            {
                int newProj = Terraria.Projectile.NewProjectile(player.Center.X, player.Center.Y, (2 * 3), 2 * 3, 356, 40, 0f, Main.myPlayer);

                int dist = 800;
                int target = -1;
                for (int i = 0; i < 200; ++i)
                {
                    if (Main.npc[i].active && Main.npc[i].CanBeChasedBy(Main.projectile[newProj], false))
                    {
                        if ((Main.npc[i].Center - Main.projectile[newProj].Center).Length() < dist)
                        {
                            target = i;
                            break;
                        }
                    }
                }
            }
        }

        // IRIAZUL'S CODE



        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            {
                if (this.fateToken)
                {
                    player.statLife = 500;
                    timeLeft = 0;
                    this.fateToken = false;
                    return false;
                }
                return true;
            }
            if (this.bubbleShield)
            {
                for (int i = 3; i < 8 + player.extraAccessorySlots; i++)
                {
                    int type = player.armor[i].type;
                    if (type == mod.ItemType("BubbleShield"))
                    {
                        player.armor[i].SetDefaults(0);
                        break;
                    }
                }
                player.statLife = 150;
                bubbleTimer = 360;
                return false;
            }
            if (this.clatterboneSet)
            {
                if (this.clatterboneTimer <= 0)
                {
                    MyPlayer gp = (MyPlayer)Main.player[Main.myPlayer].GetModPlayer(mod, "MyPlayer");
                    CombatText.NewText(new Rectangle((int)gp.player.position.X, (int)gp.player.position.Y - 60, gp.player.width, gp.player.height), new Color(29, 240, 255, 100),
                    "Sturdy Activated!");
                    player.statLife += (int)damage;
                    this.clatterboneTimer = 21600; // 6 minute timer.

                    player.AddBuff(mod.BuffType("Sturdy"), 60);

                    return false;
                }
            }

            return true;
        }

        public override void PostUpdateEquips()
        {
            // Update armor sets.
            #region Infernal Set
            if (this.infernalSet)
            {
                int percentageLifeLeft = (int)(((float)player.statLife / (float)player.statLifeMax2) * 100);
                if (percentageLifeLeft <= 25)
                {
                    player.statDefense -= 4;
                    player.manaCost += 0.25F;
                    player.magicDamage += 0.5F;

                    bool spawnProj = true;
                    for (int i = 0; i < 1000; ++i)
                    {
                        if (Main.projectile[i].type == mod.ProjectileType("InfernalGuard") && Main.projectile[i].owner == player.whoAmI)
                        {
                            spawnProj = false;
                            break;
                        }
                    }
                    if (spawnProj)
                    {
                        for (int i = 0; i < 3; ++i)
                        {
                            int newProj = Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("InfernalGuard"), 0, 0, player.whoAmI, 90, 1);
                            Main.projectile[newProj].localAI[1] = 2f * (float)Math.PI / 3f * i;
                        }
                    }

                    player.AddBuff(mod.BuffType("InfernalRage"), 2);
                    infernalSetCooldown = 60;
                }
            }

            if (infernalSetCooldown > 0)
                infernalSetCooldown--;
            #endregion

            if (this.runicSet)
            {
                this.SpawnRunicRunes();
            }

            #region Spirit Set
            if (this.spiritSet)
            {
                if (Main.rand.Next(5) == 0)
                {
                    int num = Dust.NewDust(player.position, player.width, player.height, 261, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num].noGravity = true;
                }
                if (player.statLife >= 400)
                {
                    player.meleeDamage += 0.08f;
                    player.magicDamage += 0.08f;
                    player.minionDamage += 0.08f;
                    player.thrownDamage += 0.08f;
                    player.rangedDamage += 0.08f;
                }
                else if (player.statLife >= 200)
                {
                    player.statDefense += 6;
                }
                else if (player.statLife >= 50)
                {
                    player.lifeRegenTime += 5;
                }
                else if (player.statLife > 0)
                {
                    player.noKnockback = true;
                }
            }
            #endregion

            if (this.bloomwindSet)
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("BloomwindMinion")] <= 1)
                {
                    player.AddBuff(mod.BuffType("BloomwindMinionBuff"), 3600);
                    Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("BloomwindMinion"), 25, 0, player.whoAmI);
                }
            }
            if (this.Ward)
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("WardProj")] <= 1)
                {
                    Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("WardProj"), 1, 0, player.whoAmI);
                }
            }

            if (this.oceanSet)
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("BabyClamper")] <= 1)
                {
                    player.AddBuff(mod.BuffType("BabyClamperBuff"), 3600);
                    Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("BabyClamper"), 19, 0, player.whoAmI);
                }
            }
            if (this.witherSet)
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("WitherOrb")] <= 0)
                {
                    Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("WitherOrb"), 45, 0, player.whoAmI);
                }
            }

            if (this.illuminantSet && (Main.rand.Next(12) == 0))
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("EnchantedSword")] <= 3)
                {
                    Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("EnchantedSword"), 28, 0, player.whoAmI);
                }
            }
            if (this.shadowSet && (Main.rand.Next(2) == 0))
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("Spirit")] <= 2)
                {
                    Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("Spirit"), 56, 0, player.whoAmI);
                }
            }
            if (this.SoulStone && (Main.rand.Next(2) == 0))
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("StoneSpirit")] < 1)
                {
                    Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("StoneSpirit"), 35, 0, player.whoAmI);
                }
            }

            if (this.duskSet)
            {
                if (player.ownedProjectileCounts[mod.ProjectileType("ShadowCircleRune1")] <= 0)
                {
                    Projectile.NewProjectile(player.position, Vector2.Zero, mod.ProjectileType("ShadowCircleRune1"), 18, 0, player.whoAmI);
                }
            }

            if (this.leatherSet)
            {
                if (this.concentratedCooldown > 0)
                    this.concentratedCooldown--;
            }
            if (!this.leatherSet)
            {
                this.concentrated = false;
                this.concentratedCooldown = 300;
            }
                     if (this.shadowSet)
            {
                if (infernalDash > 0)
                    infernalDash--;
                else
                    infernalHit = -1;

                if (infernalDash > 0 && infernalHit < 0)
                {
                    Rectangle rectangle = new Rectangle((int)(player.position.X + player.velocity.X * 0.5 - 4.0), (int)(player.position.Y + player.velocity.Y * 0.5 - 4.0), player.width + 8, player.height + 8);
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
                        {
                            NPC npc = Main.npc[i];
                            Rectangle rect = npc.getRect();
                            if (rectangle.Intersects(rect) && (npc.noTileCollide || Collision.CanHit(player.position, player.width, player.height, npc.position, npc.width, npc.height)))
                            {
                                float damage = 100f * player.meleeDamage;
                                float knockback = 10f;
                                bool crit = false;

                                if (player.kbGlove)
                                    knockback *= 0f;
                                if (player.kbBuff)
                                    knockback *= 1f;

                                if (Main.rand.Next(100) < player.meleeCrit)
                                    crit = true;

                                int hitDirection = player.direction;
                                if (player.velocity.X < 0f)
                                {
                                    hitDirection = -1;
                                }
                                if (player.velocity.X > 0f)
                                {
                                    hitDirection = 1;
                                }
                                if (player.whoAmI == Main.myPlayer)
                                {
                                    npc.AddBuff(mod.BuffType("SoulFlare"), 600);
                                    npc.StrikeNPC((int)damage, knockback, hitDirection, crit, false, false);
                                    if (Main.netMode != 0)
                                    {
                                        NetMessage.SendData(28, -1, -1, "", i, damage, knockback, (float)hitDirection, 0, 0, 0);
                                    }
                                }

                                this.infernalDash = 10;
                                player.dashDelay = 0;
                                player.velocity.X = -(float)hitDirection * 2f;
                                player.velocity.Y = -2f;
                                player.immune = true;
                                player.immuneTime = 7;
                                this.infernalHit = i;
                            }
                        }
                    }
                }

                if (player.dash <= 0 && player.dashDelay == 0 && !player.mount.Active)
                {
                    int num21 = 0;
                    bool flag2 = false;
                    if (player.dashTime > 0)
                        player.dashTime--;
                    if (player.dashTime < 0)
                        player.dashTime++;

                    if (player.controlRight && player.releaseRight)
                    {
                        if (player.dashTime > 0)
                        {
                            num21 = 1;
                            flag2 = true;
                            player.dashTime = 0;
                        } else
                        {
                            player.dashTime = 15;
                        }
                    } else if (player.controlLeft && player.releaseLeft)
                    {
                        if (player.dashTime < 0)
                        {
                            num21 = -1;
                            flag2 = true;
                            player.dashTime = 0;
                        } else
                        {
                            player.dashTime = -15;
                        }
                    }

                    if (flag2)
                    {
                        player.velocity.X = 15.5f * (float)num21;
                        Point point3 = (player.Center + new Vector2((float)(num21 * player.width / 2 + 2), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
                        Point point4 = (player.Center + new Vector2((float)(num21 * player.width / 2 + 2), 0f)).ToTileCoordinates();
                        if (WorldGen.SolidOrSlopedTile(point3.X, point3.Y) || WorldGen.SolidOrSlopedTile(point4.X, point4.Y))
                        {
                            player.velocity.X = player.velocity.X / 2f;
                        }
                        player.dashDelay = -1;
                        this.infernalDash = 15;
                        for (int num22 = 0; num22 < 0; num22++)
                        {
                            int num23 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default(Color), 2f);
                            Dust dust3 = Main.dust[num23];
                            dust3.position.X = dust3.position.X + (float)Main.rand.Next(-5, 6);
                            Dust dust4 = Main.dust[num23];
                            dust4.position.Y = dust4.position.Y + (float)Main.rand.Next(-5, 6);
                            Main.dust[num23].velocity *= 0.2f;
                            Main.dust[num23].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
                            Main.dust[num23].shader = GameShaders.Armor.GetSecondaryShader(player.shield, player);
                        }
                    }
                }
            }

            if (infernalDash > 0)
                infernalDash--;
            if (player.dashDelay < 0)
            {
                for (int l = 0; l < 0; l++)
                {
                    int num14;
                    if (player.velocity.Y == 0f)
                    {
                        num14 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + player.height - 4f), player.width, 8, 31, 0f, 0f, 100, default(Color), 1.4f);
                    } else
                    {
                        num14 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + (player.height / 2) - 8f), player.width, 16, 31, 0f, 0f, 100, default(Color), 1.4f);
                    }
                    Main.dust[num14].velocity *= 0.1f;
                    Main.dust[num14].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
                    Main.dust[num14].shader = GameShaders.Armor.GetSecondaryShader(player.shoe, player);
                    int dust2 = Dust.NewDust(player.position, player.width, player.height, 6, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust2].scale *= 10f;
                    int dust = Dust.NewDust(player.position, player.width, player.height, 6, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust].scale *= 10f;
                    int dust3 = Dust.NewDust(player.position, player.width, player.height, 6, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust3].scale *= 10f;

                }

                float maxSpeed = Math.Max(player.accRunSpeed, player.maxRunSpeed);

                player.vortexStealthActive = false;
                if (player.velocity.X > 12f || player.velocity.X < -12f)
                {
                    player.velocity.X = player.velocity.X * 0.985f;
                    return;
                }
                if (player.velocity.X > maxSpeed || player.velocity.X < -maxSpeed)
                {
                    player.velocity.X = player.velocity.X * 0.94f;
                    return;
                }
                player.dashDelay = 30;
                if (player.velocity.X < 0f)
                {
                    player.velocity.X = -maxSpeed;
                    return;
                }
                if (player.velocity.X > 0f)
                {
                    player.velocity.X = maxSpeed;
                    return;
                }
            }

            // Update accessories.
            #region Infernal Shield
            if (this.infernalShield)
            {
                if (infernalDash > 0)
                    infernalDash--;
                else
                    infernalHit = -1;

                if (infernalDash > 0 && infernalHit < 0)
                {
                    int dust2 = Dust.NewDust(player.position, player.width, player.height, 6, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust2].scale *= 2f;
                    int dust = Dust.NewDust(player.position, player.width, player.height, 6, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust].scale *= 2f;
                    int dust3 = Dust.NewDust(player.position, player.width, player.height, 6, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[dust3].scale *= 2f;
                    Rectangle rectangle = new Rectangle((int)(player.position.X + player.velocity.X * 0.5 - 4.0), (int)(player.position.Y + player.velocity.Y * 0.5 - 4.0), player.width + 8, player.height + 8);
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly)
                        {
                            NPC npc = Main.npc[i];
                            Rectangle rect = npc.getRect();
                            if (rectangle.Intersects(rect) && (npc.noTileCollide || Collision.CanHit(player.position, player.width, player.height, npc.position, npc.width, npc.height)))
                            {
                                float damage = 30f * player.meleeDamage;
                                float knockback = 12f;
                                bool crit = false;

                                if (player.kbGlove)
                                    knockback *= 2f;
                                if (player.kbBuff)
                                    knockback *= 1.5f;


                                if (Main.rand.Next(100) < player.meleeCrit)
                                    crit = true;

                                int hitDirection = player.direction;
                                if (player.velocity.X < 0f)
                                {
                                    hitDirection = -1;
                                }
                                if (player.velocity.X > 0f)
                                {
                                    hitDirection = 1;
                                }
                                if (player.whoAmI == Main.myPlayer)
                                {
                                    npc.AddBuff(mod.BuffType("StackingFireBuff"), 600);
                                    npc.StrikeNPC((int)damage, knockback, hitDirection, crit, false, false);
                                    if (Main.netMode != 0)
                                    {
                                        NetMessage.SendData(28, -1, -1, "", i, damage, knockback, (float)hitDirection, 0, 0, 0);
                                    }
                                }

                                this.infernalDash = 10;
                                player.dashDelay = 30;
                                player.velocity.X = -(float)hitDirection * 1f;
                                player.velocity.Y = -4f;
                                player.immune = true;
                                player.immuneTime = 2;

                                this.infernalHit = i;
                            }
                        }
                    }
                }

                if (player.dash <= 0 && player.dashDelay == 0 && !player.mount.Active)
                {
                    int num21 = 0;
                    bool flag2 = false;
                    if (player.dashTime > 0)
                        player.dashTime--;
                    if (player.dashTime < 0)
                        player.dashTime++;

                    if (player.controlRight && player.releaseRight)
                    {
                        if (player.dashTime > 0)
                        {
                            num21 = 1;
                            flag2 = true;
                            player.dashTime = 0;
                        } else
                        {
                            player.dashTime = 15;
                        }
                    } else if (player.controlLeft && player.releaseLeft)
                    {
                        if (player.dashTime < 0)
                        {
                            num21 = -1;
                            flag2 = true;
                            player.dashTime = 0;
                        } else
                        {
                            player.dashTime = -15;
                        }
                    }

                    if (flag2)
                    {
                        int dust2 = Dust.NewDust(player.position, player.width, player.height, 6, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[dust2].scale *= 2f;
                        int dust = Dust.NewDust(player.position, player.width, player.height, 6, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[dust].scale *= 2f;
                        player.velocity.X = 15.5f * (float)num21;
                        Point point3 = (player.Center + new Vector2((float)(num21 * player.width / 2 + 2), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f)).ToTileCoordinates();
                        Point point4 = (player.Center + new Vector2((float)(num21 * player.width / 2 + 2), 0f)).ToTileCoordinates();
                        if (WorldGen.SolidOrSlopedTile(point3.X, point3.Y) || WorldGen.SolidOrSlopedTile(point4.X, point4.Y))
                        {
                            player.velocity.X = player.velocity.X / 2f;
                        }
                        player.dashDelay = -1;
                        this.infernalDash = 15;
                        for (int num22 = 0; num22 < 0; num22++)
                        {
                            int num23 = Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.width, player.height, 31, 0f, 0f, 100, default(Color), 2f);
                            Dust dust3 = Main.dust[num23];
                            dust3.position.X = dust3.position.X + (float)Main.rand.Next(-5, 6);
                            Dust dust4 = Main.dust[num23];
                            dust4.position.Y = dust4.position.Y + (float)Main.rand.Next(-5, 6);
                            Main.dust[num23].velocity *= 0.2f;
                            Main.dust[num23].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
                            Main.dust[num23].shader = GameShaders.Armor.GetSecondaryShader(player.shield, player);
                        }
                    }
                }
            }

            if (infernalDash > 0)
                infernalDash--;
            if (player.dashDelay < 0)
            {
                for (int l = 0; l < 0; l++)
                {
                    int num14;
                    if (player.velocity.Y == 0f)
                    {
                        num14 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + player.height - 4f), player.width, 8, 31, 0f, 0f, 100, default(Color), 1.4f);
                    } else
                    {
                        num14 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + (player.height / 2) - 8f), player.width, 16, 31, 0f, 0f, 100, default(Color), 1.4f);
                    }
                    Main.dust[num14].velocity *= 0.1f;
                    Main.dust[num14].scale *= 1f + (float)Main.rand.Next(20) * 0.01f;
                    Main.dust[num14].shader = GameShaders.Armor.GetSecondaryShader(player.shoe, player);
                }

                float maxSpeed = Math.Max(player.accRunSpeed, player.maxRunSpeed);

                player.vortexStealthActive = false;
                if (player.velocity.X > 12f || player.velocity.X < -12f)
                {
                    player.velocity.X = player.velocity.X * 0.985f;
                    return;
                }
                if (player.velocity.X > maxSpeed || player.velocity.X < -maxSpeed)
                {
                    player.velocity.X = player.velocity.X * 0.94f;
                    return;
                }
                player.dashDelay = 30;
                if (player.velocity.X < 0f)
                {
                    player.velocity.X = -maxSpeed;
                    return;
                }
                if (player.velocity.X > 0f)
                {
                    player.velocity.X = maxSpeed;
                    return;
                }
            }
            #endregion

            if (this.shadowGauntlet)
            {
                player.kbGlove = true;
                player.meleeDamage += 0.07F;
                player.meleeSpeed += 0.07F;
            }
            if (this.goldenApple)
            {
                int num2 = 20;
                float num3 = (float)(player.statLifeMax2 - player.statLife) / (float)player.statLifeMax2 * (float)num2;
                player.statDefense += (int)num3;
            }
            if (this.bubbleTimer > 0)
                this.bubbleTimer--;

            if (this.soulSiphon > 0)
            {
                player.lifeRegenTime += 2;
                int num = (5 + this.soulSiphon) / 2;
                player.lifeRegenTime += num;
                player.lifeRegen += num;

                this.soulSiphon = 0;
            }

            if (this.drakomireMount)
            {
                player.statDefense += 40;
                player.noKnockback = true;
                if (player.dashDelay > 0)
                {
                    player.dashDelay--;
                }
                else
                {
                    int num4 = 0;
                    bool flag = false;
                    if (player.dashTime > 0)
                    {
                        player.dashTime--;
                    }
                    else if (player.dashTime < 0)
                    {
                        player.dashTime++;
                    }
                    if (player.controlRight && player.releaseRight)
                    {
                        if (player.dashTime > 0)
                        {
                            num4 = 1;
                            flag = true;
                            player.dashTime = 0;
                        }
                        else
                        {
                            player.dashTime = 15;
                        }
                    }
                    else if (player.controlLeft && player.releaseLeft)
                    {
                        if (player.dashTime < 0)
                        {
                            num4 = -1;
                            flag = true;
                            player.dashTime = 0;
                        }
                        else
                        {
                            player.dashTime = -15;
                        }
                    }
                    if (flag)
                    {
                        player.velocity.X = 16.9f * (float)num4;
                        Point point = Utils.ToTileCoordinates(player.Center + new Vector2((float)(num4 * player.width / 2 + 2), player.gravDir * -(float)player.height / 2f + player.gravDir * 2f));
                        Point point2 = Utils.ToTileCoordinates(player.Center + new Vector2((float)(num4 * player.width / 2 + 2), 0f));
                        if (WorldGen.SolidOrSlopedTile(point.X, point.Y) || WorldGen.SolidOrSlopedTile(point2.X, point2.Y))
                        {
                            player.velocity.X = player.velocity.X / 2f;
                        }
                        player.dashDelay = 600;
                    }
                }
                if (player.velocity.X != 0f && player.velocity.Y == 0f)
                {
                    this.drakomireFlameTimer += (int)Math.Abs(player.velocity.X);
                    if (this.drakomireFlameTimer >= 15)
                    {
                        Vector2 vector = player.Center + new Vector2((float)(26 * -(float)player.direction), 26f * player.gravDir);
                        Terraria.Projectile.NewProjectile(vector.X, vector.Y, 0f, 0f, mod.ProjectileType("DrakomireFlame"), player.statDefense / 2, 0f, player.whoAmI, 0f, 0f);
                        this.drakomireFlameTimer = 0;
                    }
                }
                if (Main.rand.Next(10) == 0)
                {
                    Vector2 vector2 = player.Center + new Vector2((float)(-48 * player.direction), -6f * player.gravDir);
                    if (player.direction == -1)
                    {
                        vector2.X -= 20f;
                    }
                    Dust.NewDust(vector2, 16, 16, 6, 0f, 0f, 0, default(Color), 1f);
                }
            }
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (CursedPendant && Main.rand.Next(5) == 1)
            {
                target.AddBuff(39, 180);
            }
            if (IchorPendant && Main.rand.Next(10) == 1)
            {
                target.AddBuff(69, 180);
            }
            if (this.shadowGauntlet)
            {
                if (Main.rand.Next(2) == 0)
                    target.AddBuff(BuffID.ShadowFlame, 180);
            }
            if (this.duskSet && item.magic)
            {
                if (Main.rand.Next(4) == 0)
                    target.AddBuff(BuffID.ShadowFlame, 300);
            }
            if (this.primalSet && item.melee)
            {
                if (Main.rand.Next(2) == 0)
                    target.AddBuff(mod.BuffType("Afflicted"), 120);
            }
            if (this.illuminantSet && item.melee)
            {
                if (Main.rand.Next(4) == 0)
                    target.AddBuff(mod.BuffType("HolyLight"), 120);
            }
            if (this.moonGauntlet && item.melee)
            {
                if (Main.rand.Next(4) == 0)
                    target.AddBuff(BuffID.CursedInferno, 180);

                if (Main.rand.Next(4) == 0)
                    target.AddBuff(BuffID.Ichor, 180);

                if (Main.rand.Next(4) == 0)
                    target.AddBuff(BuffID.Daybreak, 180);

                if (Main.rand.Next(8) == 0)
                    player.AddBuff(mod.BuffType("OnyxWind"), 120);
            }
            if (this.moonHeart && item.melee)
            {
                if (Main.rand.Next(15) == 0)
                    target.AddBuff(mod.BuffType("CelestialWill"), 120);
            }
            if (this.moonHeart && item.ranged)
            {
                if (Main.rand.Next(15) == 0)
                    target.AddBuff(mod.BuffType("CelestialWill"), 120);
            }
            if (this.moonHeart && item.magic)
            {
                if (Main.rand.Next(15) == 0)
                    target.AddBuff(mod.BuffType("CelestialWill"), 120);
            }
            if (this.moonHeart && item.thrown)
            {
                if (Main.rand.Next(15) == 0)
                    target.AddBuff(mod.BuffType("CelestialWill"), 120);
            }
        }
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (icySoul && Main.rand.Next(6) == 1 && proj.thrown)
            {
                target.AddBuff(mod.BuffType("SoulBurn"), 280);
            }
            if (icySoul && Main.rand.Next(6) == 1 && proj.magic)
            {
                target.AddBuff(BuffID.Frostburn, 280);
            }
            if (this.shadowGauntlet && proj.melee)
            {
                if (Main.rand.Next(2) == 0)
                    target.AddBuff(BuffID.ShadowFlame, 180);
            }
            if (this.moonGauntlet && proj.melee)
            {
                if (Main.rand.Next(4) == 0)
                    target.AddBuff(BuffID.CursedInferno, 180);

                if (Main.rand.Next(4) == 0)
                    target.AddBuff(BuffID.Ichor, 180);

                if (Main.rand.Next(4) == 0)
                    target.AddBuff(BuffID.Daybreak, 180);

                if (Main.rand.Next(8) == 0)
                    player.AddBuff(mod.BuffType("OnyxWind"), 120);
            }
            if (this.acidSet && proj.thrown)
            {
                if (Main.rand.Next(100) == 0)
                    target.AddBuff(mod.BuffType("Death"), 60);
            }
            if (this.illuminantSet && proj.melee)
            {
                if (Main.rand.Next(4) == 0)
                    target.AddBuff(mod.BuffType("HolyLight"), 120);
            }
            if (this.illuminantSet && proj.ranged)
            {
                if (Main.rand.Next(4) == 0)
                    target.AddBuff(mod.BuffType("HolyLight"), 120);
            }
            if (this.illuminantSet && proj.magic)
            {
                if (Main.rand.Next(4) == 0)
                    target.AddBuff(mod.BuffType("HolyLight"), 120);
            }
            if (this.illuminantSet && proj.thrown)
            {
                if (Main.rand.Next(4) == 0)
                    target.AddBuff(mod.BuffType("HolyLight"), 120);
            }
            if (this.moonHeart && proj.melee)
            {
                if (Main.rand.Next(15) == 0)
                    target.AddBuff(mod.BuffType("CelestialWill"), 120);
            }
            if (this.moonHeart && proj.ranged)
            {
                if (Main.rand.Next(15) == 0)
                    target.AddBuff(mod.BuffType("CelestialWill"), 120);
            }
            if (this.moonHeart && proj.magic)
            {
                if (Main.rand.Next(15) == 0)
                    target.AddBuff(mod.BuffType("CelestialWill"), 120);
            }
            if (this.moonHeart && proj.thrown)
            {
                if (Main.rand.Next(15) == 0)
                    target.AddBuff(mod.BuffType("CelestialWill"), 120);
            }
            if (this.primalSet && proj.magic)
            {
                if (Main.rand.Next(2) == 0)
                    target.AddBuff(mod.BuffType("Afflicted"), 120);
            }
            if (this.primalSet && proj.melee)
            {
                if (Main.rand.Next(2) == 0)
                    target.AddBuff(mod.BuffType("Afflicted"), 120);
            }
            if (this.duskSet && proj.magic)
            {
                if (Main.rand.Next(4) == 0)
                    target.AddBuff(BuffID.ShadowFlame, 300);
            }
            
            if(this.concentrated && proj.ranged)
            {
                damage = (int)(damage * 1.1F);
                crit = true;

                this.concentrated = false;
                this.concentratedCooldown = 300;
            }
        }

        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (this.shadowGauntlet && item.melee)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Shadowflame);
        }

        public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
        {
            if (npc.whoAmI == infernalHit)
            {
                damage = 0;
            }
        }

        public override void FrameEffects()
        {
            //Hide players wings, etc. when mounted
            if (player.mount.Active)
            {
                int mount = player.mount.Type;
                if (mount == CandyCopter._ref.Type)
                {
                    //Supposed to make players legs disappear, but only makes them skin-colored.
                    player.legs = CandyCopter._outfit;
                    player.wings = -1;
                    player.back = -1;
                    player.shield = -1;
                    //player.handoff = -1;
                    //player.handon = -1;
                }
                else if (mount == Drakomire._ref.Type)
                {
                    player.wings = -1;
                }
            }
        }
        public override void PostUpdate()
        {
            if (shootDelay > 0)
            {
                shootDelay--;
                Rectangle rect = new Rectangle((int)player.Center.X, (int)player.position.Y, 1, -1);
                float x = Main.rand.NextFloat() * rect.Width;
                float y = Main.rand.NextFloat() * rect.Height;
                Tile atTile = Framing.GetTileSafely((int)((rect.X + x) / 16), (int)((rect.Y + y) / 16));
                if (!atTile.active())
                Dust.NewDust(new Vector2(rect.X + x, rect.Y + y), 6, 6, 6);
                Dust.NewDust(new Vector2(rect.X + x, rect.Y + y), 6, 6, 244);
                Dust.NewDust(new Vector2(rect.X + x, rect.Y + y), 6, 6, 244);
                Dust.NewDust(new Vector2(rect.X + x, rect.Y + y), 6, 6, 6);
            }

        }
        public override void PostUpdateRunSpeeds()
        {
            if (copterBrake && player.mount.Active && player.mount.Type == CandyCopter._ref.Type)
            {
                //Prevent horizontal movement
                player.maxRunSpeed = 0f;
                player.runAcceleration = 0f;
                //Deplete horizontal velocity
                if (player.velocity.X > CandyCopter.groundSlowdown)
                {
                    player.velocity.X -= CandyCopter.groundSlowdown;
                }
                else if (player.velocity.X < -CandyCopter.groundSlowdown)
                {
                    player.velocity.X += CandyCopter.groundSlowdown;
                }
                else
                {
                    player.velocity.X = 0f;
                }
                //Prevent further depletion by game engine
                player.runSlowdown = 0f;
            }
        }

        public override void DrawEffects(PlayerDrawInfo drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
        {
            if (toxify)
            {
                if (Main.rand.Next(2) == 0)
                {
                    int dust = Dust.NewDust(player.position, player.width + 4, 30, 110, player.velocity.X * 0.4f, player.velocity.Y * 0.4f, 100, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 1f;
                b *= 0f;
                fullBright = true;
            }
			if (BlueDust)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(player.position, player.width + 4, 30, 206, player.velocity.X, player.velocity.Y, 100, default(Color), 1f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 1f;
                b *= 0f;
                fullBright = true;
            }
            if (HellGaze)
            {
                if (Main.rand.Next(4) == 0)
                {
                    int dust = Dust.NewDust(player.position, player.width + 26, 30, 6,  player.velocity.X, player.velocity.Y, 100, default(Color), 1f);
                    Main.playerDrawDust.Add(dust);
                }
                r *= 0f;
                g *= 1f;
                b *= 0f;
                fullBright = true;
            }
        }

        public override void OnHitByNPC(NPC npc, int damage, bool crit)
        {
            if (this.basiliskMount)
            {
                int num = player.statDefense / 2;
                npc.StrikeNPCNoInteraction(num, 0f, 0, false, false, false);
            }
        }

        private void SpawnRunicRunes()
        {
            int num = 40;
            float num2 = 1.5f;
            int num3 = mod.ProjectileType("RunicRune");
            if (Main.rand.Next(15) == 0)
            {
                int num4 = 0;
                for (int i = 0; i < 1000; i++)
                {
                    if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI && Main.projectile[i].type == num3)
                    {
                        num4++;
                    }
                }
                if (Main.rand.Next(15) >= num4 && num4 < 10)
                {
                    int num5 = 50;
                    int num6 = 24;
                    int num7 = 90;
                    for (int j = 0; j < num5; j++)
                    {
                        int num8 = Main.rand.Next(200 - j * 2, 400 + j * 2);
                        Vector2 center = player.Center;
                        center.X += (float)Main.rand.Next(-num8, num8 + 1);
                        center.Y += (float)Main.rand.Next(-num8, num8 + 1);
                        if (!Collision.SolidCollision(center, num6, num6) && !Collision.WetCollision(center, num6, num6))
                        {
                            center.X += (float)(num6 / 2);
                            center.Y += (float)(num6 / 2);
                            if (Collision.CanHit(new Vector2(player.Center.X, player.position.Y), 1, 1, center, 1, 1) || Collision.CanHit(new Vector2(player.Center.X, player.position.Y - 50f), 1, 1, center, 1, 1))
                            {
                                int num9 = (int)center.X / 16;
                                int num10 = (int)center.Y / 16;
                                bool flag = false;
                                if (Main.rand.Next(4) == 0 && Main.tile[num9, num10] != null && Main.tile[num9, num10].wall > 0)
                                {
                                    flag = true;
                                }
                                else
                                {
                                    center.X -= (float)(num7 / 2);
                                    center.Y -= (float)(num7 / 2);
                                    if (Collision.SolidCollision(center, num7, num7))
                                    {
                                        center.X += (float)(num7 / 2);
                                        center.Y += (float)(num7 / 2);
                                        flag = true;
                                    }
                                }
                                if (flag)
                                {
                                    for (int k = 0; k < 1000; k++)
                                    {
                                        if (Main.projectile[k].active && Main.projectile[k].owner == player.whoAmI && Main.projectile[k].type == num3 && (center - Main.projectile[k].Center).Length() < 48f)
                                        {
                                            flag = false;
                                            break;
                                        }
                                    }
                                    if (flag && Main.myPlayer == player.whoAmI)
                                    {
                                        Terraria.Projectile.NewProjectile(center.X, center.Y, 0f, 0f, num3, num, num2, player.whoAmI, 0f, 0f);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private Vector2 TestTeleport(ref bool canSpawn, int teleportStartX, int teleportRangeX, int teleportStartY, int teleportRangeY)
        {
            Player player = Main.player[Main.myPlayer];
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int width = player.width;
            Vector2 Position = new Vector2((float)num2, (float)num3) * 16f + new Vector2((float)(-width / 2 + 8), (float)-player.height);
            while (!canSpawn && num1 < 1000)
            {
                ++num1;
                int index1 = teleportStartX + Main.rand.Next(teleportRangeX);
                int index2 = teleportStartY + Main.rand.Next(teleportRangeY);
                Position = new Vector2((float)index1, (float)index2) * 16f + new Vector2((float)(-width / 2 + 8), (float)-player.height);
                if (!Collision.SolidCollision(Position, width, player.height))
                {
                    if (Main.tile[index1, index2] == null)
                        Main.tile[index1, index2] = new Tile();
                    if (((int)Main.tile[index1, index2].wall != 87 || (double)index2 <= Main.worldSurface || NPC.downedPlantBoss) && (!Main.wallDungeon[(int)Main.tile[index1, index2].wall] || (double)index2 <= Main.worldSurface || NPC.downedBoss3))
                    {
                        int num4 = 0;
                        while (num4 < 100)
                        {
                            if (Main.tile[index1, index2 + num4] == null)
                                Main.tile[index1, index2 + num4] = new Tile();
                            Tile tile = Main.tile[index1, index2 + num4];
                            Position = new Vector2((float)index1, (float)(index2 + num4)) * 16f + new Vector2((float)(-width / 2 + 8), (float)-player.height);
                            Vector4 vector4 = Collision.SlopeCollision(Position, player.velocity, width, player.height, player.gravDir, false);
                            bool flag = !Collision.SolidCollision(Position, width, player.height);
                            if ((double)vector4.Z == (double)player.velocity.X)
                            {
                                double y = (double)player.velocity.Y;
                            }
                            if (flag)
                                ++num4;
                            else if (!tile.active() || tile.inActive() || !Main.tileSolid[(int)tile.type])
                                ++num4;
                            else
                                break;
                        }
                        if (!Collision.LavaCollision(Position, width, player.height) && (double)Collision.HurtTiles(Position, player.velocity, width, player.height, false).Y <= 0.0)
                        {
                            Collision.SlopeCollision(Position, player.velocity, width, player.height, player.gravDir, false);
                            if (Collision.SolidCollision(Position, width, player.height) && num4 < 99)
                            {
                                Vector2 Velocity1 = Vector2.UnitX * 16f;
                                if (!(Collision.TileCollision(Position - Velocity1, Velocity1, player.width, player.height, false, false, (int)player.gravDir) != Velocity1))
                                {
                                    Vector2 Velocity2 = -Vector2.UnitX * 16f;
                                    if (!(Collision.TileCollision(Position - Velocity2, Velocity2, player.width, player.height, false, false, (int)player.gravDir) != Velocity2))
                                    {
                                        Vector2 Velocity3 = Vector2.UnitY * 16f;
                                        if (!(Collision.TileCollision(Position - Velocity3, Velocity3, player.width, player.height, false, false, (int)player.gravDir) != Velocity3))
                                        {
                                            Vector2 Velocity4 = -Vector2.UnitY * 16f;
                                            if (!(Collision.TileCollision(Position - Velocity4, Velocity4, player.width, player.height, false, false, (int)player.gravDir) != Velocity4))
                                            {
                                                canSpawn = true;
                                                int num5 = index2 + num4;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return Position;
        }
        #region Player Draw Layers
        public override void ModifyDrawLayers(List<PlayerLayer> layers)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if ((this.drakomireMount || this.basiliskMount) && layers[i].Name == "Wings")
                {
                    layers[i].visible = false;
                }

                if(layers[i].Name == "HeldItem")
                {
                    if(player.inventory[player.selectedItem].type == mod.ItemType("HexBow") && player.itemAnimation > 0)
                    {
                        this.weaponAnimationCounter++;
                        if(this.weaponAnimationCounter >= 10)
                        {
                            this.hexBowAnimationFrame =  (this.hexBowAnimationFrame + 1) % 4;
                            weaponAnimationCounter = 0;
                        }
                        layers[i] = WeaponLayer;
                    }
                }
            }

            if(this.bubbleTimer > 0)
            {
                BubbleLayer.visible = true;
                layers.Add(BubbleLayer);
            }
        }

        public static readonly PlayerLayer WeaponLayer = new PlayerLayer("SpiritMod", "WeaponLayer", PlayerLayer.HeldItem, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("SpiritMod");
            MyPlayer mp = drawPlayer.GetModPlayer<MyPlayer>(mod);

            if (drawPlayer.active && !drawPlayer.outOfRange)
            {
                Texture2D weaponTexture = Main.itemTexture[drawPlayer.inventory[drawPlayer.selectedItem].type];
                SpriteEffects effect = drawPlayer.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                Vector2 vector8 = new Vector2(weaponTexture.Width / 2, (weaponTexture.Height / 4) / 2);
                Vector2 vector9 = new Vector2(8, 0);
                int num84 = (int)vector9.X;
                Vector2 vector = drawPlayer.itemLocation;
                vector.Y += weaponTexture.Height * 0.5F;
                vector8.Y = vector9.Y;
                Vector2 origin2 = new Vector2(-(float)num84, (weaponTexture.Height / 4) / 2);
                if (drawPlayer.direction == -1)
                {
                    origin2 = new Vector2((float)(weaponTexture.Width + num84), (weaponTexture.Height / 4) / 2);
                }
                DrawData drawData = new DrawData(weaponTexture, new Vector2((float)((int)(vector.X - Main.screenPosition.X + vector8.X)), (float)((int)(vector.Y - Main.screenPosition.Y + vector8.Y))), new Rectangle?(new Rectangle(0, (weaponTexture.Height / 4) * mp.hexBowAnimationFrame, weaponTexture.Width, weaponTexture.Height / 4)), drawPlayer.inventory[drawPlayer.selectedItem].GetAlpha(Color.White), drawPlayer.itemRotation, origin2, drawPlayer.inventory[drawPlayer.selectedItem].scale, effect, 0);
                Main.playerDrawData.Add(drawData);
                if (drawPlayer.inventory[drawPlayer.selectedItem].color != default(Color))
                {
                    drawData = new DrawData(weaponTexture, new Vector2((float)((int)(vector.X - Main.screenPosition.X + vector8.X)), (float)((int)(vector.Y - Main.screenPosition.Y + vector8.Y))), new Rectangle?(new Rectangle(0, (weaponTexture.Height / 4) * mp.hexBowAnimationFrame, weaponTexture.Width, weaponTexture.Height / 4)), drawPlayer.inventory[drawPlayer.selectedItem].GetColor(Color.White), drawPlayer.itemRotation, origin2, drawPlayer.inventory[drawPlayer.selectedItem].scale, effect, 0);
                    Main.playerDrawData.Add(drawData);
                }
            }
        });

        public static readonly PlayerLayer BubbleLayer = new PlayerLayer("SpiritMod", "BubbleLayer", PlayerLayer.Body, delegate (PlayerDrawInfo drawInfo)
        {
            if (drawInfo.shadow != 0f)
            {
                return;
            }
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModLoader.GetMod("SpiritMod");

            if (drawPlayer.active && !drawPlayer.outOfRange)
            {
                Texture2D texture = mod.GetTexture("Effects/PlayerVisuals/BubbleShield_Visual");
                Vector2 drawPos = drawPlayer.position + new Vector2(drawPlayer.width * 0.5F, drawPlayer.height * 0.5F);
                drawPos.X = (int)drawPos.X; drawPos.Y = (int)drawPos.Y;
                Vector2 origin = new Vector2(texture.Width * 0.5F, texture.Height * 0.5F);
                DrawData drawData = new DrawData(texture, drawPos - Main.screenPosition, new Rectangle?(), Color.White * 0.75F, 0, origin, 1, SpriteEffects.None, 0);
                Main.playerDrawData.Add(drawData);
            }
        });
        #endregion
    }
}
