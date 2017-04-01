using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Snail : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Gargantuan Snail";
            npc.displayName = "Gargantuan Snail";
            npc.width = 62;
            npc.height = 36;
            npc.damage = 20;
            npc.defense = 17;
            npc.lifeMax = 95;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 660f;
            npc.knockBackResist = .10f;
            npc.aiStyle = 39;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.GiantTortoise];
            aiType = 153;
            animationType = 153;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.spawnTileY > Main.rockLayer && NPC.downedBoss1 && spawnInfo.player.ZoneJungle ? 0.1f : 0f;
        }
		public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Snail1"), 1f);
				Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Snail2"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Snail1"), 1f);
            }
        }
        public override void NPCLoot()
        {
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Carapace"), Main.rand.Next(1) + 2);
            }
        }
    }
}
