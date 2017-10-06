using System;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.Tide;
using SpiritMod.Items.Glyphs;
using SpiritMod.NPCs.Town;

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
		public bool spectre = false;
		public bool soulBurn = false;
		public bool Stopped = false;
		public bool SoulFlare = false;
		public bool afflicted = false;
		public bool sunBurn = false;
		public bool starDestiny = false;
		public bool Death = false;
		public bool iceCrush = false;
		public bool pestilence = false;
		public bool moonBurn = false;
		public bool holyBurn = false;

		public bool DoomDestiny = false;

		public bool DoomDestiny1 = false;


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
			Stopped = false;
			soulBurn = false;
			necrosis = false;
			moonBurn = false;
			sunBurn = false;
			blaze = false;
			iceCrush = false;
			blaze1 = false;
			felBrand = false;
			spectre = false;
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

				if (Stopped)
				{
					if (!npc.boss)
					{
						npc.velocity *= 0;
						npc.frame.Y = 0;
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
				npc.lifeRegen += (int)Math.Sqrt(npc.lifeMax - npc.life) / 2 + 1;
			}
		}

		public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (npc.type == mod.NPCType("Overseer"))
			{
				if (projectile.type == 632)
				{
					damage /= 3;
				}
			}
			if (npc.type == mod.NPCType("SteamRaiderBody"))
			{
				if (projectile.penetrate <= -1)
				{
					damage /= 3;
				}
				else if (projectile.penetrate >= 7)
				{
					damage /= 3;
				}


			}
			if (npc.type == mod.NPCType("CogTrapperBody"))
			{
				if (projectile.penetrate <= -1)
				{
					damage /= 3;
				}
				else if (projectile.penetrate >= 7)
				{
					damage /= 3;
				}

			}
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			#region Iriazul
			if (fireStacks > 0)
			{
				if (npc.FindBuffIndex(mod.BuffType("StackingFireBuff")) < 0)
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
				if (npc.FindBuffIndex(mod.BuffType("NebulaFlame")) < 0)
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
				if (npc.FindBuffIndex(mod.BuffType("AmberFracture")) < 0)
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
			if (sFracture)
			{
				npc.lifeRegen = 0;
				npc.lifeRegen -= 9;
				damage = 3;
			}
			if (DoomDestiny1)
			{
				npc.lifeRegen = 0;
				npc.lifeRegen -= 30;
				damage = 10;
			}
			if (soulBurn)
			{
				npc.lifeRegen = 0;
				npc.lifeRegen -= 15;
				damage = 5;
			}
			if (afflicted)
			{
				npc.lifeRegen = 0;
				npc.lifeRegen -= 20;
				damage = 20;
			}
			if (iceCrush)
			{
				if (!npc.boss)
				{
					npc.lifeRegen = 0;
					float def = 2 + (npc.lifeMax / (npc.life * 1.5f));
					npc.lifeRegen -= (int)def;
					npc.damage = (int)def;
				}
				else if (npc.boss || npc.type == NPCID.DungeonGuardian)
				{
					npc.lifeRegen = 0;
					npc.lifeRegen -= 6;
					npc.damage = 3;
				}
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
				npc.lifeRegen -= 30;
				damage = 10;
			}
			if (spectre)
			{
				npc.lifeRegen = 0;
				npc.lifeRegen -= 20;
				damage = 5;
			}
			if (moonBurn)
			{
				npc.lifeRegen = 0;
				npc.lifeRegen -= 10;
				damage = 6;
			}
			if (sunBurn)
			{
				npc.lifeRegen = 0;
				npc.lifeRegen -= 6;
				damage = 3;
			}
			if (necrosis)
			{
				MyPlayer mp = Main.player[npc.target].GetModPlayer<MyPlayer>(mod);
				if (mp.KingSlayerFlask)
				{
					npc.lifeRegen = 0;
					npc.lifeRegen -= 36;
					damage = 12;
				}
				else
				{
					npc.lifeRegen = 0;
					npc.lifeRegen -= 30;
					damage = 10;
				}
			}
			if (holyBurn)
			{
				npc.lifeRegen = 0;
				npc.lifeRegen -= 25;
				damage = 3;
			}
			if (pestilence)
			{
				MyPlayer mp = Main.player[npc.target].GetModPlayer<MyPlayer>(mod);
				if (mp.KingSlayerFlask)
				{
					npc.lifeRegen = 0;
					npc.lifeRegen -= 5;
					damage = 3;
				}
				else
				{
					npc.lifeRegen = 0;
					npc.lifeRegen -= 3;
					damage = 3;
				}
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

		public override void GetChat(NPC npc, ref string chat)
		{
			Player player = Main.player[Main.myPlayer];
			MyPlayer modPlayer = Main.player[Main.myPlayer].GetModPlayer<MyPlayer>();
			if (/*Main.halloween &&*/ !Main.dayTime && modPlayer.canTrickOrTreat(npc))
			{
				chat = TrickOrTeat(modPlayer, npc);
				Items._ItemUtils.DropCandy(player);
				return;
			}

		}

		internal string TrickOrTeat(MyPlayer player, NPC npc)
		{
			int dialogue = Main.rand.Next(2);
			switch (npc.type)
			{
				case NPCID.Merchant:
					if (dialogue == 0)
						return "Oh, here's some candy. You have no idea how hard it was to get this.";
					else
						return "I can be greedy, but I like to be festive. Here you go!";
				case NPCID.Nurse:
					if (dialogue == 0)
						return "Oh here, kiddo. Make sure there aren't any razorblades in there!";
					else
						return "It may not be the healithiest option, but candy is pretty nice. Take some.";
				case NPCID.ArmsDealer:
					if (dialogue == 0)
						return "Test " + npc.TypeName;
					else
						return "Test " + npc.TypeName;
				case NPCID.Dryad:
					if (dialogue == 0)
						return "Do you have any idea what's in that candy? Here, this stuff is much better for you. I made it myself.";
					else
						return "Is it that time of year again? Time flies by so fast when you are as old as I am... Oh, here, have some candy.";
				case (NPCID.Guide):
					if (dialogue == 0)
						return "Here. You may collect one piece of candy a night from every villager during halloween.";
					else
						return "Of course. Candy can be used during any season, to get special effects.";
				case NPCID.Demolitionist:
					if (dialogue == 0)
						return "I was making a sugar rocket, and this was left over. Do you want some?";
					else
						return "Aye, this candy may or may not have explosives in it, I don't remember.";
				case NPCID.Clothier:
					if (dialogue == 0)
						return "My mama always told me candy was like life. Or was it a box? ... er, something like that. Here, take a piece.";
					else
						return "Test " + npc.TypeName;
				case NPCID.GoblinTinkerer:
					if (dialogue == 0)
						return "I tried combining rocket boots and candy, but it didn't really work out. You want what's left?";
					else
						return "Test " + npc.TypeName;
				case NPCID.Wizard:
					if (dialogue == 0)
						return "I'm pretty sure this isn't enchanted candy, but I could make some if you want! No? Ok...";
					else
						return "I have some candy for you, but I could enchant it if you would li... No? Ok.";
				case NPCID.Mechanic:
					if (dialogue == 0)
						return "Don't mind the hydraulic fluid on the candy. In fact, consider it extra flavor.";
					else
						return "Test " + npc.TypeName;
				case NPCID.SantaClaus:
					if (dialogue == 0)
						return "Something ain't right. This feels all wrong";
					else
						return "Test " + npc.TypeName;
				case NPCID.Truffle:
					if (dialogue == 0)
						return "Is this candy vegan? Of course not, you sicko!";
					else
						return "<Nurse> wanted some of these for her supply. I wonder what that was about?";
				case NPCID.Steampunker:
					if (dialogue == 0)
						return "Test " + npc.TypeName;
					else
						return "Test " + npc.TypeName;
				case NPCID.DyeTrader:
					if (dialogue == 0)
						return "I put some special dyes in this sweet. It will make your tongue turn brilliant colors!";
					else
						return "It isn't about how it tastes... It's about how rich the colors look. Take a piece, why don't you?";
				case NPCID.PartyGirl:
					if (dialogue == 0)
						return "I love this time of year, where people give out free candy! Here, have a piece!";
					else
						return "Test " + npc.TypeName;
				case NPCID.Cyborg:
					if (dialogue == 0)
						return "My calendar programming has exacted it is approximately Halloween; enjoy your sucrose based food!";
					else
						return "Test " + npc.TypeName;
				case NPCID.Painter:
					if (dialogue == 0)
						return "I might've dripped a little paint on this candy, but it's probably lead-free. Hopefully.";
					else
						return "Test " + npc.TypeName;
				case NPCID.WitchDoctor:
					if (dialogue == 0)
						return "I decided not to give you lemon heads; or should I say: lemon-flavored heads, enjoy!";
					else
						return "Beware, "+ player.player.name +", for it is the season of ghouls and spirits. This edible talisman will protect you.";
				case NPCID.Pirate:
					if (dialogue == 0)
						return "Yo ho ho and a bottle of... candy. Take some!";
					else
						return "This candy cost me an arm and a leg, you enjoy that now or its to the plank with ye!";
				case NPCID.Stylist:
					if (dialogue == 0)
						return "I usually save these for after haircuts, but go ahead and take a piece, darling.";
					else
						return "Test " + npc.TypeName;
				case NPCID.TravellingMerchant:
					if (dialogue == 0)
						return "I have rare candies from all over <Worldname>. Here, take some.";
					else
						return "Test " + npc.TypeName;
				case NPCID.Angler:
					if ((dialogue = Main.rand.Next(3)) == 0)
						return "What? You want some of MY candy? I think I have some ichorice here somewhere...";
					else if (dialogue == 1)
						return "This one came out of a fish. Here, you have it, I don't want it";
					else
						return "Dude, you don't ask a kid for candy. You just don't.";
				case NPCID.TaxCollector:
					if ((dialogue = Main.rand.Next(3)) == 0)
						return "Halloween? Bah humbug. Take your candy and get outta here!";
					else if (dialogue == 1)
						return "You come to my door to take my sweets? Well go on then, take 'em!";
					else
						return "Here, have this. It's the cheapest brand I could find.";
				case NPCID.SkeletonMerchant:
					if (dialogue == 0)
						return "I'm feeling happy, it's my people's season! Take some candy!";
					else
						return "Test " + npc.TypeName;
				case NPCID.DD2Bartender:
					if (dialogue == 0)
						return "I managed to find some ale-flavored candy! Maybe this world ain't so bad after all.";
					else
						return "Test " + npc.TypeName;
			}
			if (npc.type == Adventurer._type)
			{
				if (dialogue == 0)
					return "You wouldn't believe me, when I tell you I got this from a faraway kingdom made of CANDY! I promise it has an exquisite taste.";
				else
					return "Test " + npc.TypeName;
			}
			else if (npc.type == LoneTrapper._type)
			{
				if (dialogue == 0)
					return "The only thing that makes me forget my suffering is candy, I suppose you can have some.";
				else
					return "Candy helps fill the aching void where my sould used to be. Maybe it can help you too.";
			}
			else if (npc.type == Lunatic._type)
			{
				if (dialogue == 0)
					return "When I served beside the Moon Lord I was offered tempting powers, but none were more tempting than this piece of candy.";
				else
					return "Test " + npc.TypeName;
			}
			else if (npc.type == Martian._type)
			{
				if (dialogue == 0)
					return "Test " + npc.TypeName;
				else
					return "Test " + npc.TypeName;
			}
			else if (npc.type == Rogue._type)
			{
				if (dialogue == 0)
					return "Test " + npc.TypeName;
				else
					return "Test " + npc.TypeName;
			}
			else if (npc.type == RuneWizard._type)
			{
				if (dialogue == 0)
					return "Test " + npc.TypeName;
				else
					return "Test " + npc.TypeName;
			}
			if (dialogue == 0)
				return "Hello, " + player.player.name + ". Take some candy!";
			else
				return "Here. I got some candy for you.";
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
				if (Main.halloween)
				{
					shop.item[nextSlot].SetDefaults(base.mod.ItemType("CandyBowl"), false);
					nextSlot++;
				}
			}
			if (type == 20)
			{
				shop.item[nextSlot].SetDefaults(base.mod.ItemType("Dryad"), false);
				nextSlot++;
			}
			if (type == 54)
			{
				shop.item[nextSlot].SetDefaults(410, false);
				shop.item[nextSlot].value = 200000;
				nextSlot++;
				shop.item[nextSlot].SetDefaults(411, false);
				shop.item[nextSlot].value = 200000;
				nextSlot++;
			}
			if (type == NPCID.PartyGirl)
			{
				if (NPC.downedMechBossAny)
				{
					shop.item[nextSlot].SetDefaults(mod.ItemType("PartyStarter"), false);
					nextSlot++;
					shop.item[nextSlot].SetDefaults(mod.ItemType("SpiritPainting"), false);
					nextSlot++;
				}
			}

			if (type == 178)
			{
				shop.item[nextSlot].SetDefaults(base.mod.ItemType("Cog"), false);
				nextSlot++;
			}
		}

		public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
		{
			if (TideWorld.TheTide && TideWorld.InBeach)
			{
				maxSpawns = (int)(maxSpawns * 3f);
				spawnRate = (int)(spawnRate * 0.23f);
			}
			if (MyWorld.BlueMoon)
			{
				maxSpawns = (int)(maxSpawns * 2f);
				spawnRate = (int)(spawnRate * 0.19f);
			}

		}

		//public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
		//{
		//	for (int k = 0; k < 255; k++)
		//	{
		//		Player player = Main.player[k];
		//		if (player.GetModPlayer<MyPlayer>(mod).ZoneReach && !(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust))
		//		{
		//			pool.Add(mod.NPCType("Reachman"), 4f);
		//		}
		//		else if (player.GetModPlayer<MyPlayer>(mod).ZoneReach && !(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust || !Main.dayTime))
		//		{
		//			pool.Add(mod.NPCType("GroveCaster"), 0.6f);
		//			pool.Add(mod.NPCType("GrassVine"), 1.8f);
		//			pool.Add(mod.NPCType("ReachObserver"), 2f);
		//		}
		//		else if (player.GetModPlayer<MyPlayer>(mod).ZoneReach && !(player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula || player.ZoneTowerStardust || NPC.downedBoss2 || !Main.dayTime))
		//		{
		//			pool.Add(mod.NPCType("Mycoid"), 0.4f);
		//		}
		//	}
		//}

		public override bool PreNPCLoot(NPC npc)
		{
			if (npc.type == mod.NPCType("Scarabeus"))
			{
				MyWorld.downedScarabeus = true;
			}
			if (npc.type == mod.NPCType("ReachBoss1"))
			{
				MyWorld.downedReachBoss = true;
			}
			if (npc.type == mod.NPCType("AncientFlyer"))
			{
				MyWorld.downedAncientFlier = true;
			}
			if (npc.type == mod.NPCType("SteamRaiderHead"))
			{
				MyWorld.downedRaider = true;
			}
			if (npc.type == mod.NPCType("Infernon"))
			{
				MyWorld.downedInfernon = true;
			}
			if (npc.type == mod.NPCType("Dusking"))
			{
				MyWorld.downedDusking = true;
			}
			if (npc.type == mod.NPCType("IlluminantMaster"))
			{
				MyWorld.downedIlluminantMaster = true;
			}
			if (npc.type == mod.NPCType("SpiritCore"))
			{
				MyWorld.downedSpiritCore = true;
			}
			if (npc.type == mod.NPCType("Atlas"))
			{
				MyWorld.downedAtlas = true;
			}
			if (npc.type == mod.NPCType("Overseer"))
			{
				MyWorld.downedOverseer = true;
			}
			return true;
		}

		private int GlyphsHeldBy(NPC boss)
		{
			if (boss.type == NPCID.KingSlime || boss.type == Boss.Scarabeus.Scarabeus._type)
				return 1;

			if (boss.type == NPCID.QueenBee || boss.type == NPCID.SkeletronHead ||
					boss.type == Boss.AncientFlyer._type || boss.type == Boss.SteamRaider.SteamRaiderHead._type)
				return 3;

			if (boss.type == NPCID.WallofFlesh)
				return 5;

			if (boss.type == NPCID.TheDestroyer || boss.type == Boss.Infernon.Infernon._type || boss.type == Boss.Infernon.InfernoSkull._type ||
					boss.type == NPCID.SkeletronPrime || boss.type == Boss.Dusking.Dusking._type || boss.type == Boss.SpiritCore.SpiritCore._type)
				return 4;

			if (boss.type == NPCID.Plantera || boss.type == NPCID.Golem || boss.type == NPCID.DukeFishron || boss.type == NPCID.CultistBoss ||
					boss.type == Boss.IlluminantMaster.IlluminantMaster._type || boss.type == Boss.Atlas.Atlas._type || boss.type == Boss.Overseer.Overseer._type)
				return 5;

			if (boss.type == NPCID.MoonLordCore)
				return 8;

			return 2;
		}

		public override void NPCLoot(NPC npc)
		{
			#region Glyph
			if (npc.boss && (npc.modNPC == null || npc.modNPC.bossBag > 0))
			{
				string name;
				if (npc.modNPC != null)
					name = npc.modNPC.mod.Name + ":" + npc.modNPC.GetType().Name;
				else
					name = "Terraria:" + npc.TypeName;

				bool droppedGlyphs = false;
				MyWorld.droppedGlyphs.TryGetValue(name, out droppedGlyphs);
				if (!droppedGlyphs)
				{
					int glyphs = GlyphsHeldBy(npc);
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Glyph._type, glyphs * Main.ActivePlayersCount);
					MyWorld.droppedGlyphs[name] = true;
				}
			}
			else if (!npc.SpawnedFromStatue && Main.rand.Next(750) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Glyph._type);
			}
			#endregion

			#region Artifact
			if (Main.rand.Next(13) == 1 && !npc.SpawnedFromStatue)
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
				if (NPC.downedMechBossAny && Main.rand.Next(Main.expertMode ? 400 : 550) < 2)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RootPod"));
				}
			}
			if (npc.type == mod.NPCType("ReachBoss1"))
			{
				if (Main.rand.Next(Main.expertMode ? 73 : 90) < 3)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RootPod"));
				}
			}
			if (npc.type == mod.NPCType("Scarabeus"))
			{
				if (Main.rand.Next(Main.expertMode ? 73 : 90) < 10)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("GildedIdol"));
				}
			}
			if (npc.type == NPCID.EyeofCthulhu)
			{
				if (Main.rand.Next(Main.expertMode ? 73 : 90) < 10)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DemonLens"));
				}
			}
			if (npc.type == NPCID.IceSlime || npc.type == NPCID.IceBat || npc.type == NPCID.UndeadViking)
			{
				if (Main.rand.Next(Main.expertMode ? 200 : 250) < 3)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FrostLotus"));
				}
			}
			if (npc.type == NPCID.GoblinSorcerer)
			{
				if (Main.rand.Next(Main.expertMode ? 80 : 100) < 7)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosEmber"));
				}
			}
			if (npc.type == NPCID.Tim)
			{
				if (Main.rand.Next(Main.expertMode ? 80 : 90) < 10)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosEmber"));
				}
			}
			if (npc.type == NPCID.FireImp || npc.type == NPCID.Demon)
			{
				if (Main.rand.Next(Main.expertMode ? 175 : 225) < 3)
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
				if (Main.rand.Next(Main.expertMode ? 80 : 90) < 11)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StellarTech"));
				}
			}
			if (npc.type == mod.NPCType("Infernon"))
			{
				if (Main.rand.Next(Main.expertMode ? 73 : 85) < 10)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SearingBand"));
				}
			}
			if (npc.type == mod.NPCType("Dusking"))
			{
				if (Main.rand.Next(Main.expertMode ? 73 : 85) < 10)
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
				if (Main.rand.Next(Main.expertMode ? 95 : 105) < 15)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BatteryCore"));
				}
			}
			if (npc.type == NPCID.Plantera)
			{
				if (Main.rand.Next(Main.expertMode ? 95 : 105) < 11)
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
				if (Main.rand.Next(Main.expertMode ? 80 : 90) < 10)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("RadiantEmblem"));
				}
			}
			if (npc.type == mod.NPCType("Atlas"))
			{
				if (Main.rand.Next(Main.expertMode ? 80 : 90) < 10)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("UnrefinedRuneStone"));
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
				int cultistDrop = Main.rand.Next(4);
				if (cultistDrop == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StardustEmblem"));
				}
				else if (cultistDrop == 1)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("VortexEmblem"));
				}
				else if (cultistDrop == 2)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SolarEmblem"));
				}
				else if (cultistDrop == 3)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("NebulaEmblem"));
				}
			}
			if (npc.type == NPCID.DungeonSpirit && Main.rand.Next(20) == 0)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DungeonSpirit"), Main.rand.Next(2) + 1);
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
			if (npc.type == 48 && Main.rand.Next(4) == 0 && NPC.downedQueenBee)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Talon"), Main.rand.Next(2) + 2);
			}
			if (npc.type == NPCID.Tim)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TimScroll"));
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
			if (npc.type == NPCID.WallofFlesh && Main.rand.Next(3) >= 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BallOfFlesh"));
			}
			if (npc.type == NPCID.DD2DrakinT2 && Main.rand.Next(25) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DrakinTeeth"));
			}
			if (npc.type == NPCID.WalkingAntlion && Main.rand.Next(50) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AntlionIdol"));
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
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PirateCrate"));
				if (Main.rand.Next(100) <= 6)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SoulSiphon"));
				}
			}
			if (npc.type == 398)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AccursedRelic"), Main.rand.Next(3, 6));
			}
			if (npc.type == 213 && Main.rand.Next(50) <= 8)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThrownCutlass"), Main.rand.Next(11, 17));
			}
			if (npc.type == 471)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameKnife"), Main.rand.Next(57, 87));
			}
			if (npc.type == NPCID.DD2Betsy)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DragonGrenade"), Main.rand.Next(90, 240));
			}
			if (npc.type == NPCID.DeadlySphere && Main.rand.Next(10) <= 7.3f)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DeadlySphere"), Main.rand.Next(8, 15));
			}
			if (npc.type == 409 && Main.rand.Next(40) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarlightStaff"));
			}
			if (npc.type == 383 && Main.rand.Next(23) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SaucerBeacon"));
			}
			if (npc.type == 39 && Main.rand.Next(16) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BoneFlail"));
			}
			if (npc.type == 199 && Main.rand.Next(500) == 1 || npc.type == 198 && Main.rand.Next(500) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SnakeStaff"));
			}
			if (npc.type == 477 && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				int dropCheck = Main.rand.Next(5);
				if (dropCheck == 0)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenStaff"));
				else if (dropCheck == 1)
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BrokenParts"));
			}
			if (npc.type == 543 && Main.rand.Next(33) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Thresher"));
			}
			if (npc.type == 32 && Main.rand.Next(30) == 1)
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
			if ((npc.type == NPCID.ZombieEskimo || npc.type == NPCID.IceBat) && Main.rand.Next(33) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThrallGate"));
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
			if (Main.hardMode && NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3 && npc.lifeMax > 99)
			{
				int chance = npc.FindBuffIndex(mod.BuffType("EssenceTrap")) > -1 ? 4 : 8;
				if (Main.rand.Next(chance) == 0)
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
			#endregion

			//Vanilla NPCs
			if (npc.type == NPCID.ElfCopter && Main.rand.Next(Main.expertMode ? 25 : 50) < 3)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CandyRotor"));

			if (npc.type == NPCID.QueenBee && Main.rand.Next(Main.expertMode ? 10 : 20) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SweetThrow"));


			//Zone dependant
			if (closest.ZoneHoly && Main.rand.Next(200) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Mystic"), 1);

			if (closest.ZoneJungle && NPC.downedPlantBoss && npc.type != NPCID.Bee && Main.rand.Next(200) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Chaparral"), 1);

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
			if (npc.type == NPCID.EyeofCthulhu && Main.rand.Next(5) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Eyeshot"));

			if (npc.type == NPCID.BloodZombie && Main.rand.Next(25) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BZombieArm"));

			if (npc.type == 508 && Main.rand.Next(60) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AntlionClaws"));

			if (npc.type == 392 && Main.rand.Next(2) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Martian"));

			if (npc.type == NPCID.AnglerFish && Main.rand.Next(30) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Angelure"));

			if (npc.type == NPCID.ChaosElemental && Main.rand.Next(24) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Crystal"));

			if (npc.type == 6 && Main.rand.Next(40) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PMicrobe"));

			if (npc.type == 439)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ancient"));

			if (npc.type == 417 && Main.rand.Next(40) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Srollerang"));

			if (npc.type == 166 && Main.rand.Next(28) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Murk"));

			if (npc.type == 290 && Main.rand.Next(25) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EnchantedPaladinsHammerStaff"));

			if (npc.type == 268 && Main.rand.Next(50) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IchorPendant"));

			if (npc.type == 156 && Main.rand.Next(40) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FieryPendant"));

			if (npc.type == 260 || npc.type == 257)
			{
				if (Main.rand.Next(25) == 0 && Main.hardMode)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Fungus"));
				}
			}
			if (npc.type == 370)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Typhoon"));

			if (npc.type == 62 && NPC.downedBoss3 && Main.rand.Next(4) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CarvedRock"), Main.rand.Next(1) + 2);

			if (npc.type == 31 && Main.rand.Next(45) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BlazingWheel"));

			if (npc.type == 170 || npc.type == 171 || npc.type == 180)
			{
				if (Main.rand.Next(18) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("PigronStaff"));
				}
			}
			if (npc.type == 113 && Main.rand.Next(2) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FamineScepter"));

			if (npc.type == 113 && Main.rand.Next(4) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThrowerEmblem"));

			if (npc.type == 24 && Main.rand.Next(18) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TheFireball"));

			if (npc.type == 101 && Main.rand.Next(50) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CursedPendant"));

			if (npc.type == 29 && Main.rand.Next(20) == 0)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChaosBall"));

			if (npc.type == NPCID.DemonEye || npc.type == NPCID.DemonEye2 || npc.type == NPCID.DemonEyeOwl || npc.type == NPCID.DemonEyeSpaceship)
			{
				if (Main.rand.Next(20) == 1)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagnifyingGlass"), 1);
				}
			}
			if (npc.type == NPCID.EaterofSouls && Main.rand.Next(28) == 1)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EaterStaff"), 1);

			if (npc.type == NPCID.EaterofWorldsTail && !NPC.AnyNPCs(NPCID.EaterofWorldsHead) && !NPC.AnyNPCs(NPCID.EaterofWorldsBody))
			{
				if (Main.rand.Next(3) == 1)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("EoWSpear"), 1);
				}
			}
			if (npc.type == NPCID.FaceMonster && Main.rand.Next(28) == 1)
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CreeperStaff"), 1);

			if (npc.type == mod.NPCType("DiseasedSlime") || npc.type == mod.NPCType("DiseasedBat"))
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BismiteCrystal"), Main.rand.Next(3) + 2);

			if (npc.type == mod.NPCType("WanderingSoul"))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ancient Rune"), 3 + Main.rand.Next(3));
			}
			if (npc.type == mod.NPCType("Scarabeus") && Main.rand.Next(7) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ScarabMask"), 1);
			}
			if (npc.type == mod.NPCType("AncientFlyer") && Main.rand.Next(7) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("FlierMask"), 1);
			}
			if (npc.type == mod.NPCType("SteamRaiderHead") && Main.rand.Next(7) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StarplateMask"), 1);
			}
			if (npc.type == mod.NPCType("Infernon") && Main.rand.Next(7) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("InfernonMask"), 1);
			}
			if (npc.type == mod.NPCType("ReachBoss1") && Main.rand.Next(7) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ReachMask"), 1);
			}
			if (npc.type == mod.NPCType("SpiritCore") && Main.rand.Next(7) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SpiritCoreMask"), 1);
			}
			if (npc.type == mod.NPCType("Dusking") && Main.rand.Next(7) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("DuskingMask"), 1);
			}
			if (npc.type == mod.NPCType("IlluminantMaster") && Main.rand.Next(7) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IlluminantMask"), 1);
			}
			if (npc.type == mod.NPCType("Atlas") && Main.rand.Next(7) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AtlasMask"), 1);
			}
			if (npc.type == mod.NPCType("Overseer") && Main.rand.Next(7) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OverseerMask"), 1);
			}

			if (npc.type == mod.NPCType("Scarabeus") && Main.rand.Next(10) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Trophy1"), 1);
			}
			if (npc.type == mod.NPCType("AncientFlyer") && Main.rand.Next(10) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Trophy2"), 1);
			}
			if (npc.type == mod.NPCType("SteamRaiderHead") && Main.rand.Next(10) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Trophy3"), 1);
			}
			if (npc.type == mod.NPCType("Infernon") && Main.rand.Next(10) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Trophy4"), 1);
			}
			if (npc.type == mod.NPCType("ReachBoss1") && Main.rand.Next(10) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Trophy5"), 1);
			}
			if (npc.type == mod.NPCType("Dusking") && Main.rand.Next(10) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Trophy6"), 1);
			}
			if (npc.type == mod.NPCType("IlluminantMaster") && Main.rand.Next(10) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Trophy7"), 1);
			}
			if (npc.type == mod.NPCType("Atlas") && Main.rand.Next(10) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Trophy8"), 1);
			}
			if (npc.type == mod.NPCType("Overseer") && Main.rand.Next(10) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Trophy9"), 1);
			}
			if (npc.type == mod.NPCType("SpiritCore") && Main.rand.Next(10) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Trophy10"), 1);
			}


			// Donator Items

			//Folv
			if (npc.type == mod.NPCType("Scarabeus") || npc.type == mod.NPCType("AncientFlyer") || npc.type == mod.NPCType("SteamRaiderHead"))
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
			if (npc.type == mod.NPCType("IlluminantMaster") || npc.type == mod.NPCType("Atlas"))
			{
				if (Main.rand.Next(4) == 1)
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
			if (npc.type == NPCID.LihzahrdCrawler || npc.type == NPCID.Lihzahrd)
			{
				if (Main.rand.Next(6) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SunShard"));
				}
			}
			if (npc.type == NPCID.Eyezor)
			{
				if (Main.rand.Next(6) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Eyezor"));
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
			if (sFracture && Main.rand.Next(2) == 0)
				Dust.NewDust(npc.position, npc.width, npc.height, 133, (float)(Main.rand.Next(8) - 4), (float)(Main.rand.Next(8) - 4), 133);

			if (felBrand && Main.rand.Next(2) == 0)
				Dust.NewDust(npc.position, npc.width, npc.height, 75, (float)(Main.rand.Next(8) - 4), (float)(Main.rand.Next(8) - 4), 75);
		}

	}
}
