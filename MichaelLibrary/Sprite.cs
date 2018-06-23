using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelLibrary
{
    public class Sprite : BaseSprite
    {
        public virtual Texture2D Texture { get; set; }      
        public Rectangle? SourceRectangle { get; set; }
        public virtual Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)(Position.X - Origin.X * Scale.X), (int)(Position.Y - Origin.Y * Scale.Y), (int)(ScaledWidth), (int)(ScaledHeight));
            }
        }
        public bool IsHitBoxDisplayed = false;
        public Texture2D Pixel { get; set; }

        public float ScaledWidth
        {
            get
            {
                if (Texture == null)
                {
                    return 0;
                }

                return Texture.Width * Scale.X;
            }
        }
        public float ScaledHeight
        {
            get
            {
                if (Texture == null)
                {
                    return 0;
                }
                return Texture.Height * Scale.Y;
            }
        }

        public Sprite(Texture2D texture, Vector2 position, Color color, Vector2 scale, Texture2D pixel = null)
            : base(position, color)
        {
            Texture = texture;
            Position = position;
            Color = color;
            Scale = scale;
            SourceRectangle = null;
            Pixel = pixel;

            if (Texture != null)
            {
                Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
            }
        }

        public override void Update(GameTime gameTime, GraphicsDevice graphicsDevice = null)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch, SpriteSortMode sortMode)
            => DrawInternal(spriteBatch, sortMode);

        public override void Draw(SpriteBatch spriteBatch)
            => DrawInternal(spriteBatch, SpriteSortMode.Deferred);

        private void DrawInternal(SpriteBatch spriteBatch, SpriteSortMode sortMode)
        {
            if (IsVisible)
            {            
                spriteBatch.Draw(Texture, Position, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, sortMode == SpriteSortMode.FrontToBack ? LayerDepth : LayerDepth + .1f);
            }
            if (IsHitBoxDisplayed)
            {       
                if(DebugName != null)
                {

                }

                spriteBatch.Draw(Pixel, HitBox, null, Color.Red * .5f, Rotation, Vector2.Zero, SpriteEffects.None, sortMode == SpriteSortMode.FrontToBack ? LayerDepth + .1f : LayerDepth);
            }
        }
    }
}
