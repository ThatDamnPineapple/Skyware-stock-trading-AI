using Terraria;
using Terraria.ID;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Mecromancer : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Mecromancer";
            npc.displayName = "Mecromancer";
            npc.width = 44;
            npc.height = 56;
            npc.damage = 29;
            npc.defense = 8;
            npc.lifeMax = 500;
            npc.soundHit = 2;
            npc.soundKilled = 2;
            npc.value = 60f;
            npc.knockBackResist = .95f;
           npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = 17;
            aiType = NPCID.AngryBones;
            animationType = 471;
        }
		public override void NPCLoot()
		{
			int Techs = Main.rand.Next(2,5);
			for (int J = 0; J <= Techs; J++)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("TechDrive"));
			}
		}
        public override void AI()
		{
			if (Main.rand.Next(200) == 4)
			{
						npc.TargetClosest();
			Vector2 direction = Main.player[npc.target].Center - npc.Center;
            float ai = Main.rand.Next(100);
					direction.Normalize();
						int MechBat = Terraria.Projectile.NewProjectile(npc.Center.X, npc.Center.Y, 0, -6, mod.ProjectileType("MechBat"), npc.damage, 0);
			}
		}
    }
}
