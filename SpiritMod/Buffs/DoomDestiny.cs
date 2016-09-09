using Terraria;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs
{
    public class DoomDestiny : ModBuff
    {
        public override void SetDefaults()
        {
            Main.buffName[Type] = "Mark of the Apocolypse";
            Main.buffTip[Type] = "You won't survive";
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<MyPlayer>(mod).DoomDestiny = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetModInfo<NPCData>(mod).DoomDestiny = true;
        }
    }
}
