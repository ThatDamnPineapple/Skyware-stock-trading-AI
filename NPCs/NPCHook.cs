using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using SpiritMod.Items;

namespace SpiritMod.NPCs
{
	public class NPCHook : GlobalNPC
	{

		public override void ResetEffects(NPC npc)
		{
			NPCData data = npc.GetModInfo<NPCData>(mod);
			data.DoomDestiny = false;
            data.sFracture = false;
			if (npc.HasBuff(Buffs.TikiInfestation._ref.Type) < 0)
			{
				data.TikiStacks = 0;
				data.TikiSlot = 0;
			}
		}

        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            NPCData data = npc.GetModInfo<NPCData>(mod);
            if(data.sFracture)
            {
                if(Main.rand.Next(2) == 0) Dust.NewDust(npc.position, npc.width, npc.height, 133, (float)(Main.rand.Next(8)-4), (float)(Main.rand.Next(8) - 4), 133);
            }
        }
        public override void NPCLoot(NPC npc)
		{
			NPCData data = npc.GetModInfo<NPCData>(mod);
			//Vanilla NPCs
			if (npc.type == NPCID.Plantera)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ThornbloomKnife"), Main.rand.Next(40, 60));
			} else if (npc.type == NPCID.DesertBeast)
			{
				if (Main.rand.Next(Main.expertMode ? 10 : 20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BasiliskHorn"));
				}
			} else if (npc.type == NPCID.ElfCopter)
			{
				if (Main.rand.Next(Main.expertMode ? 50 : 100) < 3)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CandyRotor"));
				}
			} else if (npc.type == NPCID.QueenBee)
			{
				if (Main.rand.Next(Main.expertMode ? 10 : 20) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SweetThrow"));
				}
			}

			//Zone dependant
			Player closest = Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)];
			if (closest.ZoneHoly)
			{
				if (Main.rand.Next(100) == 0)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Mystic"), 1);
				}
			}
			if (closest.ZoneJungle)
			{
				if(NPC.downedPlantBoss && Main.rand.Next(100) == 0)
				{
					if (npc.type != NPCID.Bee)
					{
						Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Chaparral"), 1);
					}
				}
			}
			
			//Spirit Mod NPCs should have their drops managed in the respective file
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
			NPCData data = npc.GetModInfo<NPCData>(mod);
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

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			NPCData data = npc.GetModInfo<NPCData>(mod);
			if (data.DoomDestiny)
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
			if (data.fireStacks > 0)
			{
				if (npc.HasBuff(mod.BuffType("StackingFireBuff")) < 0)
				{
					data.fireStacks = 0;
					return;
				}

				if (npc.lifeRegen > 0)
					npc.lifeRegen = 0;
				npc.lifeRegen -= 16;
				damage = data.fireStacks * 5;
			}
		}
		
	}
}
