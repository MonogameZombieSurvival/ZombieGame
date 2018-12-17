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
    class Enemy2 : GameObject
    {
        /// <summary>
        /// Sets the zombie stats
        /// </summary>
        float moveSpeed = 150;
        Random rand = new Random();
        Vector2 distance;
        private int distanceToAttack = 400;
        private int damnge = 10;
        private double LastAttck = 0;
        private double lastmovemet = 0;
        private double DistancetoPlayer = 0;
        private double lastfram = 0;
        
        private int framcountmov = 0;
        private int AnimationframsWalk;
        private int AnimationframsAttack;


        private int oldfram;
        private string EnemyName;
        private string EnemyWalk;
        private string EnemyAttack;

        bool walk = true;
        bool Attack = false;
        
        /// <summary>
        /// Default Enemy
        /// </summary>
        /// <param name="content">Content Manager for loading resources</param>
        public Enemy2(ContentManager content) : base(content, $"zombie/move/skeleton-move_1")
        {
           
            
            position.X = 200;
            position.Y = 200;
            this.content = content;
        }
        /// <summary>
        /// sætter enemyin me posistion navn(Hvilken enemy det er), Health, og animation ,
        /// </summary>
        /// <param name="content"></param>
        /// <param name="Enamy"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="framcount"></param>
        /// <param name="freamcountAttack"></param>
        public Enemy2(ContentManager content, string Enamy, int x, int y, int framcount,int freamcountAttack) : base(content, Enamy)
        {
            position.X = x;
            position.Y = y;
            EnemyName = Enamy;
            AnimationframsWalk = framcount;
            AnimationframsAttack = freamcountAttack;
            SetRandomDirection();
            this.content = content;
            EnemyWalk = EnemyName;
           
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

            if (DistancetoPlayer < 30)
            {

                EnemyAttack = "zombie/attack/skeleton-attack_0";
                Attack = true;
                walk = false;
                EnemyName = EnemyAttack;
                moveSpeed = 0;
            }
            else
            {
                EnemyName = EnemyWalk;
                moveSpeed = 50;
                Attack = false;
                walk = true;
                
            }
        }

        /// <summary>
        ///  sets the animationfram
        /// </summary>
        public void AnimtionFrams()
        {

            oldfram = framcountmov;

            if (walk == true)
            {
                if (lastfram > 0.05)
                {
                    framcountmov += 1;
                    lastfram = 0;
                }
                if (framcountmov >= 16)
                {
                    framcountmov = 0;
                }
            }

            if(Attack == true)
            {
                if (lastfram > 0.05)
                {
                    framcountmov += 1;
                    lastfram = 0;
                }
                if (framcountmov >= AnimationframsAttack)
                {
                    framcountmov = 0;
                }
            }
        }

        /// <summary>
        /// Update method that moves the zombies in direction of the player.
        /// </summary>
        public override void Update(GameTime gameTime)
        {
            AttckPlayer(gameTime);
            AnimtionFrams();

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
           if (otherObject is SolidObejts || otherObject is NoTwalkerbelObejt && lastmovemet < 2)
            {
                SetRandomDirection();
                lastmovemet = 0;
            }

            if (otherObject is Bullet)
            {
                Blood blood = new Blood(Position, content);
                BloodEffect bloodEffect = new BloodEffect(1, position, content);
                GameWorld.AddEFfect(blood);
                GameWorld.AddGameObject(bloodEffect);
                GameWorld.RemoveGameObject(this);
                GameWorld.addKill();
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

        /// <summary>
        /// removes latter fra name stringen så der kan blive smit et nyt in så der kan køre en animation a billere fra en mappe
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Removelastletter(string input)
        {           
            string output;
            if (oldfram >=16) { 

               output = input.Remove(input.Length - 2);         
               

            } else
            {
                output = input.Remove(input.Length - 1);
            }                      
            return output;

        }

        /// <summary>
        /// Draw nyt aniamtion fram
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {

          
            EnemyName = Removelastletter(EnemyName);

            EnemyName += framcountmov;

            
            spiteName = EnemyName;

            sprite = content.Load<Texture2D>(spiteName);
            spriteBatch.Draw(sprite, position, null, Color.White, rotation, new Vector2(sprite.Width * 0.5f, sprite.Height * 0.5f), 1, new SpriteEffects(), 0f);
        }


    }
}
