using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelLibrary
{
    public class Screen
    {
        protected ContentManager Content;
        protected GraphicsDevice Graphics;
        public List<BaseSprite> Sprites = new List<BaseSprite>();

        public Screen(GraphicsDevice graphics, ContentManager content)
        {
            Content = content;
            Graphics = graphics;
        }

        public virtual void Update(GameTime gameTime)
        {
            for (int i = 0; i < Sprites.Count; i++)
            {
                Sprites[i].Update(gameTime);
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            // Draw non-UI components first
            for (int i = 0; i < Sprites.Count; i++)
            {
                if(Sprites[i] is IUIComponent)
                {
                    continue;
                }

                if (Sprites[i].IsVisible == true)
                {                    
                    Sprites[i].Draw(spriteBatch);
                }
            }

            // Close spriteBatch; re-open with Immediate mode for UI draw
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate);

            // Draw UI components
            for (int i = 0; i < Sprites.Count; i++)
            {
                if (!(Sprites[i] is IUIComponent))
                {
                    continue;
                }

                if (Sprites[i].IsVisible == true)
                {
                    Sprites[i].Draw(spriteBatch);
                }
            }
        }
    }
}
