using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    class sighte :GameObject
    {


        private float moveSpeed = 200;

       

        public sighte( ContentManager content) : base(content, "sighte")
        {
            
        }




        /// <summary>
        /// get Position from player
        /// </summary>
      public void GetPosition()
        {

        }

  
        


        public override void Update(GameTime gameTime)
        {

            position = sightposition;




      
           
        }



        //public override void DoCollision(GameObject otherObject)
        //{
        //    if (otherObject is Solid)
        //    {

        //        if (Keyboard.GetState().IsKeyDown(Keys.D))
        //        {
        //            position.X -= 4;
        //        }
        //        else if (Keyboard.GetState().IsKeyDown(Keys.W))
        //        {

        //            position.Y -= -4;
        //        }

        //        if (Keyboard.GetState().IsKeyDown(Keys.A))
        //        {
        //            position.X += 4;
        //        }

        //        if (Keyboard.GetState().IsKeyDown(Keys.W))
        //        {
        //            position.Y += 4;
        //        }

        //        if (Keyboard.GetState().IsKeyDown(Keys.S))
        //        {
        //            position.Y -= 4;
        //        }

        //    }

        //}

    }

}
