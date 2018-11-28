﻿using Microsoft.Xna.Framework;
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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWorld : Game
    {
        
        private SpriteBatch spriteBatch;
        /// <summary>
        ///     lists a obejts
        /// </summary>
        public List<GameObject> gameObjects = new List<GameObject>();
        private static List<GameObject> toBeAdded = new List<GameObject>();

        public List<GameObject> solidObejts = new List<GameObject>();
        private static List<GameObject> toBeAddeSolid = new List<GameObject>();

        public List<GameObject> Effects = new List<GameObject>();
        private static List<GameObject> toBeAddedEffect = new List<GameObject>();
        private static List<GameObject> toBeRemoved = new List<GameObject>();
       
        

        /// <summary>
        ///     Classes
        /// </summary>
        private Solid solid;
        private BloodEffect blood;
        private Player player;
        private GameTimer gametimer;
        private GameTimer Spawnspeed;
        private Levels level;
        private sighte sighte;

        /// <summary>
        /// Texttures,song, and text
        /// </sTummary>
        private SpriteFont font;      
        private SpriteFont WaveTimer;
        private SpriteFont KillCount;
        private Texture2D collisionTexture;
        private Song backgroundMusic;
        private Texture2D Sighte;
        private Texture2D backgroundImg;
        private Texture2D backgroundImgEnd;
        private Texture2D backgroundImgWin;
        private Song bossSound;
        Camera camera;
        Random rand = new Random();

        
        
        
        /// <summary>
        /// fileds / varibler
        /// </summary>
        public static int ScreenWith;
        public static int screenHeight;

       
        private int ammount = 0;
        private int WaveTimeOutPut;
        
        private int NumberOfgameObejts;
        static private int healthHold;
        public int HealhHold
        {

            get
            {
                return healthHold;
            }
        }

        static private int kills;
        public int Kills
        {
            get {
                return kills;

            }
        }
        private double spawtimeBetwenneEnemys; 

        private static GraphicsDeviceManager graphics;
       
        public static Rectangle ScreenSize
        {
            get
            {
                return graphics.GraphicsDevice.Viewport.Bounds;
            }
        }
        public  static void addKill()
        {
            kills += 1;
            
            
        }


        public static void DealDamngeToPlayer(int damnge)
        {

            healthHold -= damnge;

            
        }
        /// <summary>
        /// Timer 
        /// </summary>


        /*
        private static ContentManager _content;
        public static ContentManager ContentManager
        {
            get
            {
                return _content;
            }
        }
       */

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
          //  graphics.IsFullScreen = true;
            // _content = Content;
        }

        public static void AddGameObject(GameObject go)
        {
            toBeAdded.Add(go);
        }
        /// <summary>
        /// ass and grathic effect wich the player can on top on ;
        /// </summary>
        /// <param name="go"></param>
        public static void AddEFfect(GameObject go)
        {
            toBeAddedEffect.Add(go);
        }
        /// <summary>
        ///    adds solid obejt a obejt the player go thoruth
        /// </summary>
        /// <param name="go"></param>
        public static void AddSolid(GameObject go)
        {
            toBeAddeSolid.Add(go);
        }
        /// <summary>
        ///        adds to obejts there well be removed
        /// </summary>
        /// <param name="go"></param>
        public static void RemoveGameObject(GameObject go)
        {
            toBeRemoved.Add(go);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
             this.IsMouseVisible = true;
            screenHeight = graphics.PreferredBackBufferHeight;
          
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //backgroundMusic = Content.Load<Song>("zombiesound");
            //MediaPlayer.Play(backgroundMusic);
            //MediaPlayer.IsRepeating = true;

            //bossSound = Content.Load<Song>("bosssound");

            camera = new Camera(graphics.GraphicsDevice.Viewport);
            //Background Img
            backgroundImg = Content.Load<Texture2D>("bg-grass");
            backgroundImgEnd = Content.Load<Texture2D>("gameover");
            backgroundImgWin = Content.Load<Texture2D>("winscreen");
            Sighte = Content.Load<Texture2D>("sighte");


            player = new Player(Content);
            sighte = new sighte(Content);


            healthHold = player.Health;
            gameObjects.Add(player);
            gameObjects.Add(sighte);

            level = new Levels();

            switch (level.Level)
            {

                case 1:
                    Loadlvl1();
                    break;
                case 2:
                   
                    break;


                default:

                    break;
            }
            if (level.Level == 1)
            



            // Create a timer with a two second interval.

            // Hook up the Elapsed event for the timer. 

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("ExampleFont");
            WaveTimer = Content.Load<SpriteFont>("WaveTimer");
            KillCount = Content.Load<SpriteFont>("KillCount");
            collisionTexture = Content.Load<Texture2D>("CollisionTexture");

            Spawnspeed = new GameTimer();
            gametimer = new GameTimer();
           
        }


        public void Loadlvl1()
        {

            int X;
            int Y;
            solid = new Solid(Content);
            backgroundImg = Content.Load<Texture2D>("bg-grass");

            gameObjects.Add(new Solid(Content, "Tileset", 250, 250));
            gameObjects.Add(new Solid(Content, "Tileset", 400, 250));
         
                gameObjects.Add(new Solid(Content, "water",1100,600));
   
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }



        /// <summary>
        /// SpawnAynemeas
        /// </summary>
        public void SpawnAnymens(double spawnCircle)
        {          
            if(spawnCircle <=0.0001)
            {
              gameObjects.Add(new Enemy(rand.Next(0, 400), rand.Next(0, 400), Content));                                       
            }          
        }
        /// <summary>
        /// summons boss
        /// </summary>
 
        public void SpawnBoss(double spawnCircle, int ammountBoss)
        {
            if (spawnCircle <= 0.0001)
            {
                if (ammount < ammountBoss) {
                    ammount++;

                    MediaPlayer.Play(bossSound);
                    
                    gameObjects.Add(new Boss(rand.Next(0, 400), rand.Next(0, 400), Content));
                }
            }
        }
        /// <summary>
        /// sets level
        /// </summary>
        /// <param name="WavetimeOutput"></param>
     



        
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            //// gameObjects = level1.GameObejts(gameTime, level,gameObjects);
           
            //if (level.Level == 1)
            //{
            //    spawtimeBetwenneEnemys = Spawnspeed.gameTimerMIlilesecs(gameTime, 0.7, 0.01);
            //    SpawnAnymens(spawtimeBetwenneEnemys);

            //}
            //if (level.Level == 2)
            //{

            //    spawtimeBetwenneEnemys = Spawnspeed.gameTimerMIlilesecs(gameTime, 0.6, 0.01);

            //    SpawnAnymens(spawtimeBetwenneEnemys);
            //}
            //if (level.Level == 3)
            //{

            //    spawtimeBetwenneEnemys = Spawnspeed.gameTimerMIlilesecs(gameTime, 0.5, 0.01);

            //    SpawnAnymens(spawtimeBetwenneEnemys);
            //}

            //if (level.Level == 4)
            //{

            //    spawtimeBetwenneEnemys = Spawnspeed.gameTimerMIlilesecs(gameTime, 0.4, 0.01);
            //    SpawnAnymens(spawtimeBetwenneEnemys);

            //}
            //if (level.Level == 5)
            //{
            //    spawtimeBetwenneEnemys = Spawnspeed.gameTimerMIlilesecs(gameTime, 0.3, 0.01);
            //    SpawnBoss(spawtimeBetwenneEnemys, 1);
            //}





            WaveTimeOutPut = gametimer.gameTimerSec(gameTime, 29999);// level clock// spawn clock
               level.Setlevel(WaveTimeOutPut);
           
                camera.update(player.playerPosition);
               


            foreach (GameObject go in gameObjects)
            {

                player.Health = healthHold;
                go.Update(gameTime);
               
                go.GetPlayerPosition(player.playerPosition);

                go.GetSightePosition(player.Sightpostotion);

                // check for colisions
                foreach (GameObject other in gameObjects)
                {
                    if (go != other && go.IsColliding(other))
                    {
                        go.DoCollision(other);
                    }
                }
                
            }// update gameobejts




            foreach (GameObject go in solidObejts)
            {

                foreach (GameObject other in solidObejts)
                {
                    if (go != other && go.IsColliding(other))
                    {
                        go.DoCollision(other);
                    }
                }

            }



            foreach (GameObject go in toBeRemoved)
            {
                gameObjects.Remove(go);
            }/// remove gameobejts
            toBeRemoved.Clear();
           
        
            Effects.AddRange(toBeAddedEffect);
            toBeAddedEffect.Clear();
            gameObjects.AddRange(toBeAdded);
            toBeAdded.Clear();

            

            }


       

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


           

            spriteBatch.Begin(SpriteSortMode.Deferred,
                BlendState.AlphaBlend,null,null,null,null,camera.Transform);


             if (level.Level == 1)
            {

                DrawLvl1();
            }
             


            player.Draw(spriteBatch);



            NumberOfgameObejts = Effects.Count;
            foreach(GameObject GO in Effects)
            {
                GO.Draw(spriteBatch);
#if DEBUG
                DrawCollisionBox(GO);
#endif
            }

               foreach (GameObject GO in solidObejts)
            {
                GO.Draw(spriteBatch);
#if DEBUG
                DrawCollisionBox(GO);
#endif
            }

            foreach (GameObject go in gameObjects)
            {
                go.Draw(spriteBatch);
#if DEBUG
                DrawCollisionBox(go);
#endif
            }

            if (healthHold <= 0)
            {

                        spriteBatch.Draw(backgroundImgEnd, new Rectangle(0, 0, 1280, 720), Color.White);
                
                
              
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    gameObjects.Clear();
                    Effects.Clear();
                    gameObjects.Add(player = new Player(Content));
                    gametimer = new GameTimer();
                    level.Level = 1;
                    kills = 0;
                    healthHold = 1000;
                    gametimer.gameTimerSec(gameTime, 30);// level clock// spawn clock
                }
              

                }



            if (level.Level == 5)
            {
                spriteBatch.Draw(backgroundImgWin, new Rectangle(0, 0, 1280, 720), Color.White);
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    gameObjects.Clear();
                    Effects.Clear();
                    gameObjects.Add(player = new Player(Content));
                    gametimer = new GameTimer();
                    
                    kills = 0;
                    healthHold = 1000;
                    gametimer.gameTimerSec(gameTime, 30);// level clock// spawn clock
                }

                //Exit();
            }


            if (healthHold > 0 || level.Level == 5) {
                spriteBatch.DrawString(WaveTimer, $"Next wave in:{WaveTimeOutPut} level:{level}", new Vector2(580, 5), Color.White);
                spriteBatch.DrawString(font, $"Health:{player.Health}", new Vector2(5, 5), Color.White);
                spriteBatch.DrawString(KillCount, $"KilleCount:{Kills}", new Vector2(1160, 5), Color.Red);
            }

            
            spriteBatch.End();
            base.Draw(gameTime);
            
        }


        public void DrawLvl1()
        {
            int x=0;
            int y=0;

            for (int i = 0; i < 10; i++)
            {

               
                for (int l = 0; l <10; l++)
                {

                    spriteBatch.Draw(backgroundImg, new Rectangle(x, y, 1000, 1000), Color.White);


                 
                    y = + 1000;
                }
                x += 1000;
                y = 0;
            }

     


        }
























        private void DrawCollisionBox(GameObject go)
        {
            Rectangle collisionBox = go.CollisionBox;
            Rectangle topLine = new Rectangle(collisionBox.X, collisionBox.Y, collisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(collisionBox.X, collisionBox.Y + collisionBox.Height, collisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(collisionBox.X + collisionBox.Width, collisionBox.Y, 1, collisionBox.Height);
            Rectangle leftLine = new Rectangle(collisionBox.X, collisionBox.Y, 1, collisionBox.Height);

            spriteBatch.Draw(collisionTexture, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(collisionTexture, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        }
    }
}
