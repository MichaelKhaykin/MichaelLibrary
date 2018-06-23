using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelLibrary
{
    public class AnimationHero : AnimationSprite
    {
        public AnimationHero(Texture2D texture, Vector2 position, Color color, Vector2 scale, List<Rectangle> frames)
            : base(texture, position, color, scale, frames)
        {

        }

        public override void Update(GameTime gameTime, Vector2? AmountToMove)
        {
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.D))
            {
                Position = new Vector2(Position.X + AmountToMove.Value.X, Position.Y);
            }
            else if (keyboard.IsKeyDown(Keys.A))
            {
                Position = new Vector2(Position.X - AmountToMove.Value.X, Position.Y);
            }
            else if (keyboard.IsKeyDown(Keys.W))
            {
                Position = new Vector2(Position.X, Position.Y - AmountToMove.Value.Y);
            }
            base.Update(gameTime);
        }

    }
}
