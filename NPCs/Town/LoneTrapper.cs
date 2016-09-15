using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Town
{
	public class LoneTrapper : ModNPC
	{
		public override bool Autoload(ref string name, ref string texture, ref string[] altTextures)
		{
			name = "Lone Trapper";
			altTextures = new string[] { "SpiritMod/NPCs/Town/LoneTrapper_Alt_1" };
			return mod.Properties.Autoload;
		}

		public override void SetDefaults()
		{
            npc.CloneDefaults(NPCID.Guide);
            npc.name = "Lone Trapper";
            npc.townNPC = true;
            npc.friendly = true;
            npc.aiStyle = 7;
            npc.damage = 30;
            npc.defense = 30;
            npc.lifeMax = 500;
            npc.soundHit = 1;
            npc.soundKilled = 1;
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

		public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, mod.DustType("Sparkle"));
			}
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
                        if (NPC.downedMechBossAny == true)
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
			switch (WorldGen.genRand.Next(4))
			{
				case 0:
					return "Casper";
				case 1:
					return "Timmy";
                case 2:
                    return "Beni";
                default:
					return "Castiel";
                
                
			}
		}

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{			
			switch (Main.rand.Next(8))
			{
				case 0:
					return "Uhm, right now is my depression time. Go away.";
				case 1:
					return "Hell was nice, but I needed a change.";
                case 2:
                    return "Buy something and leave. Please.";
                case 3:
                    return "Need to capture souls? You came to the right place.";
                case 4:
                    return "Sorrow is all I see in this wretched world... No longer, if I have something to say about it.";
                case 5:
                    return "...";
                case 6:
                    return "I ask for you be leave my presence.";
                case 7:
                    return "Leave me alone...";
                default:
					return "I used to be a massive, hulking king of the Underworld. Until you showed up.";

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
			shop.item[nextSlot].SetDefaults(mod.ItemType("EtherealSword"));
			nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("EtherealBow"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("EtherealStaff"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("EtherealSpear"));
            nextSlot++;


        }

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 15;
			knockback = 6f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 15;
			randExtraCooldown = 15;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
            projType = mod.ProjectileType("EtherealStaffProjectile");
            attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 11f;
			randomOffset = 2f;
		}
	}
}
