using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    /// <summary>
    /// 
    /// </summary>
    class Player : AnimatedGameObject
    {

        Viewport Viewport;
        private const float moveSpeed = 200;
    
        public Vector2 direction = new Vector2();
        /// <summary>
        /// Classer
        /// </summary>
        GameTimer gameTimer = new GameTimer();           
        private double lastShoot = 0;   
        private Vector2 bulletposition;     
        public int KillCount
        {
            get
            {
                return KillCount;
            }
        }
        private Vector2 sightpostotion;
        public Vector2 Sightpostotion {
            get
            {
                return sightpostotion;
            }
        }



        public Vector2 playerPosition {
            get
            {
                return position;
            }
                }  
        private int health;

        public int Health
        {
            get { return health; }
            set
            {
                health = value;
            }
        }

   

        public Player(ContentManager content) : base(1,5, new Vector2(GameWorld.ScreenSize.Width / 2, GameWorld.ScreenSize.Height / 2), content, "playerImg")
        {
            this.content = content;
            health = 1000;
           
            
            
        }
        public Vector2 RotateAboutOrigin(Vector2 point, Vector2 origin, float rotation)
        {
            return Vector2.Transform(point - origin, Matrix.CreateRotationZ(rotation)) +origin;
        }

        
        public override void Update(GameTime gameTime)
        {

      
            MouseState mouse = Mouse.GetState();
            direction.X = mouse.X - 1280/2 ;
            direction.Y = mouse.Y - 720 / 2; 
            rotation = (float)Math.Atan2(direction.Y, direction.X);
            direction = new Vector2((float)Math.Cos(rotation - MathHelper.Pi * 0.0f), (float)Math.Sin(rotation - MathHelper.Pi * 0.0f));

            position += direction * (float)(gameTime.ElapsedGameTime.TotalSeconds);

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                direction.X -= (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                direction.X += (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                direction.X -= (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);
              direction.X += (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }


            lastShoot += gameTime.ElapsedGameTime.TotalSeconds;
            bulletposition = position;
            sightposition = position;

            bulletposition.X += 35;
            bulletposition.Y += 10;

            bulletposition = RotateAboutOrigin(bulletposition, position, rotation);

            sightposition.X += 100;
            sightposition.Y  += 10;

            sightpostotion = RotateAboutOrigin(sightposition, position, rotation);

           



            if (mouse.LeftButton == ButtonState.Pressed && lastShoot > 0.3f)
            {
                GameWorld.AddGameObject(new Bullet(direction, bulletposition, content));
                lastShoot = 0;
                //explosionSound = content.Load<SoundEffect>("8bit_bomb_explosion").CreateInstance();
                //explosionSound.Play();
            }

           

            base.Update(gameTime);
        }


        /// <summary>
        /// enemys obejt kan attack hvert second hvor play vil misye healt og der komme en bloods animation og sætter til 0 
        /// </summary>
        /// <param name="otherObject"></param>
        public override void DoCollision( GameObject otherObject)
        {
            if (otherObject is Solid  )
            {

                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    position.X -= 4;
                }else if( Keyboard.GetState().IsKeyDown(Keys.W))
                {
                   
                    position.Y -= -4;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    position.X += 4;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    position.Y += 4;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    position.Y -= 4;
                }

            }

        }

      
    }
}
