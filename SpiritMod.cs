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
using System.Linq;
using Terraria.UI;
using Terraria.GameContent.UI;
using SpiritMod.NPCs.Boss.Overseer;
using SpiritMod.NPCs.Boss.Atlas;
using SpiritMod.Tide;

namespace SpiritMod
{
    class SpiritMod : Mod
    {
        internal static SpiritMod instance;
        public static int customEvent;
        public const string customEventName = "The Tide";
        public static ModHotKey SpecialKey;
        public static ModHotKey ReachKey;
        public static ModHotKey HolyKey;
		public static int GlyphCustomCurrencyID;


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
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Gold Bar" + Lang.GetItemNameValue(ItemType("Gold Bar")), new int[]
           {
                19,
                706
           });
            RecipeGroup.RegisterGroup("GoldBars", group);
            group = new RecipeGroup(() => Lang.misc[37] + " Lunar Fragment" + Lang.GetItemNameValue(ItemType("Lunar Fragment")), new int[]
           {
                3456,
                3457,
                3458,
                3459
           });
            RecipeGroup.RegisterGroup("CelestialFragment", group);
            group = new RecipeGroup(() => Lang.misc[37] + " Cursed Flame" + Lang.GetItemNameValue(ItemType("Cursed Flame")), new int[]
           {
                ItemID.Ichor,
                ItemID.CursedFlame
           });
            RecipeGroup.RegisterGroup("EvilMaterial", group);
            group = new RecipeGroup(() => Lang.misc[37] + " Ichor Pendant" + Lang.GetItemNameValue(ItemType("Ichor Pendant")), new int[]
           {
               ItemType("CursedPendant"),
               ItemType("IchorPendant")
           });

            RecipeGroup.RegisterGroup("EvilNecklace", group);
            group = new RecipeGroup(() => Lang.misc[37] + " Shadow Scale" + Lang.GetItemNameValue(ItemType("Shadow Scale")), new int[]
           {
            ItemID.ShadowScale,
            ItemID.TissueSample 
           });

            RecipeGroup.RegisterGroup("EvilMaterial1", group);
            group = new RecipeGroup(() => Lang.misc[37] + " Nightmare Fuel" + Lang.GetItemNameValue(ItemType("Nightmare Fuel")), new int[]
         {
               ItemType("CursedFire"),
               ItemType("NightmareFuel")
         });

