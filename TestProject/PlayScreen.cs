using MichaelLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class PlayScreen : Screen
    {
        TextBox textBox;

        Button button;

        public PlayScreen(GraphicsDevice graphics, ContentManager content)
            : base(graphics, content)
        {
            SpriteFont font = Content.Load<SpriteFont>("SpriteFont");

            textBox = new TextBox(graphics, new Rectangle(10, 200, 780, 30), font, Color.Black, Color.White, Color.Red, false);

            button = new Button(Content.Load<Texture2D>("BROLAF"), new Vector2(Graphics.Viewport.Width / 2, Graphics.Viewport.Height / 2), Color.Red, new Vector2(.5f), Game1.pixel);
            button.LayerDepth = 1;
            button.IsHitBoxDisplayed = true;   
            
          //  Sprites.Add(button);
            Sprites.Add(textBox);
        }

        public override void Update(GameTime gameTime)
        {
            textBox.Update(gameTime);

            MouseState mouse = Mouse.GetState();
            if (button.IsClicked(mouse))
            {
                Game1.screenState = ScreenStates.GameScreen;
            }
        }
    }
}
