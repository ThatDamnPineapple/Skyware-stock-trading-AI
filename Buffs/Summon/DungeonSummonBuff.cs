using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Summon
{
	public class DungeonSummonBuff : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Dungeon Soul";
			Main.buffTip[Type] = "A particularly fiesty soul";

			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

        public override void Update(Player player, ref int buffIndex)
        {
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType("DungeonSummon")] > 0)
            {
                modPlayer.DungeonSummon = true;
            }
            if (!modPlayer.DungeonSummon)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }
            player.buffTime[buffIndex] = 18000;
        }
    }
}
