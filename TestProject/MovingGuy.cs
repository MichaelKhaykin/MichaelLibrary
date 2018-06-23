using MichaelLibrary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class MovingGuy : AnimationSprite
    {
        GuyState guyState;
        List<Rectangle> idleFrames;
        List<Rectangle> movingFrames = new List<Rectangle>();
        bool isKeyPressed = false;
        public MovingGuy(Texture2D texture, Vector2 position, Color color, Vector2 scale, List<Rectangle> frames, Texture2D pixel)
            : base(texture, position, color, scale, frames, TimeSpan.FromMilliseconds(1), pixel)
        {
            movingFrames = frames;
        }

        //public override void Update(GameTime gameTime)
        //{
        //    KeyboardState keyboard = Keyboard.GetState();

        //    if (keyboard.IsKeyDown(Keys.W))
        //    {
        //        Position = new Vector2(Position.X, Position.Y - 5);
        //    }
        //    else if (keyboard.IsKeyDown(Keys.D))
        //    {
        //        Position = new Vector2(Position.X + 5, Position.Y);
        //        guyState = GuyState.Moving;
        //        Frames = movingFrames;
        //        SpriteEffects = SpriteEffects.None;
        //        isKeyPressed = true;
        //    }
        //    else if (keyboard.IsKeyDown(Keys.A))
        //    {
        //        Position = new Vector2(Position.X - 5, Position.Y);
        //        guyState = GuyState.Moving;
        //        Frames = movingFrames;
        //        SpriteEffects = SpriteEffects.FlipHorizontally;
        //        isKeyPressed = true;
        //    }
        //    else if (keyboard.IsKeyDown(Keys.S))
        //    {
        //        Position = new Vector2(Position.X, Position.Y + 5);
        //    }
        //    if (isKeyPressed)
        //    {
        //        base.Update(gameTime);
        //    }
        //}
    }
}
