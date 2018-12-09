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

       
        private const float moveSpeed = 1000;
    
        public Vector2 direction = new Vector2();
        /// <summary>
        /// Classer
        /// </summary>
        GameTimer gameTimer = new GameTimer();           
        private double lastShoot = 0;   
        private Vector2 bulletposition;     
     
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
        public int KillCount
        {
            get
            {
                return KillCount;
            }
        }

        
        /// Pistol values
        private float pistilshootspeed= 0.3f;
        private int PistiolMag = 15;
        private int Pistiobulletshot=0;
        bool Havepistiol = true;

        ///
        ///machingun values
        private float Machigunspeed = 0.1f;
        private double Machingunrange;
        private int MachingunBulletshot;
        private int MachingunMag = 40;
        bool HaveMachinGun = false;
        bool MachingunOn = false;

        /// shot gun values
        private double shotgunrange;
        private float shotgunSpeed = 1f;
        private int shotgunshotsfired = 0;
        private int shotfunMag = 5;
        bool shotgunOn = false;

      
     
        bool Haveshotgun = false;
        /// <summary>
        /// default constucter
        /// </summary>
        /// <param name="content"></param>
        public Player(ContentManager content) : base(1,10, new Vector2(GameWorld.ScreenSize.Width / 2, GameWorld.ScreenSize.Height / 2), content, "playerImg")
        {
            this.content = content;
            health = 10;
           
            
            
        }


  /// <summary>
  /// return the vector pistion for hvor bullet ud fra player bliver loaded 
  /// </summary>
  /// <param name="point"></param>
  /// <param name="origin"></param>
  /// <param name="rotation"></param>
  /// <returns></returns>
        public Vector2 RotateAboutOrigin(Vector2 point, Vector2 origin, float rotation)
        {
            return Vector2.Transform(point - origin, Matrix.CreateRotationZ(rotation)) +origin;
        }
        /// <summary>
        /// bevæger playeren med WDAD keysne 
        /// </summary>
        /// <param name="gameTime"></param>
        private void WSADMovement(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);

            }

        }

        /// <summary>
        /// change players weapon
        /// </summary>
        /// <param name="gameTime"></param>
        public void ChangeWeapon(GameTime gameTime) {

            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                Havepistiol = true;
                MachingunOn = false;
                shotgunOn = false;
            }

           if (HaveMachinGun == true)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D2))
                {
                    Havepistiol = false;
                    shotgunOn = false;
                    MachingunOn = true;
                }
               }
              if (Haveshotgun == true)
               {
                if (Keyboard.GetState().IsKeyDown(Keys.D3))
                {
                    Havepistiol = false;
                    MachingunOn = false;
                    shotgunOn = true;
                }
            }
        }

        /// <summary>
        /// reloard
        /// </summary>
        public void reloard()
        {
            if (PistiolMag==Pistiobulletshot)
            {
                Pistiobulletshot = 0;
                pistilshootspeed = 10000000;

            }

            if (Keyboard.GetState().IsKeyDown(Keys.R) && Havepistiol == true)
            {
                pistilshootspeed = 0.3f;
            }

            if(MachingunMag== MachingunBulletshot)
            {
                Machigunspeed = 10000000;
                MachingunBulletshot =0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R) && MachingunOn == true)
            {
                Machigunspeed = 0.1f;
            }

            if (shotfunMag== shotgunshotsfired)
            {
                shotgunSpeed = 10000000;
                shotgunshotsfired = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.R) && shotgunOn== true)
            {
                shotgunSpeed = 0.5f;
            }

        }
        /// <summary>
        /// upaate player
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {

      
            MouseState mouse = Mouse.GetState();

            direction.X = mouse.X - 1280/2 ;
            direction.Y = mouse.Y - 720/2; 
            rotation = (float)Math.Atan2(direction.Y, direction.X);
            direction = new Vector2((float)Math.Cos(rotation - MathHelper.Pi * 0.0f), (float)Math.Sin(rotation - MathHelper.Pi * 0.0f));

            position += direction * (float)(gameTime.ElapsedGameTime.TotalSeconds);

            WSADMovement(gameTime);

            lastShoot += gameTime.ElapsedGameTime.TotalSeconds;
            bulletposition = position;  
            
            bulletposition.X += 35;
            bulletposition.Y += 10;

            bulletposition = RotateAboutOrigin(bulletposition, position, rotation);

        
            sightposition.X = mouse.X;
            sightposition.Y = mouse.Y;


            // change wåpen på spilelren
            ChangeWeapon(gameTime);



            //reload
            reloard();

            // shute with machingun
            if (mouse.LeftButton == ButtonState.Pressed && lastShoot > Machigunspeed && HaveMachinGun == true && MachingunOn == true)
            {
                GameWorld.AddGameObject(new Bullet(direction, bulletposition, content));
                lastShoot = 0;

                MachingunBulletshot += 1;
                //explosionSound = content.Load<SoundEffect>("8bit_bomb_explosion").CreateInstance();
                //explosionSound.Play();
                
            }
            

            // shute with gun
            if (mouse.LeftButton == ButtonState.Pressed && lastShoot > pistilshootspeed && Havepistiol == true  )
            {
                GameWorld.AddGameObject(new Bullet(direction, bulletposition, content));
                lastShoot = 0;
                //explosionSound = content.Load<SoundEffect>("8bit_bomb_explosion").CreateInstance();
                //explosionSound.Play();
                Pistiobulletshot += 1;
            }

          

            if (mouse.LeftButton == ButtonState.Pressed && lastShoot > shotgunSpeed && Haveshotgun == true && shotgunOn == true)
            {
                GameWorld.AddGameObject(new Bullet(direction, bulletposition, content));           
          
                GameWorld.AddGameObject(new Bullet(new Vector2(direction.X + 0.4f, direction.Y -0.1f), new Vector2(bulletposition.X, bulletposition.Y), content));
                GameWorld.AddGameObject(new Bullet(new Vector2(direction.X - 0.1f, direction.Y -0.2f), new Vector2(bulletposition.X, bulletposition.Y), content));
                GameWorld.AddGameObject(new Bullet(new Vector2(direction.X - 0.2f, direction.Y -0.3f), new Vector2(bulletposition.X, bulletposition.Y), content));
                GameWorld.AddGameObject(new Bullet(new Vector2(direction.X - 0.3f, direction.Y -0.4f), new Vector2(bulletposition.X, bulletposition.Y), content));
                GameWorld.AddGameObject(new Bullet(new Vector2(direction.X - 0.4f, direction.Y +0.1f), new Vector2(bulletposition.X, bulletposition.Y), content));
                GameWorld.AddGameObject(new Bullet(new Vector2(direction.X + 0.1f, direction.Y +0.2f), new Vector2(bulletposition.X, bulletposition.Y), content));
                GameWorld.AddGameObject(new Bullet(new Vector2(direction.X + 0.2f, direction.Y +0.3f), new Vector2(bulletposition.X, bulletposition.Y), content));
                GameWorld.AddGameObject(new Bullet(new Vector2(direction.X + 0.3f, direction.Y +0.4f), new Vector2(bulletposition.X, bulletposition.Y), content));


                shotgunshotsfired += 1;
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

            if (otherObject is Bullet)
            {
                GameWorld.RemoveGameObject(otherObject);
            }
           if(otherObject is Shotgun)
            {
                Haveshotgun = true;
            }
            if(otherObject is Machingun)
            {
               HaveMachinGun = true;
            }
            
            if (otherObject is Solid ||otherObject is NoTwalkerbelObejt  )
            {

                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    position.X -= 4;
                    
                    sightposition.X -= 4;
                }else if( Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    sightposition.Y -= 4;
                    position.Y -= -4;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    sightposition.X += 4;
                    position.X += 4;
                }

              
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    sightposition.Y -= 4;
                    position.Y -= 4;
                }

            }

        }

      
    }
}
