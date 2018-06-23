using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelLibrary
{
    public class Camera
    {
        public float _zoom;
        public float Rotation { get; set; }
        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; }
        }

        public Vector2 Position { get; set; }
        public Camera()
        {
            _zoom = 1.0f;

        }

        public void Update(Vector2 positionToFollow, GraphicsDevice graphicsDevice)
        {
            Position = new Vector2(positionToFollow.X, graphicsDevice.Viewport.Height);
        }
        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            Matrix _transform;


            _transform = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0)) *
                                       Matrix.CreateRotationZ(Rotation) *
                                       Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                       Matrix.CreateTranslation(new Vector3(0, graphicsDevice.Viewport.Height, 0));
            return _transform;
        }

    }
}
