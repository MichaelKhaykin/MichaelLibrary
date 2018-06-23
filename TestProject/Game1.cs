using MichaelLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TestProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static ScreenStates screenState = ScreenStates.PlayScreen;
        GameScreen gameScreen;
        PlayScreen playScreen;

        public Dictionary<ScreenStates, Screen> screen = new Dictionary<ScreenStates, Screen>();

        public static Texture2D pixel;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Debug Code Below
            pixel = new Texture2D(GraphicsDevice, 1, 1);
            pixel.SetData(new Color[] { Color.White });
            //Debug Code Above
           
            gameScreen = new GameScreen(GraphicsDevice, Content);
            playScreen = new PlayScreen(GraphicsDevice, Content);

            screen.Add(ScreenStates.GameScreen, gameScreen);
            screen.Add(ScreenStates.PlayScreen, playScreen);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            screen[screenState].Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Game sprites
            spriteBatch.Begin(SpriteSortMode.BackToFront);
            screen[screenState].Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
