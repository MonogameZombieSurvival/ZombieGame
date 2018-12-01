using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

using System.Threading;
using System.Timers;

namespace Game2
{
    class Levels
    {
     

        private int level = 1;
        private GraphicsDevice graphicsDevice;
        private ContentManager contents;
        public int Level
        {
            get{
                return level;
            }
            set
            {
                level = value;
            }
        }
        public Levels(ContentManager content, int level)
        {

            contents = content;
            int X;
            int Y;

            if(level == 1)
            {
                addGround();
                addwater();
                addobejt();
                addEnemy();

            }
            



        }





        public void addGround()
        {

            string ground = "bg-grass2000'2";
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 0, 0));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 0, 2000));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 2000, 0));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 2000, 2000));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 0, -2000));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, -2000, 0));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 2000, -2000));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, -2000, 2000));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, -2000, -2000));

        }


        public void addwater() {

            string water = "water";

            if (level == 1)
            {
                int Y = 600;
              
                GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, 0, Y));
                GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, 400, Y));
                GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, 800, Y));
                GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, 1200, Y));
                GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, 1600, Y));
                GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, 2000, Y));
                GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, -400, Y));
                GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, -800, Y));
                GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, -1200, Y));
                GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, -1600, Y));
                GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, -2000, Y));
            }



        }

        public void addobejt()
        {
            if (level == 1)
            {
                NoneSolidObejts Bridge = new NoneSolidObejts(contents, "bridge-wood-square_0", 670, 520);
                NoneSolidObejts ship = new NoneSolidObejts(contents, "pirate_ship_00000", 520, 560);
                GameWorld.AddGameObject(Bridge);
                GameWorld.AddGameObject(ship);
            }
        } 

        public void addEnemy()
        {

            int y = 400;
            for (int i = 0; i < 10; i++)
            {

               
                GameWorld.AddGameObject(new Enemy(contents, "zombiesmall", 400, y));
                y -= 100;
                Thread.Sleep(100);
                
            }
            
        }



        public void Setlevel(int WavetimeOutput)
        {
            if (WavetimeOutput == 0)
            {
                level += 1;
            }           
        }

        public virtual void LoadContent()
        {
           
        }
        protected virtual void Update(GameTime gameTime)
        {
            
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {

          //  spriteBatch.Draw(backgroundImg, new Rectangle(13, 44, 1280, 720), Color.White);
          //  spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1f, new SpriteEffects(), 0f);
        }


     








    }
}






