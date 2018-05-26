using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Dusts
{
	public class FirewallDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			dust.noLight = true;
		//	dust.color = new Color(188, 66, 244);
			dust.scale = 4f;
			dust.noGravity = true;
		}
		public override bool Update(Dust dust)
		{
			dust.position += dust.velocity;
			dust.rotation = 0;
			Lighting.AddLight((int)(dust.position.X / 16f), (int)(dust.position.Y / 16f), .225f, 1.5975f, 1.9125f);
			dust.scale -= 0.06f;
			if (dust.scale < 1f)
			{
				dust.active = false;
			}
			return false;
		}
		
		
	}
}