using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs
{
    public class Snapper : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Snapper";
            npc.displayName = "Snapper";
            npc.width = 34;
            npc.height = 52;
            npc.damage = 40;
            npc.defense = 15;
            npc.lifeMax = 115;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 1060f;
            npc.knockBackResist = 0.75f;
            npc.aiStyle = 3;
            Main.npcFrameCount[npc.type] = 5;
            aiType = NPCID.Zombie;
            animationType = 530;
        }
        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
			int y = spawnInfo.spawnTileY;
			int tile = (int)Main.tile[x, y].type;
            return (tile == 1) && spawnInfo.spawnTileY > Main.rockLayer && NPC.downedBoss1 ? 0.2f : 0f;
        }
		
		        public override void NPCLoot()
        {
				int Techs = Main.rand.Next(2,5);
			for (int J = 0; J <= Techs; J++)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Carapace"));
			}
			if (Main.rand.Next(30) == 1)
			{
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("MagicConch"), 1);
			}
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Snapper_Head"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/Snapper_Body"), 1f);

            }
        }
    }
}
