using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class FleshHound : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Flesh Hound";
            npc.displayName = "Flesh Hound";
            npc.width = 60;
            npc.height = 36;
            npc.damage = 25;
            npc.defense = 9;
            npc.lifeMax = 100;
            npc.soundHit = 1;
            npc.soundKilled = 5;
            npc.value = 60f;
            npc.knockBackResist = .8f;
            npc.aiStyle = 26;
            aiType = NPCID.Hellhound;
            Main.npcFrameCount[npc.type] = 10;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer && (Main.bloodMoon) ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
		public override void NPCLoot()
		{
			int Techs = Main.rand.Next(8,16);
		if (Main.rand.Next(2) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodFire"));
			}
		}
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("BCorrupt"), 180);
        }
    }
}
