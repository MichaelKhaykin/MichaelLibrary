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
    public class Button : Sprite
    {
        public Button(Texture2D texture, Vector2 position, Color color, Vector2 scale, Texture2D pixel)
            : base(texture, position, color, scale, pixel)
        {

        }

        public bool IsClicked(MouseState mouse)
        {
            if (IsVisible)
            {
                if (mouse.LeftButton == ButtonState.Pressed && HitBox.Contains(mouse.X, mouse.Y))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
