using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Threading;

namespace Game2
{
    /// <summary>
    /// Class that represents a zombie
    /// </summary>
    class Enemy : AnimatedGameObject
    {
        /// <summary>
        /// Sets the zombie stats
        /// </summary>
        float moveSpeed = 50;
        Random rand = new Random();
        Vector2 distance;
        private int distanceToAttack = 400;            
        private int damnge = 10;
        private double LastAttck=0;
        private double lastmovemet = 0;
        private double DistancetoPlayer=0;
        private double lastfram = 0;    

        /// <summary>
        /// Spawns zombies at random sides of the map
        /// </summary>
        /// <param name="content">Content Manager for loading resources</param>
        /// 

        public Enemy(ContentManager content) : base(1,1, content, $"zombie/move/skeleton-move_1")
        {
          
            position.X = 200;
            position.Y = 200;
            this.content = content;
        }
        /// <summary>
        /// sætter enenmyen op med hvilke enemy der(navn), Healt, positon, og animation
        /// </summary>
        /// <param name="content"></param>
        /// <param name="Enamy"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="freamcount"></param>
        /// <param name="animationfps"></param>
        public Enemy(ContentManager content, string Enamy,int x,int y,int freamcount, float animationfps ) : base(freamcount,animationfps,content, Enamy)
        {
            position.X = x;
            position.Y = y;

            SetRandomDirection();
            this.content = content;
         
        }
        /// <summary>
        /// Sets the direction of the zombies in direction of the player
        /// </summary>
        private void SetRandomDirection()
        {
            Random rnd = new Random();
            Direction = new Vector2((rnd.Next(0, 2) * 2 - 1), (rnd.Next(0, 2) * 2 - 1)); //Set direction vector components to -1 or 1
            Direction.Normalize(); //Normalizes vector so that it is only a unit vector

        }
        /// <summary>
        /// regner vectoren mellem enemyen ud
        /// </summary>
        private void SetDiraction()
        {
            Direction = realTimeplayerPosition - position;

            
            Direction.Normalize();

        }
        /// <summary>
        /// sætter rotation så enemien vender den vej den bevæger sig
        /// </summary>
        private void SetRotation()
        {
           
            rotation = (float)Math.Atan2(Direction.Y, Direction.X);

        }
        /// <summary>
        /// sætter rotation mod playeren
        /// </summary>
        private void SetRotationTowasPlayer()
        {
            distance.X = realTimeplayerPosition.X - position.X;
            distance.Y = realTimeplayerPosition.Y - position.Y;

            rotation = (float)Math.Atan2(distance.Y, distance.X);

        }
        /// <summary>
        /// enemy attack playern hvis den kommer inden for distanceforAttack.
        /// og movement speed af enemien blicer sat til 0 nå enemien kommer enden for 30 px
        /// </summary>
        /// <param name="gameTime"></param>
        public void AttckPlayer(GameTime gameTime)
        {

            distance = realTimeplayerPosition - position;
            DistancetoPlayer = Math.Sqrt((distance.X * distance.X) + (distance.Y * distance.Y));
            if (DistancetoPlayer < distanceToAttack)
            {
                SetDiraction();
                SetRotationTowasPlayer();
                position += Direction * (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);
                // Direction = new Vector2((float)Math.Cos(rotation - MathHelper.Pi * 0.0f), (float)Math.Sin(rotation - MathHelper.Pi * 0.0f));

            }

            if(DistancetoPlayer < 30)
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = 50;
            }
        }

        /// <summary>
        /// Update method that moves the zombies in direction of the player.
        /// </summary>    
        public override void Update(GameTime gameTime)
        {
            AttckPlayer(gameTime);
            if (lastmovemet > rand.Next(2, 6))
            {
                SetRandomDirection();
                lastmovemet = 0;
            }
            if (DistancetoPlayer > distanceToAttack)
            {
                SetRotation();
                position += Direction * (float)(moveSpeed * gameTime.ElapsedGameTime.TotalSeconds);
            }
            //Added direction vector to current position
            lastmovemet += gameTime.ElapsedGameTime.TotalSeconds;
            LastAttck += gameTime.ElapsedGameTime.TotalSeconds;
            lastfram += gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
        }

        /// <summary>
        /// Collide actions if bullet zombies die and boss loses health. If bullet it gets removed and if player it gets damage.
        /// </summary>
        /// <param name="otherObject">The object it collided with</param>
        public override void DoCollision(GameObject otherObject)
        {   
            // cheker om enemyen går in i et solid obejt
            if(otherObject is Solid || otherObject is NoTwalkerbelObejt&& lastmovemet <2)
            {
                SetRandomDirection();
                lastmovemet = 0;
            }
            /// checker om Enemyen bliver ramt
            if (otherObject is Bullet)
            {
                Blood blood = new Blood(Position, content);
                BloodEffect bloodEffect = new BloodEffect(1, position, content);
                GameWorld.AddEFfect(blood);
                GameWorld.AddGameObject(bloodEffect);
                GameWorld.RemoveGameObject(this);
                GameWorld.addKill();
            }
            // Attacks og checker for sistet attack så der ikke bliver angrabet hvert fram
            if (otherObject is Player  && LastAttck > 0.5f)
            {
                PlayerBlood playerBlood = new PlayerBlood( realTimeplayerPosition, content);
                GameWorld.DealDamngeToPlayer(damnge);
                GameWorld.AddGameObject(playerBlood);
                LastAttck = 0;
            }
        }  
    }
}
