using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items
{
    public class GItem : GlobalItem
    {
        double time;

        public override void PostDrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            if (time != Main.time)
            {
                if (Main.invasionType < 5 || Main.invasionProgress == -1)
                    return;

                if (InvasionHandler.currentInvasion == null || InvasionHandler.currentInvasion != InvasionHandler.GetInvasionInfo(Main.invasionType))
                {
                    InvasionHandler.currentInvasion = InvasionHandler.GetInvasionInfo(Main.invasionType);
                    if (Main.netMode == 0)
                    {
                        Main.NewText(InvasionHandler.currentInvasion.beginMessage, 175, 75, 255, false);
                        return;
                    }
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(25, -1, -1, InvasionHandler.currentInvasion.beginMessage, 255, 175f, 75f, 255f, 0, 0, 0);
                    }   
                }

                if (!Main.gamePaused && InvasionHandler.invasionProgressDisplayLeft > 0)
                {
                    InvasionHandler.invasionProgressDisplayLeft--;
                }
                if (InvasionHandler.invasionProgressDisplayLeft > 0)
                {
                    InvasionHandler.invasionProgressAlpha += 0.05f;
                }
                else
                {
                    InvasionHandler.invasionProgressAlpha -= 0.05f;
                }
                if (InvasionHandler.invasionProgressAlpha < 0f)
                {
                    InvasionHandler.invasionProgressAlpha = 0f;
                }
                if (InvasionHandler.invasionProgressAlpha > 1f)
                {
                    InvasionHandler.invasionProgressAlpha = 1f;
                }
                if (InvasionHandler.invasionProgressAlpha > 0)
                {

                    float num = 0.5f + InvasionHandler.invasionProgressAlpha * 0.5f;
                    Texture2D iconTexture = InvasionHandler.currentInvasion.invasionIcon;
                    string text = InvasionHandler.currentInvasion.name;
                    Color c = new Color(64, 109, 164) * 0.5f;

                    int num7 = (int)(200f * num);
                    int num8 = (int)(45f * num);
                    Vector2 vector3 = new Vector2((float)(Main.screenWidth - 120), (float)(Main.screenHeight - 40));
                    Rectangle r2 = new Rectangle((int)vector3.X - num7 / 2, (int)vector3.Y - num8 / 2, num7, num8);
                    Utils.DrawInvBG(spriteBatch, r2, new Color(63, 65, 151, 255) * 0.785f);
                    string text3;
                    if (Main.invasionProgressMax == 0)
                    {
                        text3 = Main.invasionProgress.ToString();
                    }
                    else
                    {
                        text3 = ((int)((float)Main.invasionProgress * 100f / (float)Main.invasionProgressMax)).ToString() + "%";
                    }
                    text3 = "Cleared " + text3;
                    Texture2D texture2D4 = Main.colorBarTexture;
                    Texture2D texture2D5 = Main.colorBlipTexture;
                    if (Main.invasionProgressMax != 0)
                    {
                        spriteBatch.Draw(texture2D4, vector3, null, Color.White * InvasionHandler.invasionProgressAlpha, 0f, new Vector2((float)(texture2D4.Width / 2), 0f), num, SpriteEffects.None, 0f);
                        float num9 = MathHelper.Clamp((float)Main.invasionProgress / (float)Main.invasionProgressMax, 0f, 1f);
                        float num10 = 169f * num;
                        float num11 = 8f * num;
                        Vector2 vector4 = vector3 + Vector2.UnitY * num11 + Vector2.UnitX * 1f;
                        Utils.DrawBorderString(Main.spriteBatch, text3, vector4, Color.White * InvasionHandler.invasionProgressAlpha, num, 0.5f, 1f, -1);
                        vector4 += Vector2.UnitX * (num9 - 0.5f) * num10;
                        spriteBatch.Draw(Main.magicPixel, vector4, new Rectangle?(new Rectangle(0, 0, 1, 1)), new Color(255, 241, 51) * InvasionHandler.invasionProgressAlpha, 0f, new Vector2(1f, 0.5f), new Vector2(num10 * num9, num11), SpriteEffects.None, 0f);
                        spriteBatch.Draw(Main.magicPixel, vector4, new Rectangle?(new Rectangle(0, 0, 1, 1)), new Color(255, 165, 0, 127) * InvasionHandler.invasionProgressAlpha, 0f, new Vector2(1f, 0.5f), new Vector2(2f, num11), SpriteEffects.None, 0f);
                        spriteBatch.Draw(Main.magicPixel, vector4, new Rectangle?(new Rectangle(0, 0, 1, 1)), Color.Black * InvasionHandler.invasionProgressAlpha, 0f, new Vector2(0f, 0.5f), new Vector2(num10 * (1f - num9), num11), SpriteEffects.None, 0f);
                    }
                    Vector2 center = new Vector2((Main.screenWidth - 120), (Main.screenHeight - 80));
                    Vector2 value = Main.fontItemStack.MeasureString(text);
                    Rectangle r3 = Utils.CenteredRectangle(center, (value + new Vector2((float)(iconTexture.Width + 20), 10f)) * num);
                    Utils.DrawInvBG(Main.spriteBatch, r3, c);
                    spriteBatch.Draw(iconTexture, r3.Left() + Vector2.UnitX * num * 8f, null, Color.White * InvasionHandler.invasionProgressAlpha, 0f, new Vector2(0f, (float)(iconTexture.Height / 2)), num * 0.8f, SpriteEffects.None, 0f);
                    Utils.DrawBorderString(spriteBatch, text, r3.Right() + Vector2.UnitX * num * -8f, Color.White * InvasionHandler.invasionProgressAlpha, num * 0.9f, 1f, 0.4f, -1);
                }
                time = Main.time;
            }
        }
    }
}
