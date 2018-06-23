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
    public class AnimationSprite : Sprite
    {
        TimeSpan elapsedTimeToNextAnimation;
        public List<(TimeSpan timeSpan, Rectangle frame)> Frames = new List<(TimeSpan,Rectangle)>();
        public int currentFrameIndex = 0;

        public override Vector2 Origin
        {
            get
            {
                return new Vector2(Frames[currentFrameIndex].frame.Width / 2, Frames[currentFrameIndex].frame.Height);
            }
        }

        public override Rectangle HitBox
        {
            get
            {
                return new Rectangle((int)(Position.X - Origin.X / 2), (int)(Position.Y - (Origin.Y / 2)), (int)(Frames[currentFrameIndex].frame.Width * Scale.X), (int)(Frames[currentFrameIndex].frame.Height * Scale.Y));
            }
        }

        public AnimationSprite(Texture2D texture, Vector2 position, Color color, Vector2 scale, List<Rectangle> frames, TimeSpan timeTillAnimate, Texture2D pixel = null)
            : base(texture, position, color, scale, pixel)
        {
            List<(TimeSpan timeSpan, Rectangle frame)> framesWithTimeTillAnimate = new List<(TimeSpan, Rectangle)>();
            foreach (var frame in frames)
            {
                framesWithTimeTillAnimate.Add((timeTillAnimate, frame));
            }

            Initialize(framesWithTimeTillAnimate);
        }

        public AnimationSprite(Texture2D texture, Vector2 position, Color color, Vector2 scale, List<(TimeSpan timeSpan, Rectangle frame)> frames, Texture2D pixel = null)
            : base(texture, position, color, scale, pixel)
        {
            Initialize(frames);
        }

        private void Initialize(List<(TimeSpan timeSpan, Rectangle frame)> frames)
        {
            Frames = frames;
            SourceRectangle = frames[0].frame;
        }

        public override void Update(GameTime gameTime, GraphicsDevice graphicsDevice = null)
        {
            elapsedTimeToNextAnimation += gameTime.ElapsedGameTime;
            if (elapsedTimeToNextAnimation > Frames[currentFrameIndex].timeSpan)
            {
                IncrementFrame();
            }
        }

        private void IncrementFrame()
        {
            currentFrameIndex += 1;
            elapsedTimeToNextAnimation = TimeSpan.Zero;
            if (currentFrameIndex >= Frames.Count)
            {
                currentFrameIndex = 0;
            }
            SourceRectangle = Frames[currentFrameIndex].frame;
        }
    }
}
