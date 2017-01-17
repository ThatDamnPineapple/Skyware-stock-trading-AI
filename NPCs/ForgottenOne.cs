using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace SpiritMod.NPCs
{
    public class ForgottenOne : ModNPC
    {
        public override void SetDefaults()
        {
            npc.name = "Forgotten One";
            npc.displayName = "Forgotten One";
            npc.width = 36;
            npc.height = 44;
            npc.damage = 300;
            npc.defense = 0;
            npc.lifeMax = 5;
            npc.HitSound = SoundID.NPCHit2;
			npc.DeathSound = SoundID.NPCDeath6;
            npc.value = 50000f;
            npc.knockBackResist = .60f;
            npc.aiStyle = 3;
            aiType = NPCID.DesertGhoul;
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.DesertGhoul];
            aiType = NPCID.DesertGhoul;
            animationType = NPCID.DesertGhoul;
            npc.lavaImmune = true;
        }

        public override float CanSpawn(NPCSpawnInfo spawnInfo)
        {
            int x = spawnInfo.spawnTileX;
            int y = spawnInfo.spawnTileY;
            int tile = (int)Main.tile[x, y].type;
            bool oUnderworld = (y >= (Main.maxTilesY * 0.8f));
            return oUnderworld && Main.hardMode ? 0.025f : 0f;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++) ;
            if (npc.life <= 0)
            {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/One1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/One2"), 1f);

                int dust = Dust.NewDust(npc.position, npc.width, npc.height, 6);
            }
        }
        public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Ancient Rune"), 3 + Main.rand.Next(3));
		}

	}
}