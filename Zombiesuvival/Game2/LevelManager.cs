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
    class LevelManager
    {
        private int level;
        private GraphicsDevice graphicsDevice;
        private ContentManager contents;
        private Random rand = new Random();
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
        public LevelManager(ContentManager content, int Level)
        {
            level = Level;
            contents = content;
            int X;
            int Y;


            switch (level)
            {

                case 1:
                    addGround();
                    addwater();
                    addobejt();
                   // addEnemy();
                    break;
                case 2:
                    addGround();
                    addwater();
                    addobejt();
                    addEnemy();                
                    vej();
                   addObejtLvl2();
                   Zombieslvl2();
                    break;

                case 3:
                    addGround();
                    addwater();
                    addobejt();
                    addEnemy();
                    break;
                case 4:
                    addGround();
                    addwater();
                    addobejt();
                    addEnemy();
                    break;
                default:
                    break;
            }

            if(level == 1)
            {           
                
            }

           
        }


        /// <summary>
        /// loader jorden playeren skal gå på;
        /// </summary>
        public void addGround()
        {
         
            string[] ground = new string[] { "bg-grass2000'2", "Dirt 2 " } ;

            string HaberStone = "Haber";
            string vej = "vej";
            string vejop = "vejop";
            string kryds = "TN_2";
            string krydsvent = "krydsvendt";
            int Y = 371;
            int X = -2000;
            if (level == 1)
            {
                // add grass
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], -4000, 0));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], -2000, 0));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], 0, 0));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], 2000, 0));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], 4000, 0));
                                                                        
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], -4000, -2000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], -2000, -2000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], 0, -2000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], 2000, -2000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], 4000, -2000));
                                                                        
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], -4000, -4000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], -2000, -4000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], 0, -4000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], 2000, -4000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[0], 4000, -4000));


                // adds haven
                Y = 371;
                X = -2000;
                for (int i = 0; i < 19; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, HaberStone, X, Y));
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
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vej, X, Y));
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
                for (int i = 0; i < 15; i++)
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
                Y = -928;

                /// mere vej efter kryd til højre opppe
                X = 2293;
                X += 283;

                for (int i = 0; i < 3; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vej, X, Y));
                    X += 283;
                }
                X += 283;
                Y = -1090;
                X = -2000;

                for (int i = 0; i < 19; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, HaberStone, X, Y));
                    X += 283;
                }
            }
            if(level == 2)
            {
                // add grass
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], -4000, 0));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], -2000, 0));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], 0, 0));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], 2000, 0));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], 4000, 0));
                                                                    
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], -4000, -2000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], -2000, -2000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], 0, -2000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], 2000, -2000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], 4000, -2000));

                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], -4000, -4000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], -2000, -4000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], 0, -4000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], 2000, -4000));
                GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[1], 4000, -4000));
            }

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
                    GameWorld.AddGameObject(new SolidObejts(contents, miniTruck, X, Y));
                    Y += 175;
                }
                //cars
                Y = 120;
                for (int i = 0; i < 2; i++)
                {
                    GameWorld.AddGameObject(new SolidObejts(contents, miniTruck, X + 4000, Y));
                    Y += 175;
                }

                /// cars
                Y = -1320;
                for (int i = 0; i < 4; i++)
                {
                    GameWorld.AddGameObject(new SolidObejts(contents, miniTruck, X + 4000, Y));
                    Y += 175;
                }


                Y = -1090;
                X = -2600;
                for (int i = 0; i < 3; i++)
                {
                    GameWorld.AddGameObject(new SolidObejts(contents, miniTruck, X, Y));
                    Y += 175;
                }

                Y = -410;
                X = -3200;

                // adding huse og buske rund om dem
                for (int i = 0; i < 14; i++)
                {
                    Y = -410;
                    GameWorld.AddGameObject(new SolidObejts(contents, House, X, Y));
                    Y += 260;
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, parkeringplads, X, Y));
                    X += 400;
                }

                // adder plater melle, husene
                Y = -300;
                X = -3400;
                for (int i = 0; i < 14; i++)
                {
                    GameWorld.AddGameObject(new SolidObejts(contents, Bush, X, Y));
                    X += 400;
                }

                X = -2000;
                X += 400;
                // adding huse og buske rund om dem
                for (int i = 0; i < 14; i++)
                {
                    Y = -1540;
                    GameWorld.AddGameObject(new SolidObejts(contents, House, X, Y));
                    Y += 260;
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, parkeringplads, X, Y));
                    X += 400;
                }
                // adder plater melle, husene
                Y = -1500;
                X = -1800;
                for (int i = 0; i < 13; i++)
                {
                    GameWorld.AddGameObject(new SolidObejts(contents, Bush, X, Y));
                    X += 400;
                }
                X = -1800;
                GameWorld.AddGameObject(new SolidObejts(contents, Bush, X-130, Y));

                X = 2500;
                Y = 50;
                // addd fence
                for (int i = 0; i < 8; i++)
                {
                    Y -= 90;
                    GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));


                }
                X = 3050;
                Y = 50;
                // addd fence
                for (int i = 0; i < 8; i++)
                {
                    Y -= 90;
                    GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));


                }
                X = 3000;
                Y = 0;
                // addd fence
                for (int i = 0; i < 6; i++)
                {

                    GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));

                    X -= 90;
                }
                X = 3000;
                Y = -720;
                for (int i = 0; i < 6; i++)
                {

                    GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));

                    X -= 90;
                }
                // adding tres in the in fence
                X = 3000;
                Y = -500;
                GameWorld.AddGameObject(new SolidObejts(contents, "trees/(19)", X - 100, Y + 400));
                GameWorld.AddGameObject(new SolidObejts(contents, tree + trees[9], X, Y));
                GameWorld.AddGameObject(new SolidObejts(contents, tree + trees[3], X - 300, Y));
                GameWorld.AddGameObject(new SolidObejts(contents, tree + trees[5], X - 300, Y + 400));



                //fence for house garden
                X = 2130;
                Y = -570;
                for (int i = 0; i < 14; i++)
                {
                    GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
                    Y -= 90;
                    GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
                    Y -= 45;
                    X -= 45;
                    GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
                    X -= 90;
                    GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
                    X -= 90;
                    GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
                    Y += 45;
                    X -= 45;
                    GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
                    Y += 90;
                    GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
                    /// adds tress to garen
                    GameWorld.AddGameObject(new SolidObejts(contents, tree + trees[3], X + 70, Y - 30));
                    GameWorld.AddGameObject(new SolidObejts(contents, tree + trees[8], X + 50, Y - 100));
                    GameWorld.AddGameObject(new SolidObejts(contents, tree + trees[14], X + 190, Y - 40));

                    X -= 130;
                }

                //X = 2130;
                //Y = -1700;
                //for (int i = 0; i < 10; i++)
                //{
                //    GameWorld.AddGameObject(new Solid(contents, fencelodrat, X, Y));
                //    Y -= 90;
                //    GameWorld.AddGameObject(new Solid(contents, fencelodrat, X, Y));
                //    Y -= 45;
                //    X -= 45;
                //    GameWorld.AddGameObject(new Solid(contents, fenceVandrat, X, Y));
                //    X -= 90;
                //    GameWorld.AddGameObject(new Solid(contents, fenceVandrat, X, Y));
                //    X -= 90;
                //    GameWorld.AddGameObject(new Solid(contents, fenceVandrat, X, Y));
                //    Y += 45;
                //    X -= 45;
                //    GameWorld.AddGameObject(new Solid(contents, fencelodrat, X, Y));
                //    Y += 90;
                //    GameWorld.AddGameObject(new Solid(contents, fencelodrat, X, Y));
                //    / adds tress to garen
                //    GameWorld.AddGameObject(new Solid(contents, tree + trees[3], X + 70, Y - 30));
                //    GameWorld.AddGameObject(new Solid(contents, tree + trees[8], X + 50, Y - 100));
                //    GameWorld.AddGameObject(new Solid(contents, tree + trees[14], X + 190, Y - 40));

                //    X -= 130;
                //}




                // adding more fence
                X = -2000;
                Y = -1220;
                for (int i = 0; i < 20; i++)
                {
                    GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
                    Y -= 90;
                }
                X = -2500;
                Y = -1220;
                for (int i = 0; i < 20; i++)
                {
                    GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
                    Y -= 90;
                }
                Y = -1175;
                X = -2545;
                for (int i = 0; i < 20; i++)
                {
                    GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
                    X -= 90;
                }




                //test addding weapons 
                GameWorld.AddGameObject(new Machingun(contents, Machingun, 300, 300));
                GameWorld.AddGameObject(new Shotgun(contents, shotgun, 400, 300));

            }
        }

        public void addObejtLvl2()
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
            string Gas = "boxs/barrel_top";
            string motorCykel = "mortorcykel";

            string[] trees = new string[] { "(1)", "(2)", "(3)", "(4)", "(5)", "(6)",
                "(7)", "(8)", "(9)", "(10)", "(11)", "(12)", "(13)", "(14)", "(15)", "(16)", "(17)", "(18)", "(19)", "(20)", "(21)", "(22)", "(23)", "(24)", "(25)", "(26)", "(27)", "(28)" };
            int Y = 500;
            int X = 500;
            GameWorld.AddGameObject(new Gas(contents, Gas, X, Y));
          
            X = 700;

            GameWorld.AddGameObject(new Motorcyekel(contents, "mortorcykel",X,Y));
            



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
         
     
            /// zombies at haber
            if (level == 1)
            {
                GameWorld.AddGameObject(new Enemy2(contents, zombie5, 200, 200, 16, 8));
                for (int i = 0; i < 5; i++)
                {
                    y = rand.Next(200, 300);
                    GameWorld.AddGameObject(new Enemy2(contents, zombie5, x, y, 16, 8));
                    x += 400;
                    Thread.Sleep(100);
                }
                x = -500;
                y = 100;
                for (int i = 0; i < 5; i++)
                {

                    GameWorld.AddGameObject(new Enemy(contents, zombie4, x, y, 11, 15));
                    x += rand.Next(100, 300);
                    y = rand.Next(50, 100);
                    Thread.Sleep(100);
                }
                x = 0;
                y = 200;
                for (int i = 0; i < 5; i++)
                {
                    GameWorld.AddGameObject(new Enemy(contents, zombie3, x, y, 5, 10));
                    x += rand.Next(50, 400);
                    Thread.Sleep(100);
                    y = rand.Next(100, 200);
                }



                //zombier lodrat
                y = 200;
                for (int i = 0; i < 5; i++)
                {
                    x = rand.Next(2300, 2500);
                    GameWorld.AddGameObject(new Enemy(contents, zombie4, x, y, 11, 15));

                    Thread.Sleep(100);
                    y -= rand.Next(100, 300);
                }



                y = -200;
                for (int i = 0; i < 5; i++)
                {
                    x = rand.Next(2300, 2500);
                    GameWorld.AddGameObject(new Enemy(contents, zombie3, x, y, 5, 10));

                    Thread.Sleep(100);
                    y -= rand.Next(0, 300);
                }



                y = -200;
                for (int i = 0; i < 5; i++)
                {
                    x = rand.Next(2300, 2500);
                    GameWorld.AddGameObject(new Enemy2(contents, zombie5, x, y, 16, 8));

                    Thread.Sleep(100);
                    y -= rand.Next(100, 200);
                }


                x = -2000;
                y = -1100;
                for (int i = 0; i < 5; i++)
                {

                    GameWorld.AddGameObject(new Enemy2(contents, zombie5, x, y, 16, 8));
                    x += rand.Next(0, 1000);
                    Thread.Sleep(100);
                }
                x = -2000;
                y = -1100;
                for (int i = 0; i < 5; i++)
                {

                    GameWorld.AddGameObject(new Enemy(contents, zombie4, x, y, 11, 15));
                    x += rand.Next(0, 1000);

                    Thread.Sleep(100);
                }
                x = -2000;
                y = -1200;
                for (int i = 0; i < 5; i++)
                {
                    GameWorld.AddGameObject(new Enemy(contents, zombie3, x, y, 5, 10));
                    x += rand.Next(50, 1000);
                    Thread.Sleep(100);
                }
            }
        }
     
        /// <summary>
        /// Add zombies in lvl 2
        /// </summary>
   public void Zombieslvl2()
        {


            string zombie1 = "zombiesmall";
            string zombie2 = "zombie1";
            string zombie3 = "zombie3";
            string zombie4 = "zombie2";
            string zombie5 = "zombie/move/skeleton-move_0";
            string BossZombie = "bosszombie";
            int y = 300;
            int x = 500;

            GameWorld.AddGameObject(new Boss(contents, y, x));

        }
         public void vej()
        {
            string vej = "vej";
            string vejop = "vejop";
            string TKrydslodrat = "TN_2";
            string krydsvent = "krydsvendt";
            string kryds = "XN_1";

            int Y = 720;
            int X = 600;
            if (level == 2)
            {
                // vej op
                for (int i = 0; i <7; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vejop, X, Y));

                    Y -= 283;
                }
                // kryds


                for (int i = 0; i < 7; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vej, X, Y));

                    X += 283;
                }

                X = 600;
                for (int i = 0; i < 7; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vej, X, Y));

                    X -= 283;
                }
                X = 600;
                GameWorld.AddEFfect(new NoneSolidObejts(contents, kryds, X, Y));
                Y -= 283;
                // vej op
                for (int i = 0; i < 7; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vejop, X, Y));

                    Y -= 283;
                }

            }

        }

     








    }
}






