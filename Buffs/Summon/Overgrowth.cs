using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Summon
{
	public class Overgrowth : ModBuff
	{
		public override void SetDefaults()
		{
			Main.buffName[Type] = "Overgrowth";
			Main.buffTip[Type] = "The overgrowth spirit will protect you";
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
            MyPlayer modPlayer = player.GetModPlayer<MyPlayer>(mod);
            if (player.ownedProjectileCounts[mod.ProjectileType("Overgrowth")] > 0)
			{
				modPlayer.OG = true;
			}
			if (!modPlayer.OG)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}