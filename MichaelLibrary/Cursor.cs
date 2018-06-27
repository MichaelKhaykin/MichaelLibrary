using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelLibrary
{
    public class Cursor
    {
        private Texture2D Pixel { get; set; }
        public Rectangle CursorArea { get; set; }
        public bool IsAbleToBeMoved { get; set; }

        public bool IsVisible { get; set; } = true;
        public bool OverallVisibility { get; set; } = true;

        private TimeSpan ElapsedInvisibleTime = TimeSpan.Zero;
        private TimeSpan InvisibleTime = TimeSpan.FromSeconds(0.5);

        public Cursor(Texture2D pixel, Rectangle cursorArea, bool isAbleToBeMoved, bool isVisible)
        {
            Pixel = pixel;
            CursorArea = cursorArea;
            IsAbleToBeMoved = isAbleToBeMoved;
            OverallVisibility = isVisible;
        }

        public void Update(GameTime gameTime)
        {
            ElapsedInvisibleTime += gameTime.ElapsedGameTime;

            if (OverallVisibility)
            {
                if (IsVisible)
                {
                    if (ElapsedInvisibleTime > InvisibleTime)
                    {
                        IsVisible = false;
                        ElapsedInvisibleTime = TimeSpan.Zero;
                    }
                }
                else
                {
                    if (ElapsedInvisibleTime > InvisibleTime)
                    {
                        IsVisible = true;
                        ElapsedInvisibleTime = TimeSpan.Zero;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (OverallVisibility && IsVisible && Pixel != null)
            {
                spriteBatch.Draw(Pixel, CursorArea, Color.Black);
            }
        }
    }
}
