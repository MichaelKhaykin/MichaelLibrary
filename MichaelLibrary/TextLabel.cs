using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelLibrary
{
    public class TextLabel : BaseSprite
    {
        public string Text { get; set; }

        public SpriteFont SpriteFont { get; set; }
        public TextLabel(Vector2 position, Color color, string text, SpriteFont spriteFont)
            :base(position, color)
        {
            Position = position;
            Color = color;
            Text = text;
            SpriteFont = spriteFont;
        }

        public override void Update(GameTime gameTime, GraphicsDevice graphicsDevice = null)
        {
           
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, Text, Position, Color);
        }

    }
}
