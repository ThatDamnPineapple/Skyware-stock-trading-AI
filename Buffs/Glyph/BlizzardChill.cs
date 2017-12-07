using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.NPCs;
using Microsoft.Xna.Framework;

namespace SpiritMod.Buffs.Glyph
{
	public class BlizzardChill : ModBuff
	{
		public static int _type;

		public override void SetDefaults()
		{
			DisplayName.SetDefault("Blizzard Chill");
			Description.SetDefault("Movement speed is reduced by 30% and damage taken increased by 8%");
			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
			Main.debuff[Type] = true;
			canBeCleared = false;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			if (Main.rand.NextDouble() < 0.2)
			{
				int d = Dust.NewDust(npc.position, npc.width, npc.height, 172);
				Main.dust[d].noGravity = true;
				Main.dust[d].velocity = Vector2.Zero;
				Main.dust[d].scale *= 1.9f;
			}

			npc.GetGlobalNPC<GNPC>().frostChill = true;
			if (npc.knockBackResist == 0f)
				return;
			//npc.velocity.X *= 0.75f;
		}
	}
}
