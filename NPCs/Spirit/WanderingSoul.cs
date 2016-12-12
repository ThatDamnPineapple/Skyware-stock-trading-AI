using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SpiritMod.NPCs.Spirit
{
    public class WanderingSoul : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Wandering Soul";
            npc.displayName = "Wandering Soul";
            npc.width = 17;
            npc.height = 24;
            npc.damage = 37;
            npc.defense = 40;
            npc.lifeMax = 540;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 60f;
            npc.knockBackResist = .60f;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.aiStyle = 22;
            aiType = NPCID.Wraith;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Wraith];
            aiType = NPCID.Wraith;
            animationType = NPCID.Wraith;
            npc.stepSpeed = .5f;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
		{
			return Main.player[(int)Player.FindClosest(npc.position, npc.width, npc.height)].GetModPlayer<MyPlayer>(mod).ZoneSpirit ? 1f : 0f;
		}

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }

		public override void NPCLoot()
		{
			if (Main.rand.Next(3) == 1)
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Rune"));
		}

	}
}