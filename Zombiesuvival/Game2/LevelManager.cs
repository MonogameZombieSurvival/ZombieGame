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
        public static bool door1lvl2 = false;    
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
                    addEnemy();
                    break;
                case 2:
                    addGround();
                    addwater();
                    addobejt();
                    addEnemy();                
                    vej();
                   addObejtLvl2();
             
                    break;

                case 3:
                    addGround();
                    addEnemy();
                    vej();
                    addobejtlvl3();


                    break;
                case 4:
                    addGround();
                    addObejtlvl4();
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
         
            string[] ground = new string[] { "bg-grass2000'2", "Dirt 2 ", "BlackBagground","floor" } ;

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
            if (level == 3)
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
            }
            if(level == 4)
            {
                X = -4000;
                Y = -2000;
                for (int x = 0; x < 4; x++)
                {

                    for (int y = 0; y < 4; y++)
                    {
                        GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[2], X,Y));
                        Y += 2000;

                    }
                    Y = -2000;
                    X += 2000; 
                }
                X = 450;
                Y = -300;
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[3], X, Y));
                        Y += 200;
                    }
                    X += 200;
                    Y = -300;
                }
               
                
            }
        }
        public void addNextRooom()
        {
            string[] ground = new string[] { "bg-grass2000'2", "Dirt 2 ", "BlackBagground", "floor" };
            string[] walls = new string[] { "HouseWallOP", "HouseWall300", "HouseWall400", "door", "HouseWall" };
            string zombie1 = "zombiesmall";
            string zombie2 = "zombie1";
            string zombie3 = "zombie3";
            string zombie4 = "zombie2";
            string zombie5 = "zombie/move/skeleton-move_0";
            int X = 450;
            int Y = -1100;

            if (door1lvl2 == true)
            {
                for (int x = 0; x < 4; x++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        GameWorld.AddEFfect(new NoneSolidObejts(contents, ground[3], X, Y));
                        Y += 200;
                    }
                    X += 200;
                    Y =-1100;
                }
                 X = 350;
                Y = -800;
                GameWorld.AddGameObject(new SolidObejts(contents, walls[0], X, Y));
                X += 800;
                GameWorld.AddGameObject(new SolidObejts(contents, walls[0], X, Y));
                X -= 400;
                Y -= 400;
                GameWorld.AddGameObject(new SolidObejts(contents, walls[4], X, Y));

                /// add Zombies
                /// 
                for (int i = 0; i < 15; i++)
                {
                    X = rand.Next(400, 1000);
                    GameWorld.AddGameObject(new Enemy(contents, zombie4, X, Y, 11, 15));

                                    Y = rand.Next(-800, -450);
                }



                Y = 0;
                for (int i = 0; i < 15; i++)
                {
                    X = rand.Next(400, 1000);
                    GameWorld.AddGameObject(new Enemy(contents, zombie3, X, Y, 5, 10));

          
                    Y = rand.Next(-800, -450);
                }



                Y = -200;
                for (int i = 0; i < 15; i++)
                {
                    X = rand.Next(400, 1000);
                    GameWorld.AddGameObject(new Enemy2(contents, zombie5, X, Y, 16, 8));

                    Y = rand.Next(-800, -450);
                }

            }
            door1lvl2 = false;
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
        /// <summary>
        /// addobejtfor lvl 2
        /// </summary>
        public void addObejtLvl2()
        {
            string miniTruck = "Mini_truck";
  
        
         
            string[] Cars = new string[] { "Cars/truck" };

      
            string Gas = "boxs/barrel_top";
            string motorCykel = "mortorcykel";
            string serviceStaion = "servicestation";
            string benzintank = "Tankstation";
            string[] trees = new string[] { "(1)", "(2)", "(3)", "(4)", "(5)", "(6)",
                "(7)", "(8)", "(9)", "(10)", "(11)", "(12)", "(13)", "(14)", "(15)", "(16)", "(17)", "(18)", "(19)", "(20)", "(21)", "(22)", "(23)", "(24)", "(25)", "(26)", "(27)", "(28)" };
            int Y = 500;
            int X = 500;
            GameWorld.AddGameObject(new Gas(contents, Gas, X, Y));
          
            X = 1700;
            Y = -1150;
            GameWorld.AddGameObject(new Motorcyekel(contents, motorCykel,X,Y));
            /// add ccars
            /// 
            Y -= 300;
            X += 200;
            for (int i = 0; i < 3; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, miniTruck, X, Y));
                Y += 175;
            }
            X =870;
            Y = -2560;
            for (int i = 0; i < 3; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, Cars[0], X, Y));
                X -= 225;
            }
            X = 870;
            Y =1000;
            for (int i = 0; i < 3; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, Cars[0], X, Y));
                X -= 260;
            }
            X = -2100;
            Y = -1300;
            GameWorld.AddGameObject(new SolidObejts(contents, serviceStaion, X, Y));
            X += 300;
            Y -= 200;
            GameWorld.AddGameObject(new SolidObejts(contents, benzintank, X, Y));  
                   Y += 400;
            GameWorld.AddGameObject(new SolidObejts(contents, benzintank, X, Y));

            Y += 200;
            X -= 100;

            GameWorld.AddGameObject(new Gas(contents, Gas, X, Y));

            // addd fence
            addfencelvl2();
        }
        /// <summary>
        /// adddingfence for lvlv 2
        /// </summary>
       public void addfencelvl2()
        {
            string fenceVandrat = "fenceVandrat";
            string fencelodrat = "fencelodrat";
            int Y;
            int X;

            Y = 1200;
            X = 1000;
            // addd fence
            for (int i = 0; i < 24; i++)
            {
                Y -= 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
            }
            Y = 1200;
            X = 200;
            // addd fence
            for (int i = 0; i < 24; i++)
            {
                Y -= 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
            }
            Y -= 45;
            X -= 45;
            for (int i = 0; i < 17; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
                X -= 90;
            }
            Y -= 45;
            X += 45;
            for (int i = 0; i < 4; i++)
            {
                Y += 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
            }
            Y += 45;
            X -= 45;
            for (int i = 0; i < 12; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
                X -= 90;
            }
            Y += 45;
            X += 45;
            for (int i = 0; i < 13; i++)
            {
                Y -= 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
            }
            Y -= 45;
            X += 45;
            for (int i = 0; i < 12; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
                X += 90;
            }
            Y -= 45;
            X -= 45;
            for (int i = 0; i < 3; i++)
            {
                Y += 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
            }
            Y += 45;
            X += 45;
            for (int i = 0; i < 18; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
                X += 90;
            }
            Y += 45;
            X -= 45;
            for (int i = 0; i < 20; i++)
            {
                Y -= 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
            }
            X = 1000;
            for (int i = 0; i < 20; i++)
            {

                GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
                Y += 90;
            }
            Y -= 45;
            X += 45;
            for (int i = 0; i < 18; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
                X += 90;
            }
            X -= 90 * 18;
            Y += 540;
            for (int i = 0; i < 18; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
                X += 90;
            }
        }
        /// <summary>
        /// adds ovejter for lvl 3
        /// </summary>
        public void addobejtlvl3()
        {
            string[] trees = new string[] { "(1)", "(2)", "(3)", "(4)", "(5)", "(6)",
                "(7)", "(8)", "(9)", "(10)", "(11)", "(12)", "(13)", "(14)", "(15)", "(16)", "(17)", "(18)", "(19)", "(20)", "(21)", "(22)", "(23)", "(24)", "(25)", "(26)", "(27)", "(28)" };


            string NethasHouse = "nethansHouse";
            string NethasHousemedahve = "nethansHousemwshave";
            string miniTruck = "Mini_truck";
            string[] Cars = new string[] { "Cars/truck" };
            string Gas = "boxs/barrel_top";
            string motorCykel = "mortorcykel";
            string serviceStaion = "servicestation";
            string benzintank = "Tankstation";
           
            string fenceVandrat = "fenceVandrat";
            string fencelodrat = "fencelodrat";
          

            int Y = -2585;
            int X = 1400;
           
            GameWorld.AddEFfect(new NoneSolidObejts(contents, NethasHousemedahve, X, Y));
             Y -= 57 ;
             X -= 30;
            GameWorld.AddGameObject(new SolidObejts(contents, NethasHouse, X, Y));
            X = 700;
            Y = 500;
            GameWorld.AddGameObject(new Motorcyekel(contents, "mortorcykel", X, Y));

            Y = 1000;
            X = 1000;
            // addd fence
            for (int i = 0; i < 30; i++)
            {
                Y -= 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
            }

            Y -= 700;
            for (int i = 0; i < 30; i++)
            {
                Y -= 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
            }

            Y = -1745;
            X = 955;
            for (int i = 0; i < 30; i++)
            {

                X += 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
            }
            Y = 1000;
            X = 200;
            // addd fence
            for (int i = 0; i < 70; i++)
            {
                Y -= 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
            }

            Y = -3000;
            X = 955;
            for (int i = 0; i < 10; i++)
            {

                X += 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
            }
            Y -= 45;
            X += 45;
            for (int i = 0; i < 6; i++)
            {

                Y += 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fencelodrat, X, Y));
            }
            Y += 45;
            X -= 45;
            for (int i = 0; i < 20; i++)
            {

                X += 90;
                GameWorld.AddGameObject(new SolidObejts(contents, fenceVandrat, X, Y));
            }

         
            //add truck
            X = 870;
            Y = 700;
            for (int i = 0; i < 3; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, Cars[0], X, Y));
                X -= 260;
            }

            //add truck
            X = 870;
            Y = -4400;
            for (int i = 0; i < 3; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, Cars[0], X, Y));
                X -= 260;
            }
            X = 2440;
            Y = -2350;
            /// atminitruck
            for (int i = 0; i < 4; i++)
            {
                GameWorld.AddGameObject(new SolidObejts(contents, miniTruck, X, Y));
                Y += 175;
            }

        }
        /// <summary>
        /// adds ovejter for lvl 4
        /// </summary>
        public void addObejtlvl4()
        {
            string[] walls = new string[] { "HouseWallOP","HouseWall300", "HouseWall400", "door" };

            int X = 0;
            int Y = 0;
            X += 350;
            Y += 0;
            GameWorld.AddGameObject(new SolidObejts(contents, walls[0], X, Y));
             X += 800;
            GameWorld.AddGameObject(new SolidObejts(contents, walls[0], X, Y));
            Y += 400;
            X = 490;
            GameWorld.AddGameObject(new SolidObejts(contents, walls[1], X, Y));
            X += 470;
            GameWorld.AddGameObject(new SolidObejts(contents, walls[2], X, Y));
            X = 540;
            Y -= 800;
            GameWorld.AddGameObject(new SolidObejts(contents, walls[2], X, Y));
            X += 470;
            GameWorld.AddGameObject(new SolidObejts(contents, walls[1], X, Y));
            X -= 210;
            Y -= 10;
            GameWorld.AddGameObject(new SolidObejts(contents, walls[3], X, Y,"door"));
            Y += 20;
            GameWorld.AddGameObject(new NoneSolidObejts(contents, walls[3], X, Y,"door"));
            Y += 810;
            X -= 100;
            GameWorld.AddGameObject(new SolidObejts(contents, walls[3], X, Y));
            Y -= 20;
            GameWorld.AddGameObject(new NoneSolidObejts(contents, walls[3], X, Y));




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
            if(level == 2)
            {
                x = -1800;
                y = -1300;
                GameWorld.AddGameObject(new Boss(contents, x, y));

                y = 0;
                for (int i = 0; i <15; i++)
                {
                    x = rand.Next(300, 900);
                    GameWorld.AddGameObject(new Enemy(contents, zombie4, x, y, 11, 15));

                    Thread.Sleep(100);
                    y -= rand.Next(100, 300);
                }



                y = 0;
                for (int i = 0; i < 15; i++)
                {
                    x = rand.Next(300, 900);
                    GameWorld.AddGameObject(new Enemy(contents, zombie3, x, y, 5, 10));

                    Thread.Sleep(100);
                    y -= rand.Next(0, 300);
                }


            
                y = -200;
                for (int i = 0; i < 15; i++)
                {
                    x = rand.Next(300, 900);
                    GameWorld.AddGameObject(new Enemy2(contents, zombie5, x, y, 16, 8));

                    Thread.Sleep(100);
                    y -= rand.Next(100, 200);
                }


                /// vandrat
                x = -1500;
                for (int i = 0; i < 5; i++)
                {
                    y = rand.Next(-1400, -1000);
                    GameWorld.AddGameObject(new Enemy2(contents, zombie5, x, y, 16, 8));
                    x += 400;
                    Thread.Sleep(100);
                }
              
              
                for (int i = 0; i < 5; i++)
                {

                    y = rand.Next(-1400, -1000);
                    GameWorld.AddGameObject(new Enemy(contents, zombie4, x, y, 11, 15));
                    x += rand.Next(0, 600);
                 
                    Thread.Sleep(100);
                }
              
                for (int i = 0; i < 5; i++)
                {
                    GameWorld.AddGameObject(new Enemy(contents, zombie3, x, y, 5, 10));
                    x += rand.Next(0, 500);
                    Thread.Sleep(100);
                    y = rand.Next(-1400, -1000);
                }





            }
            if (level == 3)
            {
              
                y = 0;
                for (int i = 0; i < 15; i++)
                {
                    x = rand.Next(300, 900);
                    GameWorld.AddGameObject(new Enemy(contents, zombie4, x, y, 11, 15));

                    Thread.Sleep(100);
                    y -= rand.Next(100, 300);
                }



                y = 0;
                for (int i = 0; i < 15; i++)
                {
                    x = rand.Next(300, 900);
                    GameWorld.AddGameObject(new Enemy(contents, zombie3, x, y, 5, 10));

                    Thread.Sleep(100);
                    y -= rand.Next(0, 300);
                }



                y = -200;
                for (int i = 0; i < 15; i++)
                {
                    x = rand.Next(300, 900);
                    GameWorld.AddGameObject(new Enemy2(contents, zombie5, x, y, 16, 8));

                    Thread.Sleep(100);
                    y -= rand.Next(100, 200);
                }


                x = 500;
                for (int i = 0; i < 15; i++)
                {

                    y = rand.Next(-2200, -1800);
                    GameWorld.AddGameObject(new Enemy2(contents, zombie5, x, y, 16, 8));
                    x += 200;
                    Thread.Sleep(100);
                }

                x = 500;
                for (int i = 0; i < 15; i++)
                {

                    y = rand.Next(-2200, -1800);
                    GameWorld.AddGameObject(new Enemy(contents, zombie4, x, y, 11, 15));
                    x += rand.Next(0, 200);

                    Thread.Sleep(100);
                }
                x = 500;
                for (int i = 0; i < 15; i++)
                {

                    y = rand.Next(-2200, -1800);
                    GameWorld.AddGameObject(new Enemy(contents, zombie3, x, y, 5, 10));
                    x += rand.Next(0, 200);
                    Thread.Sleep(100);
                  
                }


            }
            if(level == 4)
            {
                y = -100;
                for (int i = 0; i <15; i++)
                {
                    x = rand.Next(400, 1000);
                    GameWorld.AddGameObject(new Enemy(contents, zombie4, x, y, 11, 15));

                    Thread.Sleep(100);
                    y = rand.Next(-300, -100);
                }



                y = 0;
                for (int i = 0; i < 15; i++)
                {
                    x = rand.Next(400, 1000);
                    GameWorld.AddGameObject(new Enemy(contents, zombie3, x, y, 5, 10));

                    Thread.Sleep(100);
                    y = rand.Next(-300, -100);
                }



                y = -200;
                for (int i = 0; i < 15; i++)
                {
                    x = rand.Next(400, 1000);
                    GameWorld.AddGameObject(new Enemy2(contents, zombie5, x, y, 16, 8));

                    Thread.Sleep(100);
                    y = rand.Next(-300, -100);
                }


            }
        }

         public void vej()
        {
            string vej = "vej";
            string vejop = "vejop";
            string Plasa = "Plaza_3";
            string TKrydslodrat = "TN_2";
            string krydsvent = "krydsvendt";
            string kryds = "XN_1";
            string TKrydsvenstre = "TN_4";
            int Y = 720;
            int X = 600;
            if (level == 2)
            {


      // vej ned
                for (int i = 0; i < 7; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vejop, X, Y));

                    Y += 283;
                }
                // kryds

                Y -= 283 * 7;
                // vej op
                for (int i = 0; i <7; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vejop, X, Y));

                    Y -= 283;
                }
                // kryds

          
                for (int i = 0; i <9; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vej, X, Y));

                    X += 283;
                }

                X = 600;
                for (int i = 0; i < 9; i++)
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
                X = -2500;
                Y = -695;
                for (int x = 0; x < 3; x++)
                {
                    
                    Y -= 283;
                    for (int y = 0; y < 3; y++)
                    {

                        X += 283;
                        GameWorld.AddEFfect(new NoneSolidObejts(contents, Plasa, X, Y));
                    }
                    X -= 283 * 3;
                }




            }
            if(level == 3)
            {
                // vej op
                for (int i = 0; i < 10; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vejop, X, Y));

                    Y -= 283;
                }


                for (int i = 0; i < 15; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vej, X, Y));

                    X += 283;
                }

              
                X = 600;
                GameWorld.AddEFfect(new NoneSolidObejts(contents, TKrydsvenstre, X, Y));
                Y -= 283;
                // vej op
                for (int i = 0; i < 7; i++)
                {
                    GameWorld.AddEFfect(new NoneSolidObejts(contents, vejop, X, Y));

                    Y -= 283;
                }

            }
        }

       
        public void Zombielvl3()
        {

        }

     








    }
}






