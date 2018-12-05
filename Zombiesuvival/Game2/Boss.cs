﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game2
{
    /// <summary>
    /// Class that represents a boss
    /// </summary>
    class Boss : GameObject
    {
        /// <summary>
        /// Sets the boss stats
        /// </summary>
        float moveSpeed = 70;
        Random rand = new Random();
        Vector2 distance;
        private int holdNumber;
        private int damnge = 200;
        private double LastAttck = 0;
        private int bosshealth = 50;

        /// <summary>
        /// Spawns boss at random side of the map
        /// </summary>
        /// <param name="content">Content Manager for loading resources</param>
        public Boss(int HoldNumber, int SpawnDistansfromEachOther, ContentManager content) : base(content, "bosszombie")
        {
            if (HoldNumber <= 100)
            {
                position = new Vector2(rand.Next(-200, 0), rand.Next(GameWorld.ScreenSize.Height));//left
            }
            else if (HoldNumber >= 100 && HoldNumber <= 200)
            {
                position = new Vector2(rand.Next(GameWorld.ScreenSize.Width), rand.Next(-200, 0));//top
            }
            else if (HoldNumber >= 200 && HoldNumber <= 300)
            {
                position = new Vector2(rand.Next(GameWorld.ScreenSize.Width), GameWorld.ScreenSize.Height + rand.Next(0, 200));//bottom
            }
            else if (HoldNumber >= 300 && HoldNumber <= 400)
            {
                position = new Vector2(GameWorld.ScreenSize.Width + rand.Next(0, 200), rand.Next(GameWorld.ScreenSize.Height));//right
            }
        }

        /// <summary>
        /// Spawns boss at random side of the map
        /// </summary>
        /// <param name="content">Content Manager for loading resources</param>
        public Boss(ContentManager content) : base(content, "bosszombie")
        {
            holdNumber = rand.Next(0, 400);
            Thread.Sleep(100);

            if (holdNumber <= 100)
            {
                position = new Vector2(rand.Next(-200, 0), rand.Next(GameWorld.ScreenSize.Height));// left
            }
            else if (holdNumber >= 100 && holdNumber <= 200)
            {
                position = new Vector2(rand.Next(GameWorld.ScreenSize.Width), rand.Next(-200, 0));//top
            }
            else if (holdNumber >= 200 && holdNumber <= 300)
            {
                position = new Vector2(rand.Next(GameWorld.ScreenSize.Width), GameWorld.ScreenSize.Height + rand.Next(0, 200));//bottom
            }
            else if (holdNumber >= 300 && holdNumber <= 400)
            {
                position = new Vector2(GameWorld.ScreenSize.Width + rand.Next(0, 200), rand.Next(GameWorld.ScreenSize.Height));// right 
            }
        }

        /// <summary>
        /// Sets the direction of the boss in direction of the player
        /// </summary>
        private void SetRandomDirection()
        {
            Random rnd = new Random();
            Direction = new Vector2((rnd.Next(0, 2) * 2 - 1), (rnd.Next(0, 2) * 2 - 1)); //Set direction vector components to -1 or 1
            Direction.Normalize(); //Normalizes vector so that it is only a unit vector
        }

        private void SetDiraction()
        {
            Direction = realTimeplayerPosition - position;// Sets the direction of the boss in direction of the player
            Direction.Normalize();
        }

        /// <summary>
        /// Update method that moves the boss in direction of the player.
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
        /// Collide actions if bullet zombies die and boss loses health. If bullet it gets removed and if player it gets damage.
        /// </summary>
        /// <param name="otherObject">The object it collided with</param>
        public override void DoCollision(GameObject otherObject)
        {
            if (otherObject is Bullet)
            {
                Blood blood = new Blood( Position, content);
                BloodEffect bloodEffect = new BloodEffect(1, position, content);
                GameWorld.AddEFfect(blood);
                GameWorld.AddGameObject(bloodEffect);
                bosshealth --;
                if (bosshealth == 0) {
                    GameWorld.RemoveGameObject(this);
                    GameWorld.addKill();
                }
            }

            if (otherObject is Player && LastAttck > 0.5f)
            {
                PlayerBlood playerBlood = new PlayerBlood(realTimeplayerPosition, content);
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
