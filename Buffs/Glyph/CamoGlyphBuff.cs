using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;

namespace SpiritMod.Buffs.Glyph
{
	public class CamoGlyphBuff : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Concealment");
			Description.SetDefault("Being still puts you in stealth\nStealth increases damage by 15% and life regen by 3");
			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			if (player.velocity.X == 0 && player.velocity.Y == 0)
			{
				player.rangedDamage += 0.15f;
				player.magicDamage += 0.15f;
				player.thrownDamage += 0.15f;
				player.minionDamage += 0.15f;
				player.meleeDamage += 0.15f;
				player.lifeRegen += 3;
				int dust = Dust.NewDust(player.position, player.width, player.height, 110);
				Main.dust[dust].scale = 2.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}
