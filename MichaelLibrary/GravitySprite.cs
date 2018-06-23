using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MichaelLibrary
{
    public class GravitySprite : Sprite
    {
        int Ground = 0;
        public GravitySprite(Texture2D texture, Vector2 position, Color color, Vector2 scale, int ground)
            : base(texture, position, color, scale)
        {
            Ground = ground;
        }

        public override void Update(GameTime gameTime, GraphicsDevice graphicsDevice = null)
        {
            if(Position.Y - Texture.Height / 2 < Ground)
            {
                Position = new Vector2(Position.X, Position.Y + 1);
            }

            base.Update(gameTime, graphicsDevice);
        }

    }
}
