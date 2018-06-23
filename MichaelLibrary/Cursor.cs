using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelLibrary
{
    public class Cursor
    {
        public Rectangle CursorArea { get; set; }
        public bool IsAbleToBeMoved { get; set; } 

        public Cursor(Rectangle cursorArea, bool isAbleToBeMoved)
        {
            CursorArea = cursorArea;
            IsAbleToBeMoved = isAbleToBeMoved;
        }
    }
}
