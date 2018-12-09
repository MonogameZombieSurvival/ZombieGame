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
        private int level;
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
        public Levels(ContentManager content, int Level)
        {
            level = Level;
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

        
        /// <summary>
        /// loader jorden playeren skal gå på;
        /// </summary>
        public void addGround()
        {

            string ground = "bg-grass2000'2";
            string HaberStone = "Haber";
            string vej = "vej";
            string vejop = "vejop";
            string kryds = "TN_2";
            string krydsvent = "krydsvendt";
            int Y = 371;
            int X = -2000;
            // add grass
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, -2000, 0));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 0, 0));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 2000, 0));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 4000, 0));

            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, -2000, -2000));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 0, -2000));          
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 2000, -2000));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 4000, -2000));

            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, -2000, -4000));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 0, -4000));
            GameWorld.AddEFfect(new NoneSolidObejts(contents, ground, 2000, -4000));
            

            // adds haven
            Y = 371;
             X = -2000;          
            for (int i = 0; i <19; i++)
            {
             GameWorld.AddEFfect(new NoneSolidObejts(contents, HaberStone,X ,Y ));         
                X += 283;
            }

            Y = 40;
            X = -2000;
            //fortov førsy
            for (int i = 0; i < 19; i++)
            {
                GameWorld.AddEFfect(new NoneSolidObejts(contents, HaberStone, X, Y));
                X += 283;
            }

            Y = -763;
            X = -2000;
            X -= 4 * 283;
            /// fotov til næste række af huse
            for (int i = 0; i < 23; i++)
            {
                GameWorld.AddEFfect(new NoneSolidObejts(contents, HaberStone, X, Y));
                X += 283;
            }

       
            Y = 202;
            X = -2000;
            /// 
            /// vej
            for (int i = 0; i < 19; i++)
            {
                GameWorld.AddEFfect(new NoneSolidObejts(contents, vej, X,Y  ));
                X += 283;
            }
            ///haven færdig here
            Y = 202;
            X = 2293;// kryds ven havnen
            GameWorld.AddEFfect(new NoneSolidObejts(contents, kryds, X, Y));

            Y = -83;
            // vej op ad fra havene
            for (int i = 0; i < 3; i++)
            {
                GameWorld.AddEFfect(new NoneSolidObejts(contents, vejop, X, Y));

                Y -= 283;
            }

            GameWorld.AddEFfect(new NoneSolidObejts(contents, krydsvent, X, Y));

            // vej vandret
            X -= 283;
            for (int i = 0; i <15; i++)
            {
                GameWorld.AddEFfect(new NoneSolidObejts(contents, vej, X, Y));
                X -= 283;
            }
            // kryds venste op
            GameWorld.AddEFfect(new NoneSolidObejts(contents, kryds, X, Y));
            X -= 283;
            for (int i = 0; i < 4; i++)
            {
                GameWorld.AddEFfect(new NoneSolidObejts(contents, vej, X, Y));
                X -= 283;
            }
            X += 5 * 283;
            // vej op efter krus oppe venste
            Y -= 283;
            for (int i = 0; i < 7; i++)
            {
                GameWorld.AddEFfect(new NoneSolidObejts(contents, vejop, X, Y));

                Y -= 283;
            }

            // fortov øverst
            Y = -1090;
            X = -2000;
         
            for (int i = 0; i < 19; i++)
            {
                GameWorld.AddEFfect(new NoneSolidObejts(contents, HaberStone, X, Y));
                X += 283;
            }
            /// mere vej efter kryd til højre opppe
            X = 2293;
            X += 283;
            for (int i = 0; i < 3; i++)
            {
                GameWorld.AddEFfect(new NoneSolidObejts(contents, vej, X, Y));
                X += 283;
            }
            X += 283;
          

        }

        /// <summary>
        /// add water
        /// </summary>
        public void addwater() {

            string water = "water";
          
            if (level == 1)
            {
                int Y = 600;
                int X = -2000;
                for (int i = 0; i < 14; i++)
                {
                    GameWorld.AddGameObject(new NoTwalkerbelObejt(contents, water, X, Y));
                    X += 400;
                }           
          
            }



        }
        /// <summary>
        /// loader obejter som broer, biler, skibe og andre ting
        /// </summary>
        public void addobejt()
        {
            string miniTruck = "Mini_truck";
            string House = "House";
            string parkeringplads = "parkeringsplas";
            string Bush = "plant1";
            string Machingun = "firearms/blood_c_0001";
            string shotgun = "firearms/item_shotgun";
            string fenceVandrat = "fenceVandrat";
            string fencelodrat = "fencelodrat";
            string tree = "Trees/";
            string[] trees = new string[] { "(1)", "(2)", "(3)", "(4)", "(5)", "(6)",
                "(7)", "(8)", "(9)", "(10)", "(11)", "(12)", "(13)", "(14)", "(15)", "(16)", "(17)", "(18)", "(19)", "(20)", "(21)", "(22)", "(23)", "(24)", "(25)", "(26)", "(27)", "(28)" };

            if (level == 1)
            {

                int Y = -200;
                int X = -1400;
                //addingbrige
                GameWorld.AddGameObject(new NoneSolidObejts(contents, "bridge-wood-square_0", 670, 520));
                // adds skib
                GameWorld.AddGameObject(new NoneSolidObejts(contents, "pirate_ship_00000", 520, 560));
                // adds cars
                for (int i = 0; i < 4; i++)
                {
                    GameWorld.AddGameObject(new Solid(contents, miniTruck, X, Y));
                    Y += 175;
                }
                //cars
                 Y = 120;
                for (int i = 0; i < 2; i++)
                {
                    GameWorld.AddGameObject(new Solid(contents, miniTruck, X+4000, Y));
                    Y += 175;
                }

                /// cars
                Y = -1320;
                for (int i = 0; i < 4; i++)
                {
                    GameWorld.AddGameObject(new Solid(contents, miniTruck, X + 4000, Y));
                    Y += 175;
                }

                Y = -410;
                X = -3200;

                // adding huse og buske rund om dem
                for (int i = 0; i < 14; i++)
                {
                    Y = -410;
                    GameWorld.AddGameObject(new Solid(contents, House, X, Y));
                    Y += 260;           
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, parkeringplads, X, Y));
                    X += 400;
                }

                // adder plater melle, husene
                Y = -300;
                X = -3400;
                for (int i = 0; i < 14; i++)
                {
                    GameWorld.AddGameObject(new Solid(contents, Bush,X, Y));
                    X += 400;
                }
                
                X = -2000;
                X += 400;
                // adding huse og buske rund om dem
                for (int i = 0; i < 14; i++)
                {
                    Y = -1540;
                    GameWorld.AddGameObject(new Solid(contents, House, X, Y));
                    Y += 260;
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, parkeringplads, X, Y));
                    X += 400;
                }
                // adder plater melle, husene
                Y = -1500;
                X = -1800;
                for (int i = 0; i < 13; i++)
                {
                    GameWorld.AddGameObject(new Solid(contents, Bush, X, Y));
                    X += 400;
                }


                X = 2500;
                Y = 50;
                // addd fence
                for (int i = 0; i < 8; i++)
                {
                    Y -= 90;
                    GameWorld.AddGameObject(new Solid(contents, fencelodrat, X, Y));
                    
                
                }
                X = 3050;
                Y = 50;
                // addd fence
                for (int i = 0; i < 8; i++)
                {
                    Y -= 90;
                    GameWorld.AddGameObject(new Solid(contents, fencelodrat, X, Y));


                }
                X = 3000;
                Y = 0;
                // addd fence
                for (int i = 0; i < 6; i++)
                {
                 
                    GameWorld.AddGameObject(new Solid(contents, fenceVandrat, X, Y));

                     X -= 90;
                }
                X = 3000;
                Y = -720;
                for (int i = 0; i < 6; i++)
                {

                    GameWorld.AddGameObject(new Solid(contents, fenceVandrat, X, Y));

                    X -= 90;
                }
                // adding tres in the in fence


                X = 3000;
                Y = -500;
                GameWorld.AddGameObject(new Solid(contents, "trees/(19)", X - 100, Y+400));
                GameWorld.AddGameObject(new Solid(contents, tree+trees[9], X, Y));
                GameWorld.AddGameObject(new Solid(contents, tree+trees[3], X - 300, Y));
                GameWorld.AddGameObject(new Solid(contents, tree+trees[5], X -300, Y +400));


                //test addding weapons 
                GameWorld.AddGameObject(new Machingun(contents, Machingun, 300, 300));
                GameWorld.AddGameObject(new Shotgun(contents, shotgun,400, 300));

            }
        } 
        /// <summary>
        /// loader enemies 
        /// </summary>
        public void addEnemy()
        {

            string zombie1 = "zombiesmall";
            string zombie2 = "zombie1";
            string zombie3 = "zombie3";
            string zombie4 = "zombie2";
            string zombie5 = "zombie/move/skeleton-move_0";
            int y = 300;
            int x = -1000;
            Vector2 startposition;
            startposition.X = x;
            startposition.Y = y;

          // GameWorld.AddGameObject(new Enemy2(contents,zombie5 ,200,200,16,8));
            for (int i = 0; i < 10; i++)
            {
               
                GameWorld.AddGameObject(new Enemy2(contents, zombie5, x, y, 16, 8));
                x += 200;
                //  Thread.Sleep(100);               
            }
            x = -1000;
            y = 100;
            for (int i = 0; i < 10; i++)
            {

                GameWorld.AddGameObject(new Enemy(contents, zombie4, x, y, 11, 15));
                x += 200;
                Thread.Sleep(100);
            }
            x = -1000;
            y = 200;
            for (int i = 0; i < 10; i++)
            {
                GameWorld.AddGameObject(new Enemy(contents, zombie3, x, y, 5, 10));
                x += 100;
                ///   Thread.Sleep(100);
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






