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


        private float moveSpeed = 1000;

        private Vector2 sightepos;
        public Vector2 Sightepos
        {
            set
            {
                sightepos = value;
            }
        }
        private Vector2 sighteofset = new Vector2(0,0);
        public sighte( ContentManager content) : base(content, "sighte")
        {
            
        }




        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            sightepos.Y = mouse.Y;
            sightepos.X = mouse.X;
                 
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                sighteofset.X -= (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                sighteofset.X += (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                sighteofset.Y -= (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
               sighteofset.Y += (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            }
            sightepos += sighteofset;
             position = sightepos;
        }




    }

}
