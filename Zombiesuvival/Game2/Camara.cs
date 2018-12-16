using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    public class Camera
    {

        private Matrix tranform;

        public Matrix Transform
        {
            get { return tranform; }
        }

        private Vector2 centre;
        private Viewport viewport;

        public Camera(Viewport viewport)
        {
            this.viewport = viewport;
        }
    
        public void Camara(Viewport NewViewPort){

            NewViewPort = viewport;
        }

        /// <summary>
        ///  takes the positon wich the camara has to follow
        /// </summary>
        /// <param name="position"></param>

            public void update(Vector2 position)
        {

            centre = position;

            tranform = Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0))
                * Matrix.CreateTranslation(viewport.Width/2 , viewport.Height/2 , 0);
        }
        

}
}
