using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelLibrary
{
    public class BasePlatform : Sprite
    {

        public BasePlatform(Texture2D texture, Vector2 position, Color color, Vector2 scale, Texture2D pixel)
            : base(texture, position, color, scale, pixel)
        {

        }

        public bool CollideTop(Sprite sprite)
        {
            if (sprite.HitBox.Bottom > HitBox.Top && sprite.HitBox.Bottom < (HitBox.Bottom - HitBox.Height / 2) && sprite.HitBox.Intersects(HitBox))
            {
                return true;
            }
            return false;
        }

        public bool CollideBottom(Sprite sprite) 
        {
            if (sprite.HitBox.Top < HitBox.Bottom && sprite.HitBox.Top > (HitBox.Top + HitBox.Height / 2) && sprite.HitBox.Intersects(HitBox))
            {
                return true;
            }
            return false;
        }

        public bool CollideLeftSide(Sprite sprite)
        {
            if (sprite.HitBox.Right > HitBox.Left && sprite.HitBox.Right < HitBox.Left + (HitBox.Width /4) && sprite.HitBox.Intersects(HitBox))
            {
                return true;
            }
            return false;
        }

        public bool CollideRightSide(Sprite sprite)
        {
            if (sprite.HitBox.Left < HitBox.Right && sprite.HitBox.Left > HitBox.Right - (HitBox.Width /4) && sprite.HitBox.Intersects(HitBox))
            {
                return true;
            }
            return false;
        }
    }
}
