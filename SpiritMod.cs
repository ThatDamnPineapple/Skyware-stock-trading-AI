using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Initializers;
using Terraria.IO;
using Terraria.GameContent;
using Terraria.ModLoader;
using SpiritMod.NPCs.Boss.Overseer;
using SpiritMod.NPCs.Boss.Atlas;

namespace SpiritMod
{
    class SpiritMod : Mod
    { 
        public static int customEvent;
        public const string customEventName = "The Tide";
        public static ModHotKey SpecialKey;
        public static ModHotKey GoreKey;
        public static ModHotKey IchorKey;
        public static ModHotKey ReachKey;
        public static ModHotKey WraithKey;
        public static ModHotKey HolyKey;
        public static ModHotKey DepthKey;

        public SpiritMod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true,
                AutoloadBackgrounds = true
            };
        }

        public override void Load()

        {
            {
                InvasionHandler.Reset();
                InvasionHandler.AddInvasion(out SpiritMod.customEvent, new InvasionInfo(customEventName,
                       "The depths are stirring!", "The Tide has waned!",
                   delegate ()
                   {
                       int amountOfPlayers = 0;
                       int maxAmountOfPlayers = 6;
                       for (int i = 0; i < 255; ++i)
                       {
                           if (Main.player[i].active && Main.player[i].statLifeMax >= 400)
                           {
                               amountOfPlayers++;
                               if (amountOfPlayers == maxAmountOfPlayers)
                                   break;
                           }
                       }

                       if (amountOfPlayers > 0)
                       {
                           InvasionWorld.invasionSize = 120 + (30 * amountOfPlayers);
                           InvasionWorld.invasionX = Main.spawnTileX;
                       }
                       return false;

                   }));
            }

            SpecialKey = RegisterHotKey("Cosmic Wrath", "Q");
            ReachKey = RegisterHotKey("Frenzy Plant", "E");
            GoreKey = RegisterHotKey("Ichor Rage", "R");
            IchorKey = RegisterHotKey("Ichor Guard", "F");
            WraithKey = RegisterHotKey("Wraith", "X");
            HolyKey = RegisterHotKey("Holy Ward", "Z");
            DepthKey = RegisterHotKey("Shark Attack", "D");
            if (!Main.dedServ)
            {
                Filters.Scene["SpiritMod:Overseer"] = new Filter(new SeerScreenShaderData("FilterMiniTower").UseColor(0f, 0.3f, 1f).UseOpacity(0.75f), EffectPriority.VeryHigh);
                SkyManager.Instance["SpiritMod:Overseer"] = new SeerSky();
                Filters.Scene["SpiritMod:IlluminantMaster"] = new Filter(new SeerScreenShaderData("FilterMiniTower").UseColor(1.2f, 0.1f, 1f).UseOpacity(0.75f), EffectPriority.VeryHigh);
                SkyManager.Instance["SpiritMod:IlluminantMasterr"] = new SeerSky();
                Filters.Scene["SpiritMod:Atlas"] = new Filter(new AtlasScreenShaderData("FilterMiniTower").UseColor(0.5f, 0.5f, 0.5f).UseOpacity(0.6f), EffectPriority.VeryHigh);
                SkyManager.Instance["SpiritMod:Atlas"] = new AtlasSky();
            }
        }
        public override void UpdateMusic(ref int music)
        {
            int[] NoOverride = {MusicID.Boss1, MusicID.Boss2, MusicID.Boss3, MusicID.Boss4, MusicID.Boss5,
                MusicID.LunarBoss, MusicID.PumpkinMoon, MusicID.TheTowers, MusicID.FrostMoon, MusicID.GoblinInvasion,
                MusicID.PirateInvasion, GetSoundSlot(SoundType.Music, "Sounds/Music/Overseer")};

            bool playMusic = true;
            foreach (int n in NoOverride)
            {
                if (music == n) playMusic = false;
            }
            if (Main.myPlayer != -1 && !Main.gameMenu)
            {
            }
            if (Main.player[Main.myPlayer].active && NPC.downedMechBossAny && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this).ZoneSpirit && (Main.player[Main.myPlayer].position.Y / 16) < WorldGen.rockLayer && playMusic && !Main.gameMenu)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/SpiritOverworld");
            }
            if (Main.player[Main.myPlayer].active && NPC.downedMechBossAny && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this).ZoneSpirit && (Main.player[Main.myPlayer].position.Y / 16) >= WorldGen.rockLayer && playMusic && !Main.gameMenu)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/SpiritUnderground");
            }
            if (InvasionWorld.invasionType == SpiritMod.customEvent)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/DepthInvasion");
            }
            if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this).ZoneReach && playMusic && !Main.dayTime && !Main.gameMenu)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Reach");
            }
        }

        public override void PostSetupContent()
        {
            {
                Mod bossChecklist = ModLoader.GetMod("BossChecklist");
                if (bossChecklist != null)
                {
                    // 14 is moolord, 12 is duke fishron
                    bossChecklist.Call("AddBossWithInfo", "Scarabeus", 0.8f, (Func<bool>)(() => MyWorld.downedScarabeus), "Use a [i:" + ItemType("ScarabIdol") + "] in the Desert biome at any time");
                    bossChecklist.Call("AddBossWithInfo", "Ancient Flier", 4.2f, (Func<bool>)(() => MyWorld.downedAncientFlier), "Use a [i:" + ItemType("JewelCrown") + "] in the sky at any time");
                    bossChecklist.Call("AddBossWithInfo", "Starplate Raider", 5.2f, (Func<bool>)(() => MyWorld.downedRaider), "Use a [i:" + ItemType("StarWormSummon") + "] at nighttime");
                    bossChecklist.Call("AddBossWithInfo", "Infernon", 6.5f, (Func<bool>)(() => MyWorld.downedInfernon), "Use [i:" + ItemType("CursedCloth") + "] in the underworld at any time");
                    bossChecklist.Call("AddBossWithInfo", "Vinewrath Bane", 6.7f, (Func<bool>)(() => MyWorld.downedReachBoss), "Use a [i:" + ItemType("ReachBossSummon") + "] in the Reach at any time");
                    bossChecklist.Call("AddBossWithInfo", "Dusking", 7.3f, (Func<bool>)(() => MyWorld.downedDusking), "Use a [i:" + ItemType("DuskCrown") + "] at nighttime");
                    bossChecklist.Call("AddBossWithInfo", "Illuminant Master", 9.9f, (Func<bool>)(() => MyWorld.downedIlluminantMaster), "Use [i:" + ItemType("ChaosFire") + "] in the Hallowed Biome at Nighttime");
                    bossChecklist.Call("AddBossWithInfo", "Atlas", 12.4f, (Func<bool>)(() => MyWorld.downedAtlas), "Use a [i:" + ItemType("StoneSkin") + "] at any time");
                    bossChecklist.Call("AddBossWithInfo", "Overseer", 14.2f, (Func<bool>)(() => MyWorld.downedOverseer), "Use a [i:" + ItemType("SpiritIdol") + "] at the Spirit Biome during nighttime");
                }
            }
            {

                LoadReferences();
                Item ccoutfit = new Item();
                ccoutfit.SetDefaults(ItemType("CandyCopterOutfit"));
                Mounts.CandyCopter._outfit = ccoutfit.legSlot;
            }
        }

		/// <summary>
		/// Scans all classes deriving from any Mod type
		/// for a field called _ref
		/// and populates it, if it exists.
		/// </summary>
		private void LoadReferences()
		{
			foreach (Type type in Code.GetTypes())
			{
				if (type.IsAbstract)
				{
					continue;
				}

				System.Reflection.FieldInfo field = type.GetField("_ref");
				if (field == null || !field.IsStatic)
				{
					continue;
				}

				if (type.IsSubclassOf(typeof(ModItem)))
				{
					if (field.FieldType == typeof(ModItem))
					{
						field.SetValue(null, GetItem(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModNPC)))
				{
					if (field.FieldType == typeof(ModNPC))
					{
						field.SetValue(null, GetNPC(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModProjectile)))
				{
					if (field.FieldType == typeof(ModProjectile))
					{
						field.SetValue(null, GetProjectile(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModDust)))
				{
					if (field.FieldType == typeof(ModDust))
					{
						field.SetValue(null, GetDust(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModTile)))
				{
					if (field.FieldType == typeof(ModTile))
					{
						field.SetValue(null, GetTile(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModWall)))
				{
					if (field.FieldType == typeof(ModWall))
					{
						field.SetValue(null, GetWall(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModBuff)))
				{
					if (field.FieldType == typeof(ModBuff))
					{
						field.SetValue(null, GetBuff(type.Name));
					}
				} else if (type.IsSubclassOf(typeof(ModMountData)))
				{
					if (field.FieldType == typeof(ModMountData))
					{
						field.SetValue(null, GetMount(type.Name));
					}
				}
			}
		}

 

        public override void HotKeyPressed(string name)
        {
            if(name == "Concentration_Hotkey")
            {
                MyPlayer mp = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this);
                if(mp.leatherSet && !mp.concentrated && mp.concentratedCooldown <= 0)
                {
                    mp.concentrated = true;
                }
            }
        }

          public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            if (InvasionWorld.invasionType <= 0 || InvasionWorld.invasionProgress == -1)
                return;

            if (InvasionHandler.currentInvasion == null || InvasionHandler.currentInvasion != InvasionHandler.GetInvasionInfo(InvasionWorld.invasionType))
            {
                InvasionHandler.currentInvasion = InvasionHandler.GetInvasionInfo(InvasionWorld.invasionType);
                if (Main.netMode == 0)
                {
                    Main.NewText(InvasionHandler.currentInvasion.beginMessage, 175, 75, 255, false);
                    return;
                }
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(25, -1, -1, null, 255, 175f, 75f, 255f, 0, 0, 0);
                }
            }

            if (!Main.gamePaused && InvasionHandler.invasionProgressDisplayLeft > 0)
            {
                InvasionHandler.invasionProgressDisplayLeft--;
            }
            if (InvasionHandler.invasionProgressDisplayLeft > 0)
            {
                InvasionHandler.invasionProgressAlpha += 0.05f;
            }
            else
            {
                InvasionHandler.invasionProgressAlpha -= 0.05f;
            }
            if (InvasionHandler.invasionProgressAlpha < 0f)
            {
                InvasionHandler.invasionProgressAlpha = 0f;
            }
            if (InvasionHandler.invasionProgressAlpha > 1f)
            {
                InvasionHandler.invasionProgressAlpha = 1f;
            }
            if (InvasionHandler.invasionProgressAlpha > 0)
            {
                float num = 0.5f + InvasionHandler.invasionProgressAlpha * 0.5f;

                string text = InvasionHandler.currentInvasion.name;
                Color c = new Color(64, 109, 164) * 0.5f;

                int num7 = (int)(200f * num);
                int num8 = (int)(45f * num);
                Vector2 vector3 = new Vector2((float)(Main.screenWidth - 120), (float)(Main.screenHeight - 40));
                Rectangle r2 = new Rectangle((int)vector3.X - num7 / 2, (int)vector3.Y - num8 / 2, num7, num8);
                Utils.DrawInvBG(spriteBatch, r2, new Color(63, 65, 151, 255) * 0.785f);
                string text3;
                if (InvasionWorld.invasionProgressMax == 0)
                {
                    text3 = InvasionWorld.invasionProgress.ToString();
                }
                else
                {
                    text3 = ((int)((float)InvasionWorld.invasionProgress * 100f / (float)InvasionWorld.invasionProgressMax)).ToString() + "%";
                }
                text3 = "Cleared " + text3;
                Texture2D texture2D4 = Main.colorBarTexture;
                Texture2D texture2D5 = Main.colorBlipTexture;
                if (InvasionWorld.invasionProgressMax != 0)
                {
                    spriteBatch.Draw(texture2D4, vector3, null, Color.White * InvasionHandler.invasionProgressAlpha, 0f, new Vector2((float)(texture2D4.Width / 2), 0f), num, SpriteEffects.None, 0f);
                    float num9 = MathHelper.Clamp((float)InvasionWorld.invasionProgress / (float)InvasionWorld.invasionProgressMax, 0f, 1f);
                    float num10 = 169f * num;
                    float num11 = 8f * num;
                    Vector2 vector4 = vector3 + Vector2.UnitY * num11 + Vector2.UnitX * 1f;
                    Utils.DrawBorderString(Main.spriteBatch, text3, vector4, Color.White * InvasionHandler.invasionProgressAlpha, num, 0.5f, 1f, -1);
                    vector4 += Vector2.UnitX * (num9 - 0.5f) * num10;
                    spriteBatch.Draw(Main.magicPixel, vector4, new Rectangle?(new Rectangle(0, 0, 1, 1)), new Color(255, 241, 51) * InvasionHandler.invasionProgressAlpha, 0f, new Vector2(1f, 0.5f), new Vector2(num10 * num9, num11), SpriteEffects.None, 0f);
                    spriteBatch.Draw(Main.magicPixel, vector4, new Rectangle?(new Rectangle(0, 0, 1, 1)), new Color(255, 165, 0, 127) * InvasionHandler.invasionProgressAlpha, 0f, new Vector2(1f, 0.5f), new Vector2(2f, num11), SpriteEffects.None, 0f);
                    spriteBatch.Draw(Main.magicPixel, vector4, new Rectangle?(new Rectangle(0, 0, 1, 1)), Color.Black * InvasionHandler.invasionProgressAlpha, 0f, new Vector2(0f, 0.5f), new Vector2(num10 * (1f - num9), num11), SpriteEffects.None, 0f);
                }
                Vector2 center = new Vector2((Main.screenWidth - 120), (Main.screenHeight - 80));
                Vector2 value = Main.fontItemStack.MeasureString(text);
                Rectangle r3 = Utils.CenteredRectangle(center, (value + new Vector2((float)(20), 10f)) * num);
                Utils.DrawInvBG(Main.spriteBatch, r3, c);
                Utils.DrawBorderString(spriteBatch, text, r3.Right() + Vector2.UnitX * num * -8f, Color.White * InvasionHandler.invasionProgressAlpha, num * 0.9f, 1f, 0.4f, -1);

            }
        }
        const int ShakeLength = 5;
        int ShakeCount = 0;
        float previousRotation = 0;
        float targetRotation = 0;
        float previousOffsetX = 0;
        float previousOffsetY = 0;
        float targetOffsetX = 0;
        float targetOffsetY = 0;

        public static float shittyModTime;

        public override Matrix ModifyTransformMatrix(Matrix Transform)
        {            
            shittyModTime--;
            if (shittyModTime > 0)
            {
                if (shittyModTime % ShakeLength == 0)
                {
                    ShakeCount = 0;
                    previousRotation = targetRotation;
                    previousOffsetX = targetOffsetX;
                    previousOffsetY = targetOffsetY;
                    targetRotation = (Main.rand.NextFloat() - .5f) * MathHelper.ToRadians(15);
                    targetOffsetX = Main.rand.Next(60) - 30;
                    targetOffsetY = Main.rand.Next(40) - 20;
                    if (shittyModTime == ShakeLength)
                    {
                        targetRotation = 0;
                        targetOffsetX = 0;
                        targetOffsetY = 0;
                    }
                }
                float transX = Main.screenWidth / 2;
                float transY = Main.screenHeight / 2;

                float lerp = (float)(ShakeCount) / ShakeLength;
                float rotation = MathHelper.Lerp(previousRotation, targetRotation, lerp);
                float offsetX = MathHelper.Lerp(previousOffsetX, targetOffsetX, lerp);
                float offsetY = MathHelper.Lerp(previousOffsetY, targetOffsetY, lerp);

                shittyModTime--;
                ShakeCount++;


                return Transform
                    * Matrix.CreateTranslation(-transX, -transY, 0f)
                    * Matrix.CreateRotationZ(rotation)
                    * Matrix.CreateTranslation(transX, transY, 0f)
                    * Matrix.CreateTranslation(offsetX, offsetY, 0f);
                //Matrix.CreateFromAxisAngle(new Vector3(Main.screenWidth / 2, Main.screenHeight / 2, 0f), .2f);
                //Matrix.CreateRotationZ(MathHelper.ToRadians(30));
            }
            return Transform;
        }
    }
}