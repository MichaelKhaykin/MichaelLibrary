using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelLibrary
{
    public abstract class BaseSprite
    {
        public object Tag { get; set; }

        private Vector2 position;
        public float X
        {
            get
            {
                return position.X;
            }
            set
            {
                position.X = value;
            }
        }
        public float Y
        {
            get
            {
                return position.Y;
            }
            set
            {
                position.Y = value;
            }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Color Color { get; set; }
        public Vector2 Scale { get; set; }
        public virtual Vector2 Origin { get; set; }
        public float LayerDepth { get; set; }
        public string DebugName { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public bool IsVisible { get; set; } = true;

        public float Rotation { get; set; }
        public BaseSprite(Vector2 position, Color color)
        {
            Position = position;
            Color = color;
        }
        public abstract void Update(GameTime gameTime, GraphicsDevice graphicsDevice = null);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
