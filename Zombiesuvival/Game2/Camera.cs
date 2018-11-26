using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class Camera
    {

        private Matrix transfrom;

        private Vector2 centre;
        private Viewport viewport;

        private float zoom = 1;

        private float rotation = 0;
        public float X
        {
            get
            {
                return centre.X;

            }
            set
            {
                centre.Y = value;
            }

        }

        public float Zoom
        {
            get
            {
                return zoom;
            }
            set
            {
                zoom = value; if (zoom < 01f) zoom = 0.1f;
            }
        }



        public void Follow(GameObject taget)
        {
            transfrom = Matrix.CreateTranslation(-taget.Position - (taget))


        }
        public float Roattion
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = value;
            }
        }
        public Camera(Viewport newViemport)
        {
            viewport = newViemport;
        }
        public void update(Vector2 position)
        {

            centre = new Vector2(position.X, position.Y);
            transfrom = Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0)) *
                        Matrix.CreateRotationZ(rotation) *
                        Matrix.CreateScale(new Vector3(zoom, zoom, 0)) *
                        Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));



        }



    }
}

