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
        protected ContentManager content;
        private SpriteBatch spriteBatch;
        private Texture2D backgroundImg;
    

        //        public List<GameObject> gameObjects = new List<GameObject>();
        //        private static List<GameObject> toBeAdded = new List<GameObject>();

        //        public List<GameObject> solidObejts = new List<GameObject>();
        //        private static List<GameObject> toBeAddeSolid = new List<GameObject>();

        //        public List<GameObject> Effects = new List<GameObject>();
        //        private static List<GameObject> toBeAddedEffect = new List<GameObject>();
        //        private static List<GameObject> toBeRemoved = new List<GameObject>();

        //        private Player player;



        //        Random rand = new Random();

        //        GameTimer gametimer;
        //        GameTimer Spawnspeed;

        //        public static int ScreenWith;
        //        public static int screenHeight;



        //        private int ammount = 0;
        //        private int WaveTimeOutPut;

        //        private int NumberOfgameObejts;
        //        static private int healthHold;
        //        public int HealhHold
        //        {

        //            get
        //            {
        //                return healthHold;
        //            }
        //        }

        //        static private int kills;
        //        public int Kills
        //        {
        //            get
        //            {
        //                return kills;

        //            }
        //        }
        //        private double spawtimeBetwenneEnemys;

        //        private static GraphicsDeviceManager graphics;

        //        public static Rectangle ScreenSize
        //        {
        //            get
        //            {
        //                return graphics.GraphicsDevice.Viewport.Bounds;
        //            }
        //        }


        private int level = 1;
        private GraphicsDevice graphicsDevice;

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


      
        public void Setlevel(int WavetimeOutput)
        {
            if (WavetimeOutput == 0)
            {
                level += 1;
            }           
        }

        protected virtual void LoadContent()
        {
            spriteBatch = new SpriteBatch(graphicsDevice);
            backgroundImg = content.Load<Texture2D>("bg-grass");
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






