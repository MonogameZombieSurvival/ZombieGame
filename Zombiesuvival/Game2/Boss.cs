using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game2
{
    class Boss : GameObject
    {


        float moveSpeed = 70;
        Random rand = new Random();
        Vector2 distance;
        /// <summary>
        /// Gets the Size of the Asteroid
        /// </summary>
        private int holdNumber;
        private int damnge = 100;
        private double LastAttck = 0;
        private int bosshealth = 100;

        /// <summary>
        /// summens zzombies random out size mape set you own sobies on side and randow range;
        /// </summary>
        /// <param name="content">Content Manager for loading resources</param>
        /// 


        public Boss(int HoldNumber, int SpawnDistansfromEachOther, ContentManager content) : base(content, "bosszombie")
        {


            if (HoldNumber <= 100)
            {

                position = new Vector2(rand.Next(-200, 0), rand.Next(GameWorld.ScreenSize.Height));// from left side
            }
            else if (HoldNumber >= 100 && HoldNumber <= 200)
            {
                position = new Vector2(rand.Next(GameWorld.ScreenSize.Width), rand.Next(-200, 0));//from top
            }
            else if (HoldNumber >= 200 && HoldNumber <= 300)
            {
                position = new Vector2(rand.Next(GameWorld.ScreenSize.Width), GameWorld.ScreenSize.Height + rand.Next(0, 200));//form button
            }
            else if (HoldNumber >= 300 && HoldNumber <= 400)
            {
                position = new Vector2(GameWorld.ScreenSize.Width + rand.Next(0, 200), rand.Next(GameWorld.ScreenSize.Height));//from right side
            }
        }


        /// <summary>
        /// summens zzombies random out size mape;
        /// </summary>
        /// <param name="content">Content Manager for loading resources</param>
        public Boss(ContentManager content) : base(content, "bosszombie")
        {
            holdNumber = rand.Next(0, 400);
            Thread.Sleep(100);



            if (holdNumber <= 100)
            {
                position = new Vector2(rand.Next(-200, 0), rand.Next(GameWorld.ScreenSize.Height));// from left side
            }
            else if (holdNumber >= 100 && holdNumber <= 200)
            {
                position = new Vector2(rand.Next(GameWorld.ScreenSize.Width), rand.Next(-200, 0));//randowmtop
            }
            else if (holdNumber >= 200 && holdNumber <= 300)
            {
                position = new Vector2(rand.Next(GameWorld.ScreenSize.Width), GameWorld.ScreenSize.Height + rand.Next(0, 200));//form
            }
            else if (holdNumber >= 300 && holdNumber <= 400)
            {
                position = new Vector2(GameWorld.ScreenSize.Width + rand.Next(0, 200), rand.Next(GameWorld.ScreenSize.Height));//from right side
            }
        }

        /// <summary>
        /// Sets the direction of the asteroid to a random direction
        /// </summary>
        private void SetRandomDirection()
        {

            Random rnd = new Random();
            Direction = new Vector2((rnd.Next(0, 2) * 2 - 1), (rnd.Next(0, 2) * 2 - 1)); //Set direction vector components to -1 or 1
            Direction.Normalize(); //Normalizes vector so that it is only a unit vector
        }


        private void SetDiraction()
        {


            Direction = realTimeplayerPosition - position;
            Direction.Normalize();

        }



        /// <summary>
        /// Update method that moves the asteroid in a specified direction. If asteroid is outside screen it sets a new random direction
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {


            distance.X = realTimeplayerPosition.X - position.X;
            distance.Y = realTimeplayerPosition.Y - position.Y;

            rotation = (float)Math.Atan2(distance.Y, distance.X);


            SetDiraction();

            position += Direction * (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds); //Added direction vector to current position




            Direction = new Vector2((float)Math.Cos(rotation - MathHelper.Pi * 0.0f), (float)Math.Sin(rotation - MathHelper.Pi * 0.0f));

            position += Direction * (float)(gameTime.ElapsedGameTime.TotalSeconds);



            LastAttck += gameTime.ElapsedGameTime.TotalSeconds;




        }

        /// <summary>
        /// Do the collide action for the Asteroid. If Player or a Bullet it explodes. If bullet it explodes into smaller asteroids
        /// </summary>
        /// <param name="otherObject">The object it collided with</param>
        public override void DoCollision(GameObject otherObject)
        {

            if (otherObject is Bullet)
            {
                Bloood blood = new Bloood(1, Position, content);
                BloodeEffect bloodeEffect = new BloodeEffect(1, position, content);
                GameWorld.AddEFfect(blood);
                GameWorld.AddGameObject(bloodeEffect);
                bosshealth--;
                if (bosshealth == 0) {
                    GameWorld.RemoveGameObject(this);

                    GameWorld.addKill();
                }
           

            }

            if (otherObject is Player && LastAttck > 0.5f)
            {

                PlayerBlood playerBlood = new PlayerBlood(1, realTimeplayerPosition, content);
                GameWorld.DealDamngeToPlayer(damnge);
                GameWorld.AddGameObject(playerBlood);


                LastAttck = 0;
            }
            if (otherObject is Bullet)
            {
                GameWorld.RemoveGameObject(otherObject);

            }

        }
    }
}
