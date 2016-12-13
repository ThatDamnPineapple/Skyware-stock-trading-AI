using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class DeadArcher : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Deadeye Marksman";
            npc.displayName = "Deadeye Marksman";
            npc.width = 36;
            npc.height = 46;
            npc.damage = 22;
            npc.defense = 13;
            npc.lifeMax = 80;
            npc.soundHit = 1;
            npc.soundKilled = 1;
            npc.value = 60f;
            npc.knockBackResist = .30f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GoblinArcher];
            aiType = NPCID.GoblinArcher;
            animationType = NPCID.GoblinArcher;
        }
		public override void NPCLoot()
		{
			int Techs = Main.rand.Next(8,16);
		if (Main.rand.Next(2) == 1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BloodFire"));
			}
		}
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY < Main.rockLayer && (Main.bloodMoon) ? 0.08f : 0f;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            if (Main.rand.Next(4) == 0)
            {
                target.AddBuff(mod.BuffType("BCorrupt"), 180);
            }
        }
    }
}
