using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Wheezer : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Wheezer";
            npc.displayName = "Wheezer";
            npc.width = 44;
            npc.height = 42;
            npc.damage = 18;
            npc.defense = 9;
            npc.lifeMax = 60;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .35f;
            npc.aiStyle = 3;
            aiType = NPCID.Salamander;
            Main.npcFrameCount[npc.type] = 8;

        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            return (tile == 1) && spawnInfo.spawnTileY > Main.rockLayer ? 0.1f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
		       public override void NPCLoot()
        {
			int Techs = Main.rand.Next(2,5);
			for (int J = 0; J <= Techs; J++)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Carapace"));
			}
		}
        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }
        public override void AI()
        {
            npc.spriteDirection = npc.direction;
        }
    }
}
