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
    /// <summary>
    /// Class that represents the player
    /// </summary>
    class Player : AnimatedGameObject
    {
        private const float moveSpeed = 100;
        private const float rotationSpeed = MathHelper.Pi;
        public Vector2 direction = new Vector2();
        GameTimer gameTimer = new GameTimer();
        private double lastShoot = 0;
        private SoundEffectInstance explosionSound;
     
        public int KillCount
        {
            get
            {
                return KillCount;
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
        /// <summary>
        /// Sets the player stats and health
        /// </summary>
        /// <param name="content"></param>
        public Player(ContentManager content) : base(1,5, new Vector2(GameWorld.ScreenSize.Width / 2, GameWorld.ScreenSize.Height / 2), content, "playerImg")
        {
            this.content = content;
            health = 1000;
        }

        /// <summary>
        /// Sets controls mouse and keyboard,
        /// aswell as rotation and gun sound effect
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
                
            direction.X = mouse.X - position.X;
            direction.Y = mouse.Y - position.Y;

            rotation = (float)Math.Atan2(direction.Y, direction.X);

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

            direction = new Vector2((float)Math.Cos(rotation-MathHelper.Pi*0.0f), (float)Math.Sin(rotation - MathHelper.Pi * 0.0f));
            position += direction * (float)(gameTime.ElapsedGameTime.TotalSeconds);

            lastShoot += gameTime.ElapsedGameTime.TotalSeconds;
            if (mouse.LeftButton == ButtonState.Pressed && lastShoot > 0.3f)
            {
                GameWorld.AddGameObject(new Bullet(direction, position, content));
                lastShoot = 0;
                explosionSound = content.Load<SoundEffect>("8bit_bomb_explosion").CreateInstance();
                explosionSound.Play();
            }
            base.Update(gameTime);
        }
    }
}
