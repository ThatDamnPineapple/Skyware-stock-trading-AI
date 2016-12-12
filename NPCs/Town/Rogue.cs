using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Town
{
	public class Rogue : ModNPC
	{
      public override bool Autoload(ref string name, ref string texture, ref string[] altTextures)
		{
			name = "Rogue";
			altTextures = new string[] { "SpiritMod/NPCs/Town/Rogue_Alt_1" };
			return mod.Properties.Autoload;
		}

		public override void SetDefaults()
		{
            npc.CloneDefaults(NPCID.Guide);
			npc.name = "Rogue";
            npc.townNPC = true;
			npc.friendly = true;
			npc.aiStyle = 7;
			npc.damage = 30;
			npc.defense = 30;
			npc.lifeMax = 500;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			Main.npcFrameCount[npc.type] = 26;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 1500;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 16;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			animationType = NPCID.Guide;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (player.active)
				{
					for (int j = 0; j < player.inventory.Length; j++)
					{
						if (player.inventory[j].type == mod.ItemType("IronShuriken") || player.inventory[j].type == mod.ItemType("LeadShuriken"))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(8))
			{
				case 0:
					return "Mark";
				case 1:
					return "Carlos";
				case 2:
					return "Lukas";
                case 3:
                    return "Damien";
                case 4:
                    return "Shane";
                case 5:
                    return "Mike";
                case 6:
                    return "Nexus";
                default:
					return "Rufus";
			}
		}

		public override string GetChat()
		{
			int Wizard = NPC.FindFirstNPC(NPCID.Wizard);
			if (Wizard >= 0 && Main.rand.Next(8) == 0)
			{
				return "Tell " + Main.npc[Wizard].displayName + " to stop asking me where I got the charms. He doesn't need to know that. He would die from shock.";
			}
			switch (Main.rand.Next(8))
			{
				case 0:
					return "Selling throwing items is special.";
				case 1:
					return "Why should I sell regular shurikens? The Merchant sells those...";
                case 2:
                    return "Watch as the apple leaves your head before I can throw at it.";
                case 3:
                    return "People think I can throw well, but yesterday I killed a bunny. By accident. ";
                case 4:
                    return "This mask is getting musky...";
                case 5:
                    return "...";
                case 6:
                    return "I hate Wyverns. I really do.";
                case 7:
                    return "Nice day we're having here! Now, who do you want dead?";
                default:
					return "Being a rogue is hard.";

			}
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Lang.inter[28];
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
		}

        public override void SetupShop(Chest shop, ref int nextSlot)
        {            
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("CopperShuriken"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("TinShuriken"));
                nextSlot++;
            }
            if (NPC.downedBoss1 == true)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("IronShuriken"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("LeadShuriken"));
                nextSlot++;

            }
            if (NPC.downedBoss2 == true)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("SilverShuriken"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("TungstenShuriken"));
                nextSlot++;

            }
            if (NPC.downedBoss3 == true)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("GoldShuriken"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("PlatinumShuriken"));
                nextSlot++;

            }
            if (NPC.downedMechBossAny == true) 
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("TwilightBlades"));
                
            }
            {
                nextSlot = 10;
                shop.item[nextSlot].SetDefaults(mod.ItemType("ShurikenLauncher"));
                nextSlot++;
                shop.item[nextSlot].SetDefaults(mod.ItemType("SwiftRune"));
                nextSlot++;
            }

        }

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 30;
			knockback = 6f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 5;
			randExtraCooldown = 5;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = mod.ProjectileType("IronShurikenProjectile");
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 20f;
			randomOffset = 2f;
		}
	}
}
