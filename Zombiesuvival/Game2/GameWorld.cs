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
        private Player player;
        private GameTimer gametimer;
        private LevelManager level;
        private sighte sighte;

        /// <summary>
        /// Texttures,song, and text
        /// </sTummary>
        private SpriteFont WaveTimer;
        private SpriteFont KillCount;
        private SpriteFont mag;
        private Texture2D collisionTexture;
        private Song backgroundMusic;         
        private Texture2D backgroundImgEnd;
        private Texture2D backgroundImgWin;
        private Texture2D[] CutScene = new Texture2D[7];
        private Song bossSound;

        private double timer;

        Camera camera;
        Random rand = new Random();


        // tager player weapons to next lvl
        public static bool HavsMachinGun = false;
        public static bool HaveShotGun = false;

        /// <summary>
        /// fileds / varibler
        /// </summary>
        private bool IsPlayer = false;
        private bool level1 = false;
        private bool level2 = false;
        private bool level3 = false;
        private bool level4 = false;
        public static int ScreenWith;
        public static int screenHeight;

        public static int levels =0;
        public static int cutScenemanager=1;
        private int NumberOfgameObejts;// blive brugt til at sore for at der ikke kommer til at være for mange effetct obejter
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
            
            backgroundImgEnd = Content.Load<Texture2D>("gameover");
            backgroundImgWin = Content.Load<Texture2D>("winscreen");
          
            for (int i = 0; i < 7; i++)
            {
                CutScene[i] = Content.Load<Texture2D>($"cutsscene/zombiegame_{i}");
            }
            

            level = new LevelManager(Content, 0);

         
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
         
            WaveTimer = Content.Load<SpriteFont>("WaveTimer");
            KillCount = Content.Load<SpriteFont>("KillCount");
            collisionTexture = Content.Load<Texture2D>("CollisionTexture");
            mag = Content.Load<SpriteFont>("mag");

            
         
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
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (IsPlayer == true)
            {
                camera.update(player.playerPosition);
            }
            foreach (GameObject go in gameObjects)
            {

                player.Health = healthHold;
                go.Update(gameTime);
               
                go.GetPlayerPosition(player.playerPosition);
              
                go.GetSightePosition(player.Sightpostotion);

                if (player.playerPosition.Y < -2400 && level1 == true)
                {
                    level1 = false;
                    levels = 2;
                    cutScenemanager = 1;
                }

                if (player.playerPosition.Y <-2370 && player.playerPosition.Y>-2400
                    && player.playerPosition.X > 1200 && player.playerPosition.X < 1300 && level3 == true)
                {
                    level3 = false;
                    levels = 4;
                    cutScenemanager = 1;
                }


                // check for colisions
                foreach (GameObject other in gameObjects)
                {
                    if (go != other && go.IsColliding(other))
                    {
                        go.DoCollision(other);
                    }
                }
                
            }// update gameobejts

          
            level.addNextRooom();

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


            timer += gameTime.ElapsedGameTime.TotalSeconds;


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
            spriteBatch.End();

            spriteBatch.Begin();



            if (levels<= 0){
                spriteBatch.Draw(CutScene[0], new Rectangle(0, 0, 1280, 720), Color.White);
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {

                    gameObjects.Clear();
                    Effects.Clear();
                    solidObejts.Clear();

                    levels = 1;
                    level1 = true;
                    level = new LevelManager(Content, 1);
                    player = new Player(Content);
                    sighte = new sighte(Content);

                    gameObjects.Add(player);
                    gameObjects.Add(sighte);
                    healthHold = player.Health;
                    IsPlayer = true;                  
                }
                
            }


            if (Player.IsAlive == true)
            {

                if (levels == 2)
                {
                    gameObjects.Clear();
                    Effects.Clear();                    
                    switch (cutScenemanager)
                    {
                        case 1:
                            spriteBatch.Draw(CutScene[1], new Rectangle(0, 0, 1280, 720), Color.White);
                            if (Keyboard.GetState().IsKeyDown(Keys.Enter)&& timer > 1)
                            {
                                cutScenemanager += 1;
                                timer = 0;
                            }
                            break;
                        case 2:
                            spriteBatch.Draw(CutScene[2], new Rectangle(0, 0, 1280, 720), Color.White);
                           
                            if (Keyboard.GetState().IsKeyDown(Keys.Enter) && timer > 1)
                            {
                                timer =0 ;
                                cutScenemanager = 0;
                                level2 = true;
                            }                        
                            break;                                                 
                        default:
                            break;
                    }
                   


                    if (Keyboard.GetState().IsKeyDown(Keys.Enter)&& level2 == true)
                    {
                        level = new LevelManager(Content, 2);
                        gameObjects.Add(player = new Player(Content, HavsMachinGun, HaveShotGun));
                        gameObjects.Add(sighte = new sighte(Content));
                        gametimer = new GameTimer();

                        healthHold = 100;

                        levels = 100;
                    }
                }
            }

            if (levels == 3 )
            {
                gameObjects.Clear();
                Effects.Clear();
                switch (cutScenemanager)
                {
                    
                    case 1:
                        spriteBatch.Draw(CutScene[3], new Rectangle(0, 0, 1280, 720), Color.White);
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter) && timer > 1)
                        {
                            cutScenemanager += 1;
                            timer = 0;
                        }
                        break;
                    case 2:
                        spriteBatch.Draw(CutScene[4], new Rectangle(0, 0, 1280, 720), Color.White);

                        if (Keyboard.GetState().IsKeyDown(Keys.Enter) && timer > 1)
                        {
                            timer = 0;
                            cutScenemanager = 0;
                            level3 = true;
                        }
                        break;
                    default:
                        break;                    
                }


                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && level3 == true)
                {

                    gameObjects.Clear();
                    Effects.Clear();
                    level = new LevelManager(Content, 3);
                    gameObjects.Add(sighte = new sighte(Content));
                    gameObjects.Add(player = new Player(Content, HavsMachinGun, HaveShotGun));
                    gametimer = new GameTimer();

                    healthHold = 100;
                    levels = 100;
                }
            }


            if (levels == 4)
            {            
                gameObjects.Clear();
                Effects.Clear();               
                switch (cutScenemanager)
                {
                    case 1:
                        spriteBatch.Draw(CutScene[5], new Rectangle(0, 0, 1280, 720), Color.White);
                        if (Keyboard.GetState().IsKeyDown(Keys.Enter) && timer > 1)
                        {
                            cutScenemanager += 1;
                            timer = 0;
                        }
                        break;
                    case 2:
                        spriteBatch.Draw(CutScene[6], new Rectangle(0, 0, 1280, 720), Color.White);

                        if (Keyboard.GetState().IsKeyDown(Keys.Enter) && timer > 1)
                        {
                            timer = 0;
                            cutScenemanager = 0;
                            level4 = true;
                        }
                        break;
                    default:
                        break;
                }


                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && level4 == true)
                {

                    gameObjects.Clear();
                    Effects.Clear();
                    level = new LevelManager(Content, 4);
                    gameObjects.Add(sighte = new sighte(Content));
                    gameObjects.Add(player = new Player(Content, HavsMachinGun, HaveShotGun));
                    gametimer = new GameTimer();

                    healthHold = 100;
                    levels = 100;
                }
            }

            if (levels>= 1)
            {
                spriteBatch.DrawString(mag, $"Magasin:{player.Mag} and PlayerPosition X {player.playerPosition.X} and Y {player.playerPosition.Y}    ", new Vector2(90, 5), Color.Blue);
                spriteBatch.DrawString(WaveTimer, $"Health:{player.Health}", new Vector2(5, 5), Color.Blue);
                spriteBatch.DrawString(KillCount, $"KilleCount:{Kills}", new Vector2(1160, 5), Color.Red);
            }

            if (Player.IsAlive == false)
            {
                   gameObjects.Clear();
                   Effects.Clear();
                   spriteBatch.Draw(backgroundImgEnd, new Rectangle(0, 0, 1280, 720), Color.White);
      
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {

                    level = new LevelManager(Content, 1);
                    gameObjects.Add(player = new Player(Content));
                    gameObjects.Add(sighte = new sighte(Content));
                    gametimer = new GameTimer();               
                    healthHold = 100;
                    Player.IsAlive = true;
                }
            }

        
            
            spriteBatch.End();
            base.Draw(gameTime);
            
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
