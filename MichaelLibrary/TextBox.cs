﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Text;
using System.Linq;

namespace MichaelLibrary
{
    public class TextBox : BaseSprite, IUIComponent
    {
        public Rectangle Area { get; set; }
        private SpriteFont Font { get; set; }

        private static Texture2D Pixel { get; set; }

        private TimeSpan holdDownTimer = TimeSpan.Zero;
        private TimeSpan KeyTime = TimeSpan.FromMilliseconds(200);
        private TimeSpan ElapsedKeyTime = TimeSpan.Zero;

        private TimeSpan LastKeyPressedTimer = TimeSpan.Zero;

        private Cursor Cursor { get; set; }

        public Color BorderColor { get; set; }
        public Color InnerColor { get; set; }

        private KeyboardState oldKeyboard;

        private int OriginalX { get; set; }

        private StringBuilder TextBuilder = new StringBuilder();
        private StringBuilder PasswordBuilder = new StringBuilder();

        private bool IsPasswordMode { get; set; } = false;

        private int capsLockOffset = 0;

        private Color TextColor { get; set; }

        public string Text => TextBuilder.ToString();

        public TextBox(GraphicsDevice graphics, Rectangle area, SpriteFont font, Color borderColor, Color innerColor, Color textColor,bool isPassword)
               : base(new Vector2(area.X, area.Y), Color.White)
        {
            TextColor = textColor;

            IsPasswordMode = isPassword;

            Cursor = new Cursor(new Rectangle(area.X, area.Y, 1, area.Height), true);

            OriginalX = area.X;

            if (Pixel == null)
            {
                Pixel = new Texture2D(graphics, 1, 1);
                Pixel.SetData(new Color[] { Color.White });
            }

            Area = area;
            Font = font;

            BorderColor = borderColor;
            InnerColor = innerColor;
        }

        public void CalculateStars(Keys lastpressedKey)
        {
            //Not necessary function

            var size = Font.MeasureString(lastKeyPressed.ToString());
            var starSize = Font.MeasureString("*");

            int sizeX = (int)size.X;
            int starSizex = (int)starSize.X;

            while (starSizex < sizeX)
            {
                starSizex = starSizex + starSizex;
                PasswordBuilder.Append("*");
            }
        }

        Keys lastKeyPressed = Keys.None;
        public override void Update(GameTime gameTime, GraphicsDevice graphicsDevice = null)
        {
            KeyboardState keyboard = Keyboard.GetState();

            //Handle cursor movement
            bool isTextUpdated = false;

            ElapsedKeyTime += gameTime.ElapsedGameTime;

            var oldKeys = oldKeyboard.GetPressedKeys();
            var newKeys = keyboard.GetPressedKeys();

            if (newKeys.Length > 0)
            {
                var newLastKeyPressed = newKeys[newKeys.Length - 1];
                if (lastKeyPressed != newLastKeyPressed)
                {
                    lastKeyPressed = newLastKeyPressed;
                    LastKeyPressedTimer = TimeSpan.Zero;
                }
            }
            else
            {
                lastKeyPressed = Keys.None;
                LastKeyPressedTimer = TimeSpan.Zero;
                holdDownTimer = TimeSpan.Zero;
            }

            if (Cursor.CursorArea.X + Cursor.CursorArea.Width + Font.MeasureString(lastKeyPressed.ToString()).X >= Area.X + Area.Width)
            {
                Cursor.IsAbleToBeMoved = false;
            }

            if (lastKeyPressed != Keys.None)
            {
                if (keyboard.IsKeyDown(lastKeyPressed))
                {
                    LastKeyPressedTimer += gameTime.ElapsedGameTime;
                }
                if (LastKeyPressedTimer.TotalMilliseconds > 500)
                {
                    holdDownTimer += gameTime.ElapsedGameTime;
                    if (holdDownTimer.TotalMilliseconds > 80)
                    {
                        if ((int)lastKeyPressed >= 65 && (int)lastKeyPressed <= 90)
                        {
                            capsLockOffset = keyboard.CapsLock ? 0 : 32;
                        }

                        if (lastKeyPressed == Keys.Back)
                        {
                            RemoveLetter(TextBuilder);
                            RemoveLetter(PasswordBuilder);

                            isTextUpdated = true;
                        }
                        if ((int)lastKeyPressed >= 32 && (int)lastKeyPressed <= 126)
                        {
                            if (lastKeyPressed == Keys.Space)
                            {
                                if (Cursor.IsAbleToBeMoved)
                                {
                                    TextBuilder.Append((char)(32));
                                }
                            }
                            else
                            {
                                if (Cursor.IsAbleToBeMoved)
                                {
                                    TextBuilder.Append((char)((int)lastKeyPressed + capsLockOffset));
                                }
                            }

                            if (IsPasswordMode == true)
                            {
                                PasswordBuilder.Append("*");
                            }

                            isTextUpdated = true;
                        }

                        holdDownTimer = TimeSpan.Zero;
                    }
                }
            }

            foreach (var key in newKeys)
            {
                if ((int)key >= 65 && (int)key <= 90)
                {
                    capsLockOffset = keyboard.CapsLock ? 0 : 32;
                }

                if (key == Keys.Back && oldKeyboard.IsKeyUp(Keys.Back))
                {
                    RemoveLetter(TextBuilder);
                    RemoveLetter(PasswordBuilder);

                    isTextUpdated = true;
                }
                if ((int)key < 32 || (int)key > 126)
                {
                    continue;
                }
                if (!oldKeys.Contains(key))
                {
                    if (key == Keys.Space)
                    {
                        if (Cursor.IsAbleToBeMoved)
                        {
                            TextBuilder.Append((char)(32));
                        }
                    }
                    else
                    {
                        if (Cursor.IsAbleToBeMoved)
                        {
                            TextBuilder.Append((char)((int)key + capsLockOffset));
                        }
                    }

                    if (IsPasswordMode == true)
                    {
                        PasswordBuilder.Append("*");
                    }

                    isTextUpdated = true;
                }
            }

            if (ElapsedKeyTime > KeyTime)
            {
                ElapsedKeyTime = TimeSpan.Zero;
            }

            if (isTextUpdated)
            {
                Vector2 textSize = Vector2.Zero;

                if (!IsPasswordMode)
                {
                    textSize = Font.MeasureString(TextBuilder.ToString());
                }
                else
                {
                    textSize = Font.MeasureString(PasswordBuilder.ToString());
                }
                Cursor = new Cursor(new Rectangle((int)(Position.X + textSize.X), Cursor.CursorArea.Y, Cursor.CursorArea.Width, Cursor.CursorArea.Height), true);
            }

            oldKeyboard = keyboard;
        }

        public bool RemoveLetter(StringBuilder stringBuilder)
        {
            if (stringBuilder.Length - 1 < 0)
            {
                return false;
            }
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //Draw outer box
            spriteBatch.Draw(Pixel, new Rectangle(Area.X - 2, Area.Y - 2, Area.Width + 4, Area.Height + 4), BorderColor);
            //Draw inner box
            spriteBatch.Draw(Pixel, Area, InnerColor);

            //Draw cursor
            spriteBatch.Draw(Pixel, Cursor.CursorArea, BorderColor);

            if (!IsPasswordMode)
            {
                spriteBatch.DrawString(Font, TextBuilder, new Vector2(Area.X, Area.Y), TextColor);
            }
            else
            {
                spriteBatch.DrawString(Font, PasswordBuilder, new Vector2(Area.X, Area.Y), TextColor);
            }
        }
    }
}