            RecipeGroup.RegisterGroup("ModEvil", group);
        }
        public override void Load()

        {
			Filters.Scene["SpiritMod:SpiritSky"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0f, 0.5f, 1f).UseOpacity(0.3f), EffectPriority.High);
						Filters.Scene["SpiritMod:BlueMoonSky"] = new Filter(new ScreenShaderData("FilterMiniTower").UseColor(0f, 0.3f, 1f).UseOpacity(0.75f), EffectPriority.High);
			
            instance = this;
            SpecialKey = RegisterHotKey("Armor Bonus", "Q");
            ReachKey = RegisterHotKey("Frenzy Plant", "E");
            HolyKey = RegisterHotKey("Holy Ward", "Z");
			
				GlyphCustomCurrencyID = CustomCurrencyManager.RegisterCurrency(new Currency(ItemType<Items.Glyph>(), 999L));
		
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
            Mod mod = ModLoader.GetMod("SpiritMod");
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
            if (Main.player[Main.myPlayer].active && NPC.downedMechBossAny && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this).ZoneSpirit && Main.player[Main.myPlayer].ZoneRockLayerHeight && !Main.gameMenu && NPC.CountNPCS(mod.NPCType("SpiritCore")) <= 0 && !Main.player[Main.myPlayer].ZoneDungeon && !Main.gameMenu && NPC.CountNPCS(mod.NPCType("Overseer")) <= 0)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/SpiritUnderground");
            }
            if (Main.player[Main.myPlayer].active && NPC.downedMechBossAny && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this).ZoneSpirit && !Main.player[Main.myPlayer].ZoneRockLayerHeight && !Main.gameMenu && NPC.CountNPCS(mod.NPCType("SpiritCore")) <= 0 && !Main.player[Main.myPlayer].ZoneDungeon && !Main.gameMenu && NPC.CountNPCS(mod.NPCType("Overseer")) <= 0)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/spirit_overworld");
            }
            if (TideWorld.TheTide && TideWorld.InBeach && !Main.gameMenu)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/DepthInvasion");
            }
            if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this).ZoneReach && playMusic && !Main.dayTime && !Main.gameMenu)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/Reach");
            }
			 if (Main.player[Main.myPlayer].active && Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this).ZoneBlueMoon && playMusic && !Main.dayTime && !Main.gameMenu)
            {
                music = this.GetSoundSlot(SoundType.Music, "Sounds/Music/BlueMoon");
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
					 bossChecklist.Call("AddBossWithInfo", "Vinewrath Bane", 3.5f, (Func<bool>)(() => MyWorld.downedReachBoss), "Use a [i:" + ItemType("ReachBossSummon") + "] in the Reach at daytime");
                    bossChecklist.Call("AddBossWithInfo", "Ancient Flier", 4.2f, (Func<bool>)(() => MyWorld.downedAncientFlier), "Use a [i:" + ItemType("JewelCrown") + "] in the sky at any time");
                    bossChecklist.Call("AddBossWithInfo", "Starplate Raider", 5.2f, (Func<bool>)(() => MyWorld.downedRaider), "Use a [i:" + ItemType("StarWormSummon") + "] at nighttime");
                    bossChecklist.Call("AddBossWithInfo", "Infernon", 6.5f, (Func<bool>)(() => MyWorld.downedInfernon), "Use [i:" + ItemType("CursedCloth") + "] in the underworld at any time");
                  
                    bossChecklist.Call("AddBossWithInfo", "Dusking", 7.3f, (Func<bool>)(() => MyWorld.downedDusking), "Use a [i:" + ItemType("DuskCrown") + "] at nighttime");
                    bossChecklist.Call("AddBossWithInfo", "Ethereal Umbra", 7.8f, (Func<bool>)(() => MyWorld.downedSpiritCore), "Use a [i:" + ItemType("UmbraSummon") + "] in the Spirit Biome at nighttime");
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
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            TidePlayer modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<TidePlayer>();
            if (TideWorld.TheTide)
            {
                int index = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
                LegacyGameInterfaceLayer TideThing = new LegacyGameInterfaceLayer("SpiritMod: TideBenis",
                    delegate
                    {
                        DrawTide(Main.spriteBatch);
                        return true;
                    },
                    InterfaceScaleType.UI);
                layers.Insert(index, TideThing);
            }
        }

        public override void HotKeyPressed(string name)
        {
            if (name == "Concentration_Hotkey")
            {
                MyPlayer mp = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>(this);
                if (mp.leatherSet && !mp.concentrated && mp.concentratedCooldown <= 0)
                {
                    mp.concentrated = true;
                }
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
        public void DrawTide(SpriteBatch spriteBatch)
        {
            TidePlayer modPlayer1 = Main.player[Main.myPlayer].GetModPlayer<TidePlayer>();
            if (TideWorld.TheTide && TideWorld.InBeach)
            {

                float alpha = 0.5f;
                Texture2D backGround1 = Main.colorBarTexture;
                Texture2D progressColor = Main.colorBarTexture;
                Texture2D TideIcon = SpiritMod.instance.GetTexture("Effects/InvasionIcons/Depths_Icon");
                float scmp = 0.5f + 0.75f * 0.5f;
                Color descColor = new Color(77, 39, 135);
                Color waveColor = new Color(255, 241, 51);
                Color barrierColor = new Color(255, 241, 51);
                const int offsetX = 20;
                const int offsetY = 20;
                int width = (int)(200f * scmp);
                int height = (int)(46f * scmp);
                Rectangle waveBackground = Utils.CenteredRectangle(new Vector2(Main.screenWidth - offsetX - 100f, Main.screenHeight - offsetY - 23f), new Vector2(width, height));
                Utils.DrawInvBG(spriteBatch, waveBackground, new Color(63, 65, 151, 255) * 0.785f);
                string waveText = "Cleared " + TideWorld.TidePoints2 + "%";
                Utils.DrawBorderString(spriteBatch, waveText, new Vector2(waveBackground.X + waveBackground.Width / 2, waveBackground.Y + 5), Color.White, scmp * 0.8f, 0.5f, -0.1f);
                Rectangle waveProgressBar = Utils.CenteredRectangle(new Vector2(waveBackground.X + waveBackground.Width * 0.5f, waveBackground.Y + waveBackground.Height * 0.75f), new Vector2(progressColor.Width, progressColor.Height));
                Rectangle waveProgressAmount = new Rectangle(0, 0, (int)(progressColor.Width * 0.01f * MathHelper.Clamp(TideWorld.TidePoints2, 0f, 100f)), progressColor.Height);
                Vector2 offset = new Vector2((waveProgressBar.Width - (int)(waveProgressBar.Width * scmp)) * 0.5f, (waveProgressBar.Height - (int)(waveProgressBar.Height * scmp)) * 0.5f);
                spriteBatch.Draw(backGround1, waveProgressBar.Location.ToVector2() + offset, null, Color.White * alpha, 0f, new Vector2(0f), scmp, SpriteEffects.None, 0f);
                spriteBatch.Draw(backGround1, waveProgressBar.Location.ToVector2() + offset, waveProgressAmount, waveColor, 0f, new Vector2(0f), scmp, SpriteEffects.None, 0f);
                const int internalOffset = 6;
                Vector2 descSize = new Vector2(154, 40) * scmp;
                Rectangle barrierBackground = Utils.CenteredRectangle(new Vector2(Main.screenWidth - offsetX - 100f, Main.screenHeight - offsetY - 19f), new Vector2(width, height));
                Rectangle descBackground = Utils.CenteredRectangle(new Vector2(barrierBackground.X + barrierBackground.Width * 0.5f, barrierBackground.Y - internalOffset - descSize.Y * 0.5f), descSize * .8f);
                Utils.DrawInvBG(spriteBatch, descBackground, descColor * alpha);
                int descOffset = (descBackground.Height - (int)(32f * scmp)) / 2;
                Rectangle icon = new Rectangle(descBackground.X + descOffset + 7, descBackground.Y + descOffset, (int)(32 * scmp), (int)(32 * scmp));
                spriteBatch.Draw(TideIcon, icon, Color.White);
                Utils.DrawBorderString(spriteBatch, customEventName, new Vector2(barrierBackground.X + barrierBackground.Width * 0.5f, barrierBackground.Y - internalOffset - descSize.Y * 0.5f), Color.White, 0.8f, 0.3f, 0.4f);
            }
        }
    }
}