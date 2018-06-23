using MichaelLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class GameScreen : Screen
    {
        MovingGuy sprite;
        List<Rectangle> rectangles;
        BasePlatform basePlatform;
        TextLabel textLabel;
        public GameScreen(GraphicsDevice graphics, ContentManager content)
            : base(graphics, content)
        {

            rectangles = new List<Rectangle>();
            rectangles.Add(new Rectangle(8, 11, 118, 133));
            rectangles.Add(new Rectangle(139, 11, 117, 133));
            rectangles.Add(new Rectangle(268, 11, 116, 133));
            rectangles.Add(new Rectangle(403, 12, 111, 133));
            rectangles.Add(new Rectangle(539, 13, 103, 133));
            rectangles.Add(new Rectangle(673, 13, 101, 133));
            rectangles.Add(new Rectangle(805, 12, 99, 133));
            rectangles.Add(new Rectangle(24, 162, 98, 133));
            rectangles.Add(new Rectangle(157, 162, 95, 133));
            rectangles.Add(new Rectangle(288, 160, 93, 133));
            rectangles.Add(new Rectangle(418, 159, 95, 133));
            rectangles.Add(new Rectangle(546, 159, 97, 133));
            rectangles.Add(new Rectangle(674, 159, 101, 133));
            rectangles.Add(new Rectangle(800, 159, 104, 133));
            rectangles.Add(new Rectangle(10, 310, 114, 133));
            rectangles.Add(new Rectangle(138, 310, 117, 133));
            rectangles.Add(new Rectangle(275, 310, 108, 133));
            rectangles.Add(new Rectangle(412, 312, 101, 133));
            rectangles.Add(new Rectangle(542, 312, 101, 133));
            rectangles.Add(new Rectangle(671, 312, 102, 133));
            rectangles.Add(new Rectangle(808, 312, 96, 133));
            rectangles.Add(new Rectangle(29, 465, 93, 133));
            rectangles.Add(new Rectangle(156, 463, 98, 133));
            rectangles.Add(new Rectangle(280, 461, 102, 133));
            rectangles.Add(new Rectangle(409, 462, 106, 133));
            rectangles.Add(new Rectangle(537, 462, 108, 133));
            rectangles.Add(new Rectangle(663, 462, 109, 133));

            Texture2D spriteTexture = Content.Load<Texture2D>("Runner");

            sprite = new MovingGuy(spriteTexture, new Vector2(0, 0), Color.White, new Vector2(.5f), rectangles, Game1.pixel);
            sprite.Position = new Vector2(0, Graphics.Viewport.Height - sprite.Origin.Y / 2);
            sprite.IsHitBoxDisplayed = true;

            basePlatform = new BasePlatform(Content.Load<Texture2D>("Flatplatform"), new Vector2(Graphics.Viewport.Width / 2, Graphics.Viewport.Height / 2), Color.White, new Vector2(.5f), Game1.pixel);
            basePlatform.IsHitBoxDisplayed = true;

            textLabel = new TextLabel(new Vector2(100, 100), Color.White, "Welcome you shall die", Content.Load<SpriteFont>("SpriteFont"));

            Sprites.Add(textLabel);
            Sprites.Add(sprite);
            Sprites.Add(basePlatform);
        }
        public override void Update(GameTime gameTime)
        {
            if (basePlatform.CollideTop(sprite) || basePlatform.CollideBottom(sprite) || basePlatform.CollideLeftSide(sprite) || basePlatform.CollideRightSide(sprite))
            {
                sprite.Position = new Vector2(basePlatform.Position.X, basePlatform.Position.Y);
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
